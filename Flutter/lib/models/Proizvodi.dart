import 'dart:convert';

class Proizvodi {
    final int proizvodId;
    final String naziv;
    final String cijena;
    final List<int> slika;

    Proizvodi({
        this.proizvodId,
        this.naziv,
        this.cijena,
        this.slika
    });

    factory Proizvodi.fromJson(Map<String, dynamic> json){
        String stringByte = json["slika"] as String;
        List<int>bytes=base64.decode(stringByte);
        return Proizvodi(
            proizvodId:int.parse(json["proizvodId"].toString()),
            naziv: json["naziv"],
            cijena: json["cijena"].toString(),
            slika: bytes
        );
    }

    Map<String, dynamic> toJson() => {
        "proizvodId": proizvodId,
        "naziv": naziv,
        "cijena": cijena,
        "slika": slika
    };
}
