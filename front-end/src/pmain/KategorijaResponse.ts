export interface KategorijeR {
  kategorije: Kategorije[]
}


export interface Kategorije {
  kategorijaId: number
  naziv: string
  opis: string
}

export interface KategorijaRequest{
  id: number
  nazivKategorije: string
  opis: string
}
