import 'dart:convert';

class Komentar {
  final int id;
  final String komentar;
  final String kupacImePrezime;
  final String proizvodNaziv;
  final int brojRijeci;
  final DateTime datum;

  Komentar({
    this.id,
    this.komentar,
    this.kupacImePrezime,
    this.proizvodNaziv,
    this.brojRijeci,
    this.datum,
  });

  factory Komentar.fromJson(Map<String, dynamic> json) {
    return Komentar(
      id: json["id"] as int,
      komentar: json["komentar"] as String,
      kupacImePrezime: json["kupacImePrezime"] as String,
      proizvodNaziv: json["proizvodNaziv"] as String,
      brojRijeci: json["brojRijeci"] as int,
      datum: DateTime.parse(json["datum"] as String),
    );
  }
}
