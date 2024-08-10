namespace eGym.Data.Endpoints.RadnikEndpoints.GetByID
{
    public class RadnikGetByResponse
    {
        public List<RadnikGetBy> radnici {  get; set; }

        public class RadnikGetBy
        {
            public string Ime { get; set; }
            public string Prezime {  get; set; }

            public DateOnly DatumZaposlenja {  get; set; }
            public string Spol {  get; set; }
        }
    }
}
