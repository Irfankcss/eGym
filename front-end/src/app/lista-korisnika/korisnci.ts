export interface Korisnci {
  korisnickiNalozi: KorisnickiNalozi[]
}

export interface KorisnickiNalozi {
  id: number
  korisnickoIme: string
  email: string
  lozinka: string
  slika: string
  isAdmin: boolean
  isKorisnik: boolean
  isRadnik: boolean
}
