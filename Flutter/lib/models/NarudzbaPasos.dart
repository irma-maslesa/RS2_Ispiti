import 'dart:convert';

class NarudzbaPasos {
  final int narudzbaId;
  final String brojNarudzbe;
  final DateTime datum;
  final double cijena;
  final bool vazeciPasos;

  NarudzbaPasos(
      {this.narudzbaId,
      this.brojNarudzbe,
      this.datum,
      this.cijena,
      this.vazeciPasos});

  factory NarudzbaPasos.fromJson(Map<String, dynamic> json) {
    return NarudzbaPasos(
        narudzbaId: int.parse(json["narudzbaId"].toString()),
        brojNarudzbe: json["brojNarudzbe"],
        datum: DateTime.parse(json['datum'].toString()),
        cijena: json["cijena"] as double,
        vazeciPasos: json["vazeciPasos"] as bool);
  }

  Map<String, dynamic> toJson() => {
        "narudzbaId": narudzbaId,
        "brojNarudzbe": brojNarudzbe,
        "datum": datum,
        "cijena": cijena,
        "vazeciPasos": vazeciPasos
      };
}
