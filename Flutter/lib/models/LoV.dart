import 'dart:convert';

class LoV {
  final int id;
  final String naziv;

  LoV({this.id, this.naziv});

  factory LoV.fromJson(Map<String, dynamic> json) {
    return LoV(
      id: int.parse(json["id"].toString()),
      naziv: json["naziv"],
    );
  }

  Map<String, dynamic> toJson() => {"id": id, "naziv": naziv};
}
