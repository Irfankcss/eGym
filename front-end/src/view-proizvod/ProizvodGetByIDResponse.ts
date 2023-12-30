export interface ProizvodGetByIDResponse {
    proizvodID: number;
    naziv: string;
    opis: string;
    cijena: number;
    kolicinaNaSkladistu: number;
    boja: string;
    brend: ProizvodGetByIDResponseBrend;
    velicina: string;
    datumObjave: string;
    slike: ProizvodGetByIDResponseSlika[];
    popust: number;
    isIzdvojen: boolean;
}

export interface ProizvodGetByIDResponseSlika {
  id: number;
  putanja: string;
}

export interface ProizvodGetByIDResponseBrend {
  brendId: number;
  nazivBrenda: string;
}
