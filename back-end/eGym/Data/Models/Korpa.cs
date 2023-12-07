using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("Korpa")]
    public class Korpa
    {
        public int KorpaID { get; set; }
        public ICollection<Proizvod> Proizvodi { get; }= new List<Proizvod>();  

        [ForeignKey(nameof(korisnik))]
        public int KorisnikID {  get; set; }
        public Korisnik korisnik { get; set; }
        public double Vrijednost { get; set; }
    }
}
