using eGym.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eGym.Data.ViewModels.ProizvodVMs
{
    public class IzdvojeniProizvodiGetVM
    {
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public string Slika { get; set; }
        public double? popust { get; set; }
    }
}
