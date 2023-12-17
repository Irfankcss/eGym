using eGym.Data.Models;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.Dodaj
{
    public class PoslanaNarudzbaDodajRequest
    {
        public DateTime DatumSlanja { get; set; }
        public int RadnikID { get; set; }
        public int NarudzbaID { get; set; }
    }
}
