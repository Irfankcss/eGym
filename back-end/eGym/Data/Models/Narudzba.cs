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
        public DateTime DatumKreiranja { get; set; }
        public bool isOdobrena { get; set; }
        public double Vrijednost { get; set; }
        public double? Popust { get; set; }
        public bool isPoslana { get; set; } = false;
        [ForeignKey(nameof(korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik korisnik { get; set; }
        [JsonIgnore]
        public List<NarudzbaProizvod> Proizvodi { get; set; }
        public string NacinPlacanja { get; set; }
        public string NacinDostave { get; set; }
        public string? ImePrimaoca { get; set; }
        public string? PrezimePrimaoca { get; set; }
        [ForeignKey(nameof(Grad))]
        public int GradID { get; set; }
        public Grad Grad { get; set; }
        public string? Adresa { get; set; }
        public string Telefon {  get; set; }
        public string Email { get; set; }

    }
}
