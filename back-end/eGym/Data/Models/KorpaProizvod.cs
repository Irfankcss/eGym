using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    public class KorpaProizvod
    {
        public int KorpaProizvodID { get; set; }

        public int KorpaID { get; set; }
        public Korpa Korpa { get; set; }

        public int ProizvodID { get; set; }
        public Proizvod Proizvod { get; set; }
        public int Kolicina { get; set; }
    }
}
