import 'dart:convert';

class PretragaIspit {
  final int korisnikId;
  final String korsinikImePrezime;

  final double minIznos;
  final double iznos;

  final int vrstaProizvodaId;

  final DateTime datumOd;
  final DateTime datumDo;

  final double prosjecanPromet;

  PretragaIspit({
    this.korisnikId,
    this.korsinikImePrezime,
    this.minIznos,
    this.iznos,
    this.vrstaProizvodaId,
    this.datumOd,
    this.datumDo,
    this.prosjecanPromet,
  });

  factory PretragaIspit.fromJson(Map<String, dynamic> json) {
    return PretragaIspit(
      korisnikId: int.parse(json["korisnikId"].toString()),
      korsinikImePrezime: json["korisnikImePrezime"],
      minIznos: double.tryParse(json['minIznos'].toString()),
      iznos: double.tryParse(json['iznos'].toString()),
      vrstaProizvodaId: json['vrstaProizvodaId'] as int,
      datumOd: DateTime.parse(json['datumOd']),
      datumDo: DateTime.parse(json['datumDo']),
      prosjecanPromet: json['prosjecanPromet'] as double,
    );
  }
}
