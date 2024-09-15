export interface Proizvod {
  proizvodID: number;
  naziv: string;
  popust: number;
  cijena: number;
  kolicina: number;
  slikaProizvoda: string;
}

export interface KorpaResponse {
  korpaID: number;
  proizvodi: Proizvod[];
  vrijednost: number;
}
