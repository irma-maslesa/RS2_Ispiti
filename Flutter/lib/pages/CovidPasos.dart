import 'dart:async';

import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:vjezbe2_app/models/LoV.dart';
import 'package:vjezbe2_app/models/NarudzbaPasos.dart';
import 'package:vjezbe2_app/pages/ProductDetails.dart';
import 'package:vjezbe2_app/services/APIService.dart';

class CovidPasos extends StatefulWidget {
  @override
  _CovidPasosState createState() => _CovidPasosState();
}

class _CovidPasosState extends State<CovidPasos> {
  LoV _selectedKupac = null;
  List<DropdownMenuItem> items = [];

  DateTime _selectedDatumOd = DateTime.now();
  DateTime _selectedDatumDo = DateTime.now();

  _selectDateOd(BuildContext context) async {
    final DateTime picked = await showDatePicker(
      context: context,
      initialDate: _selectedDatumOd, // Refer step 1
      firstDate: DateTime(2000),
      lastDate: DateTime(2025),
    );
    if (picked != null && picked != _selectedDatumOd)
      setState(() {
        _selectedDatumOd = picked;
      });
  }

  _selectDateDo(BuildContext context) async {
    final DateTime picked = await showDatePicker(
      context: context,
      initialDate: _selectedDatumDo, // Refer step 1
      firstDate: DateTime(2000),
      lastDate: DateTime(2025),
    );
    if (picked != null && picked != _selectedDatumDo)
      setState(() {
        _selectedDatumDo = picked;
      });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Narudzbe'),
        backgroundColor: Colors.amber[700],
      ),
      body: Column(
        children: [
          Center(child: dropDownWidget()),
          Center(
              child: TextButton(
            child: Text("Datum od"),
            onPressed: () => _selectDateOd(context),
          )),
          Center(
              child: TextButton(
            child: Text("Datum do"),
            onPressed: () => _selectDateDo(context),
          )),
          Expanded(child: bodyWidget()),
        ],
      ),
    );
  }

  Widget dropDownWidget() {
    return FutureBuilder<List<LoV>>(
        future: GetKupce(_selectedKupac),
        builder: (BuildContext context, AsyncSnapshot<List<LoV>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return Padding(
                padding: EdgeInsets.fromLTRB(30, 10, 30, 10),
                child: DropdownButton(
                  hint: Text('Odaberite kupca'),
                  isExpanded: true,
                  items: items,
                  onChanged: (newVal) {
                    setState(() {
                      _selectedKupac = newVal;
                    });
                  },
                  value: _selectedKupac,
                ),
              );
            }
          }
        });
  }

  Future<List<LoV>> GetKupce(LoV selectedItem) async {
    var kupci = await APIService.Get('CovidPasos/kupci', null);
    var kupciList = kupci.map((i) => LoV.fromJson(i)).toList();

    items = kupciList.map((item) {
      return DropdownMenuItem<LoV>(
        child: Text(item.naziv),
        value: item,
      );
    }).toList();

    if (selectedItem != null && selectedItem.id != 0)
      _selectedKupac =
          kupciList.where((element) => element.id == selectedItem.id).first;
    return kupciList;
  }

  Widget bodyWidget() {
    return FutureBuilder<List<NarudzbaPasos>>(
        future: GetNarudzbe(_selectedKupac, _selectedDatumOd, _selectedDatumDo),
        builder: (BuildContext context,
            AsyncSnapshot<List<NarudzbaPasos>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          } else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            } else {
              return ListView(
                children: snapshot.data.map((e) => NarudzbaWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<NarudzbaPasos>> GetNarudzbe(LoV selectedItem,
      DateTime selectedDatumOd, DateTime selectedDatumDo) async {
    final Map<String, String> queryParams = {};
    if (selectedItem != null && selectedItem.id != 0)
      queryParams.addAll({"kupacId": selectedItem.id.toString()});

    if (selectedDatumOd != null)
      queryParams.addAll({"datumOd": selectedDatumOd.toString()});

    if (selectedDatumDo != null)
      queryParams.addAll({"datumDo": selectedDatumDo.toString()});

    var proizvodi = await APIService.Get('CovidPasos/narudzbe', queryParams);
    return proizvodi.map((i) => NarudzbaPasos.fromJson(i)).toList();
  }

  Widget NarudzbaWidget(NarudzbaPasos narudzbaPasos) {
    return Card(
      child: Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          children: [
            Text(
              narudzbaPasos.brojNarudzbe,
              style: TextStyle(color: Colors.black),
            ),
            Text(
              new DateFormat("dd/MM/yyyy, hh:mm").format(narudzbaPasos.datum),
              style: TextStyle(color: Colors.black),
            ),
            Row(mainAxisAlignment: MainAxisAlignment.spaceAround, children: [
              Text(
                "${narudzbaPasos.cijena.toStringAsFixed(2)}KM",
                style: TextStyle(color: Colors.black),
              ),
              Text(
                narudzbaPasos.vazeciPasos ? "Važeći pasoš" : "Bez pasoša",
                style: TextStyle(color: Colors.black),
              ),
            ]),
          ],
        ),
      ),
    );
  }
}
