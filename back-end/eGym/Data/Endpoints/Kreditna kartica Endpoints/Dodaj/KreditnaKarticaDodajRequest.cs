using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Controllers.Kreditna_kartica.Dodaj
{
    public class KreditnaKarticaDodajRequest
    {
        public string BrojKartice { get; set; }
        public DateTime DatumIsteka { get; set; }
        public int SigurnosniBroj { get; set; }
        public string TipKartice { get; set; }
        public int KorisnikID { get; set; }
    }
}
