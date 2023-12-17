using eGym.Data.Models;

namespace eGym.Data.ViewModels.ProizvodVMs
{
    public class ProizvodUpdateVM
    {
        public string? Naziv { get; set; }
        public Kategorija? Kategorija { get; set; }
        public int? KategorijaID { get; set; }
        public string? Boja { get; set; }
        public double? Cijena { get; set; }
        public Brend? Brend { get; set; }
        public int? BrendID { get; set; }
        public DateTime? DatumObjave { get; set; }
        public bool? isIzdvojen { get; set; }
        public int? KolicinaNaSkladistu { get; set; }
        public string? Opis { get; set; }
        public double? popust { get; set; }
        public string? Velicina { get; set; }
        public List<Slika>? Slike { get; set; }
    }
}
