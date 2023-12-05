using System.ComponentModel.DataAnnotations;

namespace eGym.Data.Models
{
    public class Clan
    {
        [Key]
        public int ID { get; set; }
        public int BrojClana {  get; set; }
    }
}
