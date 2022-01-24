import 'dart:convert';

class Narudzbe{
  int narudzbaId;
  String brojNarudzbe;
  int kupacID;
  DateTime datum;
  bool status;
  bool otkazano;

  Narudzbe({this.narudzbaId,this.brojNarudzbe, this.kupacID, this.datum, this.status, this.otkazano});

  factory Narudzbe.fromJson(Map<String, dynamic> json){
    return Narudzbe(
        narudzbaId:int.parse(json["narudzbaId"].toString()),
        brojNarudzbe: json["brojNarudzbe"].toString(),
        kupacID: json["kupacID"],
        datum: json["datum"],
        status: json["status"],
        otkazano: json["otkazano"],
    );
  }

  Map<String, dynamic> toJson() => {
    "narudzbaId": narudzbaId,
    "brojNarudzbe": brojNarudzbe,
    "kupacID": kupacID,
    "datum": datum,
    "status": status,
    "otkazano": otkazano
  };
}