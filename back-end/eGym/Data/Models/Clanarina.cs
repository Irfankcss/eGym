using System.ComponentModel.DataAnnotations;

namespace eGym.Data.Models
{
    public class Clanarina
    {
        [Key]
        public int ID { get; set; }
        public DateTime DatumUplate { get; set; }
        public DateTime DatumIsteka {  get; set; }
    }
}
