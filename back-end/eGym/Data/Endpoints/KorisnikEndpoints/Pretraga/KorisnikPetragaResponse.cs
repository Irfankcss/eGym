using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Endpoints.Korisnik.Pretraga
{
    public class KorisnikPetragaResponse
    {
        public List<KorisnikPetragaResponseKorisnik> Korisnici { get; set; }
    }
    public class KorisnikPetragaResponseKorisnik
    {
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool isClan { get; set; }
        //public string OpstinaRodjenja { get; set; }
        //public DateTime DatumRodjenja { get; set; }
        public string BrojTelefona { get; set; }
        public string Spol { get; set; }
    }
}
