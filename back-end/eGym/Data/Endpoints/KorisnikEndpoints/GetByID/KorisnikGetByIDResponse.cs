namespace eGym.Data.Endpoints.Korisnik.GetByID
{
    public class KorisnikGetByIDResponse
    {
        public int id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Spol { get; set; }
        public int? OpstinaID { get; set; }
        public DateTime DatumRodjenja { get; set; }
    }
}
