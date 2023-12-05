using System.ComponentModel.DataAnnotations;

namespace eGym.Data.Models
{
    public class KorisnickiNalog
    {
        [Key]
        public int ID { get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public byte[] Slika { get; set; }
        public bool isAdmin { get; set; }
        public bool isKorisnik { get; set;}
        public bool isRadnik { get; set; }
    }
}
