import 'dart:async';
import 'dart:convert';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:vjezbe2_app/models/Komentari.dart';
import 'package:vjezbe2_app/models/Proizvodi.dart';
import 'package:vjezbe2_app/models/Proizvodi.dart';
import 'package:vjezbe2_app/pages/ProductDetails.dart';
import 'package:vjezbe2_app/services/APIService.dart';

class Komentari extends StatefulWidget {
  @override
  _KomentariState createState() => _KomentariState();
}

class _KomentariState extends State<Komentari> {
  Proizvodi _selectedProizvod = null;
  List<DropdownMenuItem> items = [];

  DateTime _selectedDatumOd = DateTime.now();
  DateTime _selectedDatumDo = DateTime.now();

  TextEditingController datumOd = new TextEditingController();
  TextEditingController datumDo = new TextEditingController();

  @override
  Widget build(BuildContext context) {
    datumOd.text =
        "${_selectedDatumOd.day}/${_selectedDatumOd.month}/${_selectedDatumOd.year}";
    datumDo.text =
        "${_selectedDatumDo.day}/${_selectedDatumDo.month}/${_selectedDatumDo.year}";

    _showDatePickerOd(BuildContext context) async {
      final DateTime picked = await showDatePicker(
          context: context,
          initialDate: _selectedDatumOd,
          firstDate: DateTime(2000),
          lastDate: DateTime(2023));

      if (picked != null && picked != _selectedDatumOd)
        setState(() {
          _selectedDatumOd = picked;
        });
    }

    _showDatePickerDo(BuildContext context) async {
      final DateTime picked = await showDatePicker(
        context: context,
        initialDate: _selectedDatumDo,
        firstDate: DateTime(2000),
        lastDate: DateTime(2023),
      );

      if (picked != null && picked != _selectedDatumDo)
        setState(() {
          _selectedDatumDo = picked;
        });
    }

    return Scaffold(
      appBar: AppBar(
        title: Text('Komentari'),
        backgroundColor: Colors.amber[700],
      ),
      body: Column(
        children: [
          Center(child: dropDownWidget()),
          Center(
            child: Padding(
              padding: EdgeInsets.fromLTRB(30, 10, 30, 10),
              child: TextField(
                controller: datumOd,
                readOnly: true,
                onTap: () => _showDatePickerOd(context),
              ),
            ),
          ),
          Center(
            child: Padding(
                padding: EdgeInsets.fromLTRB(30, 10, 30, 10),
                child: TextField(
                  controller: datumDo,
                  readOnly: true,
                  onTap: () => _showDatePickerDo(context),
                )),
          ),
          Expanded(child: bodyWidget()),
        ],
      ),
    );
  }

  Widget dropDownWidget() {
    return FutureBuilder<List<Proizvodi>>(
        future: getProizvodi(_selectedProizvod),
        builder:
            (BuildContext context, AsyncSnapshot<List<Proizvodi>> snapshot) {
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
                  hint: Text('Odaberite proizvod'),
                  isExpanded: true,
                  items: items,
                  onChanged: (newVal) {
                    setState(() {
                      _selectedProizvod = newVal;
                    });
                  },
                  value: _selectedProizvod,
                ),
              );
            }
          }
        });
  }

  Future<List<Proizvodi>> getProizvodi(Proizvodi selectedItem) async {
    var proizvodi = await APIService.Get('Proizvodi', null);
    var proizvodiList = proizvodi.map((i) => Proizvodi.fromJson(i)).toList();

    items = proizvodiList.map((item) {
      return DropdownMenuItem<Proizvodi>(
        child: Text(item.naziv),
        value: item,
      );
    }).toList();

    if (selectedItem != null && selectedItem.proizvodId != 0)
      _selectedProizvod = proizvodiList
          .where((element) => element.proizvodId == selectedItem.proizvodId)
          .first;
    return proizvodiList;
  }

  Widget bodyWidget() {
    return FutureBuilder<List<Komentar>>(
        future:
            GetKomentari(_selectedProizvod, _selectedDatumOd, _selectedDatumDo),
        builder:
            (BuildContext context, AsyncSnapshot<List<Komentar>> snapshot) {
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
                children: snapshot.data.map((e) => KomentariWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<Komentar>> GetKomentari(Proizvodi selectedItem,
      DateTime selectedDatumOd, DateTime selectedDatumDo) async {
    Map<String, String> queryParams = {};
    if (selectedItem != null && selectedItem.proizvodId != 0)
      queryParams.addAll({'ProizvodId': selectedItem.proizvodId.toString()});

    if (selectedDatumOd != null)
      queryParams.addAll({'DatumOd': selectedDatumOd.toString()});

    if (selectedDatumDo != null)
      queryParams.addAll({'DatumDo': selectedDatumDo.toString()});

    var proizvodi =
        await APIService.Get('ProizvodKomentari/search', queryParams);
    return proizvodi.map((i) => Komentar.fromJson(i)).toList();
  }

  Widget KomentariWidget(Komentar komentar) {
    return Card(
      child: Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          crossAxisAlignment: CrossAxisAlignment.center,
          children: [
            Text(
              komentar.komentar,
              style: TextStyle(color: Colors.black),
            ),
            Text(
              komentar.kupacImePrezime,
              style: TextStyle(color: Colors.black),
            ),
            Text(
              "${komentar.datum.day}/${komentar.datum.month}/${komentar.datum.year}, ${komentar.datum.hour}:${komentar.datum.minute}",
              style: TextStyle(color: Colors.black),
            ),
            Text(
              "Broj riječi: ${komentar.brojRijeci}",
              style: TextStyle(color: Colors.black),
            ),
          ],
        ),
      ),
    );
  }
}
