using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("Korisnik")]
    public class Korisnik : KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public bool isClan { get; set; }
        [ForeignKey(nameof(OpstinaRodjenja))]
        public int OpstinaRodjenjaID { get; set; }
        public Grad OpstinaRodjenja {  get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojTelefona { get; set; }
        public string Spol {  get; set; }

    }
}
