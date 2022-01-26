import 'package:flutter/material.dart';

class Korisnici {
  final int korisnikId;
  final String ime;
  final String prezime;

  Korisnici({this.korisnikId, this.ime, this.prezime});

  factory Korisnici.fromJson(Map<String, dynamic> json) {
    return Korisnici(
      korisnikId: int.parse(json["korisnikId"].toString()),
      ime: json["ime"],
      prezime: json["prezime"],
    );
  }
}
