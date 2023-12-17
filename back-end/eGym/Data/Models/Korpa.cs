using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eGym.Data.Models
{
    [Table("Korpa")]
    public class Korpa
    {
        public int KorpaID { get; set; }
        [JsonIgnore]
        public List<KorpaProizvod> Proizvodi { get; set; } = new List<KorpaProizvod>();  

        [ForeignKey(nameof(korisnik))]
        public int KorisnikID {  get; set; }
        public Korisnik korisnik { get; set; }
        public double Vrijednost { get; set; }
    }
}
