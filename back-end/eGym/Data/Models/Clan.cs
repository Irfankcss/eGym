using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("Clan")]
    public class Clan : Korisnik
    {
        public int BrojClana {  get; set; }
        [ForeignKey(nameof(Clanarina))]
        public int ClanarinaID { get; set; }
        public Clanarina Clanarina { get; set; }
    }
    
}
