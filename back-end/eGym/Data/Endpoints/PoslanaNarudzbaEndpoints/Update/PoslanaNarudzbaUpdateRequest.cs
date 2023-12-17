namespace eGym.Data.Endpoints.PoslanaNarudzbaEndpoints.Update
{
    public class PoslanaNarudzbaUpdateRequest
    {
        public int PoslanaNarudzbaID { get; set; }
        public DateTime? DatumIsporuke { get; set; }
        public DateTime? DatumPreuzimanja { get; set; }
        public bool? isIsporucena { get; set; }
        public bool? isPreuzeta { get; set; }
    }
}
