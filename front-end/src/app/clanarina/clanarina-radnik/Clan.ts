export interface Clan {
  clanovi: Clanovi[]
}

export interface Clanovi {
  id: number
  ime: string
  prezime: string
  vrstaMjesecne: string
  brojClana: number
  clanarinaID:number
  datumUplate: string
  datumIsteka: string
  korisnikID: number
}
