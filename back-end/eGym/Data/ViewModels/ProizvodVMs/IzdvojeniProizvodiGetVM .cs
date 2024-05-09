using eGym.Data.Models;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eGym.Data.ViewModels.ProizvodVMs
{
    public class IzdvojeniProizvodiGetVM
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Opis { get; set; }
        public double Cijena { get; set; }
        public string Slika { get; set; }
        public double? popust { get; set; }
    }
}
