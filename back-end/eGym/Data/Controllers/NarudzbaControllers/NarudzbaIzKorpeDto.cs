using System.ComponentModel.DataAnnotations.Schema;

namespace eGym.Data.Controllers.NarudzbaC
{
    public class CreateNarudzbaDto
    {
        public string NacinPlacanja { get; set; }
        public double? Popust { get; set; }
        public string NacinDostave { get; set; } = "regular";
        public string ImePrimaoca { get; set; }
        public string PrezimePrimaoca { get; set; }
        public int GradID { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
    }
}
