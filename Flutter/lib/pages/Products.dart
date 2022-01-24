import 'dart:async';
import 'dart:convert';
import 'package:flutter/foundation.dart';
import 'package:flutter/material.dart';
import 'package:vjezbe2_app/models/Proizvodi.dart';
import 'package:vjezbe2_app/models/VrsteProizvoda.dart';
import 'package:vjezbe2_app/pages/ProductDetails.dart';
import 'package:vjezbe2_app/services/APIService.dart';

class Products extends StatefulWidget {
  @override
  _ProductsState createState() => _ProductsState();
}

class _ProductsState extends State<Products> {
  VrsteProizvoda _selectedVrstaProizvoda = null;
  List<DropdownMenuItem> items = [];

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Proizvodi'),
        backgroundColor: Colors.amber[700],
      ),
      body: Column(
        children: [
          Center(child:dropDownWidget()),
          Expanded(child: bodyWidget()),
        ],
      ),
    );
  }

  Widget dropDownWidget() {
    return FutureBuilder<List<VrsteProizvoda>>(
        future: GetProductsTypes(_selectedVrstaProizvoda),
        builder: (BuildContext context,
            AsyncSnapshot<List<VrsteProizvoda>> snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return Center(
              child: Text('Loading...'),
            );
          }
          else {
            if (snapshot.hasError) {
              return Center(
                child: Text('${snapshot.error}'),
              );
            }
            else {
              return Padding(
                padding: EdgeInsets.fromLTRB(30, 10, 30, 10),
                child: DropdownButton(
                  hint: Text('Odaberite vrstu proizvoda'),
                  isExpanded: true,
                  items: items,
                  onChanged: (newVal) {
                    setState(() {
                        _selectedVrstaProizvoda = newVal;
                        GetProducts(_selectedVrstaProizvoda);
                    });
                  },
                  value: _selectedVrstaProizvoda,
                ),
              );
            }
          }
        });
  }

  Future<List<VrsteProizvoda>> GetProductsTypes(VrsteProizvoda selectedItem) async {
    var vrsteProizvoda = await APIService.Get('VrsteProizvodum', null);
    var vrsteProizvodaList = vrsteProizvoda.map((i) => VrsteProizvoda.fromJson(i)).toList();

    items = vrsteProizvodaList.map((item) {
      return DropdownMenuItem<VrsteProizvoda>(
        child: Text(item.naziv),
        value: item,
      );
    }).toList();

      if (selectedItem != null && selectedItem.vrstaId != 0)
      _selectedVrstaProizvoda = vrsteProizvodaList.where((element) => element.vrstaId == selectedItem.vrstaId).first;
        return vrsteProizvodaList;
   }

  Widget bodyWidget() {
    return FutureBuilder<List<Proizvodi>>(
        future: GetProducts(_selectedVrstaProizvoda),
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
              return ListView(
                children: snapshot.data.map((e) => ProizvodiWidget(e)).toList(),
              );
            }
          }
        });
  }

  Future<List<Proizvodi>> GetProducts(VrsteProizvoda selectedItem) async {
    Map<String, String> queryParams = null;
    if (selectedItem != null && selectedItem.vrstaId != 0)
      queryParams = {'VrstaId': selectedItem.vrstaId.toString()};

    var proizvodi = await APIService.Get('Proizvodi', queryParams);
    return proizvodi.map((i) => Proizvodi.fromJson(i)).toList();
  }

  Widget ProizvodiWidget(proizvod) {
    return Card(
      child: TextButton(
        onPressed: () {
          Navigator.push(
              context,
              MaterialPageRoute(
                  builder: (context) => ProductDetails(
                        product: proizvod,
                      )));
        },
        child: Padding(
          padding: EdgeInsets.all(20),
          child: Row(
            children: [
              Expanded(
                child: Text(
                  proizvod.naziv + ' (' + proizvod.cijena + ' KM)',
                  style: TextStyle(color: Colors.black),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
