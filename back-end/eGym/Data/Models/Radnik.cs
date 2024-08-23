
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace eGym.Data.Models
{
    [Table("Radnik")]
    public class Radnik
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja {  get; set; }
        public string BrojTelefona {  get; set; }
        public DateTime DatumZaposlenja {  get; set; }
        [ForeignKey(nameof(grad))]
        public int? GradID {  get; set; }
        public Grad? grad { get; set; }
        public string Spol {  get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public KorisnickiNalog Korisnik { get; set; }

    }
}
