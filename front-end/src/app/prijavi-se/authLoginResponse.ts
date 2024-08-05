export interface AuthLoginResponse {
  autentifikacijaToken: AutentifikacijaToken
  isLogiran: boolean
}

export interface AutentifikacijaToken {
  id: number
  vrijednost: string
  korisnickiNalogId: number
  korisnickiNalog: KorisnickiNalog
  vrijemeEvidentiranja: string
  ipAdresa: string
}

export interface KorisnickiNalog {
  id: number
  korisnickoIme: string
  email: string
  lozinka: string
  slika: string
  isAdmin: boolean
  isKorisnik: boolean
  isRadnik: boolean
  isClan:boolean
}
