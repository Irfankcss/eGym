export interface ProizvodiGetAllResponseKategorija {
    id: number;
    nazivKategorije: string;
    opis: string;
}

export interface ProizvodiGetAllResponseBrend {
    brendId: number;
    nazivBrenda: string;
}

export interface ProizvodiGetAllResponseSlika {
    id: number;
    putanja: string;
}

export interface ProizvodiGetAllResponse {
    proizvodID: number;
    naziv: string;
    opis: string;
    cijena: number;
    kategorija: ProizvodiGetAllResponseKategorija;
    kolicinaNaSkladistu: number;
    boja: string;
    brend: ProizvodiGetAllResponseBrend;
    velicina: string;
    datumObjave: string;
    slike: ProizvodiGetAllResponseSlika[];
    popust: number;
    isIzdvojen: boolean;
}
