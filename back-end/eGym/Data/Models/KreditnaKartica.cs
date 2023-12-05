using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    public class KreditnaKartica
    {
        [Key]
        public int ID { get; set; }
        public string BrojKartice { get; set; }
        public DateTime DatumIsteka { get; set; }
        public int SigurnosniBroj { get; set; }
        public string TipKartice { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
