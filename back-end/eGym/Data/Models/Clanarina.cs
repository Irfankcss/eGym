using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("Clanarina")]
    public class Clanarina
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumUplate { get; set; }
        public DateTime DatumIsteka {  get; set; }
    }
}
