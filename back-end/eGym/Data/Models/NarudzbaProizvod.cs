using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    public class NarudzbaProizvod
    {
        [Key]
        public int NarudzbaProizvodID { get; set; }
        public int NarudzbaId { get; set; }
        public Narudzba Narudzba { get; set; }
        public int ProizvodId { get; set; }
        public Proizvod Proizvod { get; set; }
        public int Kolicina { get; set; }

    }
}
