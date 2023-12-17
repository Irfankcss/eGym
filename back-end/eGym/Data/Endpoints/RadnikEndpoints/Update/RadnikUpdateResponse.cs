using eGym.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Endpoints.RadnikEndpoints.Update
{
    public class RadnikUpdateResponse
    {
            public int RadnikID { get; set; }
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public DateTime DatumRodjenja { get; set; }
            public string BrojTelefona { get; set; }
            DateTime DatumZaposlenja { get; set; }
            int GradID { get; set; }

            public Grad grad { get; set; }
    
    }
}
