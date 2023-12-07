using eGym.Data.Models;

namespace eGym.Data.Controllers.NarudzbaProizvodC
{
    public class DodajNarudzbuRequest
    {
        public DateTime DatumNarudzbe { get; set; }
        public List<int> ProizvodIDs { get; set; }
        public int KorisnikID { get; set; }
        public double? Popust { get;set; }
        public double vrijednost { get; set; }
        public string NacinPlacanja { get; set; }
    }
}
