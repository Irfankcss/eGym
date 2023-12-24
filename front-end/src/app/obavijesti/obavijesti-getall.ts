export interface ObavijestiGetall{
  obavijesti: Obavijesti[]
}
export interface Obavijesti {
  id: number
  datumObjave: string
  naslov: string
  text: string
  slika: string
  admin: string
}
