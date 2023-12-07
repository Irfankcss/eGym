using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    public class NarudzbaProizvod
    {
        public int NarudzbaProizvodID { get; set; }
        [ForeignKey(nameof(narudzba))]
        public int NarudzbaId { get; set; }
        public Narudzba narudzba { get; set; }
        [ForeignKey(nameof(proizvod))]
        public int ProizvodId { get; set; }
        public Proizvod proizvod { get; set; }

    }
}
