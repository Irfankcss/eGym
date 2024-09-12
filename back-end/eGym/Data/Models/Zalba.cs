using eGym.Data.Controllers.Korisnik.GetByID;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace eGym.Data.Models
{
    public class Zalba
    {
        public int ID {  get; set; }
        public string Tekst { get; set; }
        public byte[] Slika { get; set; }

        [ForeignKey(nameof(korisnik))]
        public int KorisnikID { get; set; }
        public Korisnik korisnik { get; set; }

    }
}
