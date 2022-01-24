import 'package:flutter/material.dart';
import 'package:vjezbe2_app/models/Proizvodi.dart';
import 'package:vjezbe2_app/services/APIService.dart';

class Home extends StatefulWidget {
  @override
  _HomeState createState() => _HomeState();
}

class _HomeState extends State<Home> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Sidemenu'),
        backgroundColor: Colors.amber[700],
      ),
      drawer: Drawer(
        child: ListView(
          children: [
            DrawerHeader(child: Center(child: Text('eProdaja', style: TextStyle(fontSize: 20, color: Colors.white),)),
            decoration: BoxDecoration(
              color: Colors.amber[700]
            ),
            ),
            ListTile(
              title: Text('Proizvodi'),
              onTap: () {
                    Navigator.of(context).pushNamed('/products');
              },
            ),
            ListTile(
              title: Text('Moja korpa'),
              onTap: () {
                Navigator.of(context).pushNamed('/orders');
              },
            )
          ],
        ),
      ),
    );
  }
}
