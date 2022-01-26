import 'dart:async';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:vjezbe2_app/models/Korisnici.dart';
import 'package:vjezbe2_app/models/PretragaIspit.dart';
import 'package:vjezbe2_app/models/Proizvodi.dart';
import 'package:vjezbe2_app/models/Korisnici.dart';
import 'package:vjezbe2_app/pages/ProductDetails.dart';
import 'package:vjezbe2_app/services/APIService.dart';

class Pretrage extends StatefulWidget {
  @override
  _PretrageState createState() => _PretrageState();
}

class _PretrageState extends State<Pretrage> {
  Korisnici _selectedKorisnik = null;
  List<DropdownMenuItem> items = [];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Pretrage'),
        backgroundColor: Colors.amber[700],
      ),
      body: Column(
        children: [
          Center(child: dropDownWidget()),
          Expanded(child: bodyWidget()),
        ],
      ),
    );
  }

  Widget dropDownWidget() {
    return FutureBuilder<List<Korisnici>>(
        future: GetPretrageTypes(_selectedKorisnik),
        builder:
            (BuildContext context, AsyncSnapshot<List<Korisnici>> snapshot) {
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
                  hint: Text('Odaberite korisnika'),
                  isExpanded: true,
                  items: items,
                  onChanged: (newVal) {
                    setState(() {
                      _selectedKorisnik = newVal;
                      GetPretrage(_selectedKorisnik);
                    });
                  },
                  value: _selectedKorisnik,
                ),
              );
            }
          }
        });
  }

  Future<List<Korisnici>> GetPretrageTypes(Korisnici selectedItem) async {
    var korisnici = await APIService.Get('Korisnici', null);
    var korisniciList = korisnici.map((i) => Korisnici.fromJson(i)).toList();

    items = korisniciList.map((item) {
      return DropdownMenuItem<Korisnici>(
        child: Text("${item.ime} ${item.prezime}"),
        value: item,
      );
    }).toList();

    if (selectedItem != null && selectedItem.korisnikId != 0)
      _selectedKorisnik = korisniciList
          .where((element) => element.korisnikId == selectedItem.korisnikId)
          .first;
    else
      _selectedKorisnik = korisniciList.first;

    return korisniciList;
  }

  Widget bodyWidget() {
    return FutureBuilder<List<PretragaIspit>>(
        future: GetPretrage(_selectedKorisnik),
        builder: (BuildContext context,
            AsyncSnapshot<List<PretragaIspit>> snapshot) {
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
                children: snapshot.data.map((e) => ProizvodiWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<PretragaIspit>> GetPretrage(Korisnici selectedItem) async {
    Map<String, String> queryParams = null;
    if (selectedItem != null && selectedItem.korisnikId != 0)
      queryParams = {'korisnikId': selectedItem.korisnikId.toString()};

    var proizvodi = await APIService.Get('PretragaIspit/zapisi', queryParams);
    return proizvodi.map((i) => PretragaIspit.fromJson(i)).toList();
  }

  Widget ProizvodiWidget(PretragaIspit pretraga) {
    return Card(
      child: Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          children: [
            Text(
              pretraga.korsinikImePrezime,
              style: TextStyle(color: Colors.black),
            ),
            Text(
              "${new DateFormat("dd/MM/yyyy, hh:mm").format(pretraga.datumOd)} - ${new DateFormat("dd/MM/yyyy, hh:mm").format(pretraga.datumDo)}",
              style: TextStyle(color: Colors.black),
            ),
            Text(
              "Min iznos: ${pretraga.minIznos.toStringAsFixed(2)}",
              style: TextStyle(color: Colors.black),
            ),
            Text(
              "Iznos: ${pretraga.iznos.toStringAsFixed(2)}",
              style: TextStyle(color: Colors.black),
            ),
            Text(
              "Vrsta proizvoda: ${pretraga.vrstaProizvodaId}",
              style: TextStyle(color: Colors.black),
            ),
            Text(
              "Prosječan promet: ${pretraga.prosjecanPromet}",
              style: TextStyle(color: Colors.black),
            ),
          ],
        ),
      ),
    );
  }
}
