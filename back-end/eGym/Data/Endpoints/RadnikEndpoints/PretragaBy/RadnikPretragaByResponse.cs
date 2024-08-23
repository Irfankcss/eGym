namespace eGym.Data.Endpoints.RadnikEndpoints.PretragaBy
{
    public class RadnikPretragaByResponse
    {
        public List<RadnikPretragaByResponseRadnik> Radnik { get; set; }
       
        public class RadnikPretragaByResponseRadnik
        {
            public string Ime { get; set; }
            public string Prezime { get; set; }
            public DateOnly DatumZaposlenja { get; set; }
            public string Spol { get; set; }
        }
    }
}
