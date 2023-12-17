using eGym.Data.Models;
using eGym.Data.ViewModels.ProizvodVMs;

namespace eGym.Data.ViewModels.NarudzbaVMs
{
    public class NarudzbaVM
    {
        public int Id { get; set; }
        public DateTime DatumKreiranja { get; set; }
        public bool isOdobrena { get; set; }
        public double Vrijednost { get; set; }
        public double? Popust { get; set; }
        public int KorisnikID { get; set; }
        public string NacinPlacanja { get; set; }

        public List<Proizvod> Proizvodi { get; set; }
    }
}
