using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eGym.Data.Models
{
    [Table("Narudzba")]
    public class Narudzba
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumKreiranja {  get; set; }
        public bool isOdobrena { get; set; }
        public double Vrijednost {  get; set; }
        public double? Popust {  get; set; }
        public bool isPoslana { get; set; }=false;
        [ForeignKey(nameof(korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik korisnik { get; set; }
        [JsonIgnore]
        public List<NarudzbaProizvod> Proizvodi { get; set; }
        public string NacinPlacanja { get; set; }
    }
}
