class NarudzbaStavke{
  int narudzbaStavkaID;
  int narudzbaID;
  int proizvodID;
  int kolicina;

  NarudzbaStavke({this.narudzbaStavkaID, this.narudzbaID, this.proizvodID, this.kolicina});

  factory NarudzbaStavke.fromJson(Map<String, dynamic> json){
    return NarudzbaStavke(
      narudzbaStavkaID:int.parse(json["narudzbaStavkaID"].toString()),
      narudzbaID: int.parse(json["narudzbaID"].toString()),
      proizvodID: int.parse(json["proizvodID"].toString()),
      kolicina: json["kolicina"],
    );
  }

  Map<String, dynamic> toJson() => {
    "narudzbaStavkaID": narudzbaStavkaID,
    "narudzbaID": narudzbaID,
    "proizvodID": proizvodID,
    "kolicina": kolicina,
  };
}