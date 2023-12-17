using eGym.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eGym.Data.ViewModels.ProizvodVMs
{
    public class ProizvodGetVM
    {
        public int ProizvodID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public Kategorija Kategorija { get; set; }
        public int KolicinaNaSkladistu { get; set; }
        public string? Boja { get; set; }
        public Brend Brend { get; set; }
        public string? Velicina { get; set; }
        public DateTime DatumObjave { get; set; }
        public List<Slika> Slike { get; set; }
        public double? popust { get; set; }
        public bool isIzdvojen { get; set; } = false;
    }
}
