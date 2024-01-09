using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Controllers.Korisnik.Dodaj
{
    public class KorisnikDodajRequest
    {
        //public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public int? OpstinaRodjenjaID{ get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojTelefona { get; set; }
        public string Spol { get; set; }
        public string Email {  get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka {  get; set; }
    }
}
