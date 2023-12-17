using eGym.Data.Models;
using System.Collections.ObjectModel;

namespace eGym.Data.ViewModels.NarudzbaVMs
{
    public class DodajNarudzbuVM
    {
        public DateTime DatumNarudzbe { get; set; }
        public List<int> ProizvodIDs { get; set; }
        public int KorisnikID { get; set; }
        public double? Popust { get; set; }
        public double vrijednost { get; set; }
        public string NacinPlacanja { get; set; }
    }
}
