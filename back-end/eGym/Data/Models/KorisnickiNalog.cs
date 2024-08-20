using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Models
{
    public class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string? Slika { get; set; }
        public bool isAdmin { get; set; }
        public bool isKorisnik { get; set;}
        public bool isRadnik { get; set; }
        public bool isClan { get; set; }
    }
}
