using eGym.Data.Models;

namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.GetAll
{
    public class PoslanaNarudzbaGetAllResponse
    {
        public int PoslanaNarudzbaID {  get; set; }
        public DateTime DatumSlanja { get; set; }
        public DateTime DatumIsporuke { get; set; }
        public DateTime DatumPreuzimanja { get; set; }

        public int NarudzbaID { get; set; }
        public bool isPreuzeta { get; set; }
        public bool isIsporucena { get; set; }
        public Radnik Radnik { get; set; }
    }
}
