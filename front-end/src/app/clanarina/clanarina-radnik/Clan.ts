export interface Clan {
  clanovi: Clanovi[]
}

export interface Clanovi {
  id: number
  ime: string
  prezime: string
  vrstaMjesecne: string
  brojClana: number
  datumUplate: string
  datumIsteka: string
}
