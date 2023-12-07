using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("PoslanaNarudzba")]
    public class PoslanaNarudzba : Narudzba
    {
        public DateTime DatumSlanja { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public bool isPreuzeta { get; set; }
        public bool isIsporucena { get; set; }
        [ForeignKey(nameof(radnik))]
        public int RadnikID { get; set; }
        public Radnik radnik { get; set; }
    }
}
