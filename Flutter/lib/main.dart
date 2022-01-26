import 'dart:io';
import 'package:flutter/material.dart';
import 'package:vjezbe2_app/pages/PretragaIspit.dart';
import 'package:vjezbe2_app/models/Proizvodi.dart';
import 'dart:convert';
import 'package:vjezbe2_app/pages/Login.dart';
import 'package:vjezbe2_app/pages/Loading.dart';
import 'package:vjezbe2_app/pages/Home.dart';
import 'package:vjezbe2_app/pages/Products.dart';
import 'package:vjezbe2_app/pages/ProductDetails.dart';
import 'package:vjezbe2_app/pages/Orders.dart';

void main() {
  runApp(MyApp());
}

class MyApp extends StatelessWidget {
  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      home: Login(),
      routes: {
        '/loading': (context) => Loading(),
        '/home': (context) => Home(),
        '/products': (context) => Products(),
        '/productdetails': (context) => ProductDetails(),
        '/orders': (context) => Orders(),
        '/pretrage': (context) => Pretrage()
      },
    );
  }
}
