using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("Admin")]
    public class Admin : KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string AdminKod { get; set; }
    }
}
