import 'dart:ui';
import 'package:flutter/material.dart';
import 'dart:io';
import 'dart:convert';
import 'package:vjezbe2_app/models/Proizvodi.dart';
import 'package:vjezbe2_app/services/CartService.dart';

class ProductDetails extends StatelessWidget {
  final Proizvodi product;
  ProductDetails({Key key, this.product}) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text(
          'Detalji prozivoda',
          style: TextStyle(fontSize: 20),
        ),
        backgroundColor: Colors.amber[700],
      ),
      body: Column(
        children: [
          Center(
            child: Image(
                height: 300, width: 300, image: MemoryImage(product.slika)),
          ),
          Text(
            product.naziv + ' ' + '(' + product.cijena + ') ' + 'KM',
            style: TextStyle(fontSize: 20),
          ),
          Padding(
              padding: EdgeInsets.all(50),
              child: TextButton(
                onPressed: (){
                  CartService.AddProduct(product, 1);
                },
                  child: Image(
                      width: 100,
                      height: 100,
                      image: AssetImage('assets/korpa.jpg')),

              )
          )
        ],
      ),
    );
  }
}
