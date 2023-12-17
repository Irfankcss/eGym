using eGym.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Endpoints.RadnikEndpoints.Update
{
    public class RadnikUpdateRequest
    {
        public int RadnikID { get; set; }

        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string? BrojTelefona { get; set; }
        public DateTime? DatumZaposlenja { get; set; }
        public int? GradID { get; set; }
        public Grad? grad { get; set; }
        public string? Spol { get; set; }

        public string? Email { get; set; }
        public string? Slika { get; set; }
    }
}
