class VrsteProizvoda{
  int vrstaId;
  String naziv;

  VrsteProizvoda({
    this.vrstaId,
    this.naziv,
  });

  factory VrsteProizvoda.fromJson(Map<String, dynamic> json){
    return VrsteProizvoda(
        vrstaId:int.parse(json["vrstaId"].toString()),
        naziv: json["naziv"],
    );
  }

  Map<String, dynamic> toJson() => {
    "vrstaId": vrstaId,
    "naziv": naziv,
  };
}