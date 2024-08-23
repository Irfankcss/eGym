namespace eGym.Data.Endpoints.RadnikEndpoints.Dodaj
{
    public class RadnikDodajRequest
    {
        public string Ime {  get; set; }
        public string Prezime {  get; set; }
        public DateTime DatumRodjenja {  get; set; }
        public string BrojTelefona {  get; set; }
        public DateTime DatumZaposlenja {  get; set; }
        public int? GradID {  get; set; }
        public string Spol {  get; set; }
        public int KorisnikID {  get; set; }

    }
}
