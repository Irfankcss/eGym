using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("PoslanaNarudzba")]
    public class PoslanaNarudzba
    {
        [Key]
        public int PoslanaNarudzbaID { get; set; }
        public DateTime DatumSlanja { get; set; }
        public DateTime DatumIsporuke { get; set; } = DateTime.MinValue;
        public DateTime DatumPreuzimanja { get; set; } = DateTime.MinValue;
        public bool isPreuzeta { get; set; }
        public bool isIsporucena { get; set; }
        public Radnik Radnik { get; set; }
        [ForeignKey(nameof(Narudzba))]
        public int NarudzbaID { get; set; }
    }
}
