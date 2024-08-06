export interface LogiraniClan {
  clanovi: Clanovi[]
}

export interface Clanovi {
  ime: string
  prezime: string
  vrsta: string
  brojClana: number
  datumUplate: string
  datumIsteka: string
}
