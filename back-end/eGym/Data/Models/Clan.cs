using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    [Table("Clan")]
    public class Clan
    {
        [Key]
        public int ClanID { get; set; }
        public int BrojClana {  get; set; }
        public string Vrsta {  get; set; }
        [ForeignKey(nameof(Clanarina))]
        public int ClanarinaID { get; set; }
        public Clanarina Clanarina { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik Korisnik { get; set; }
    }
    
}
