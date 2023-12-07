using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [ForeignKey(nameof(korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik korisnik { get; set; }
        public ICollection<NarudzbaProizvod> NarudzbaProizvodi { get; set; }
        public string NacinPlacanja { get; set; }
    }
}
