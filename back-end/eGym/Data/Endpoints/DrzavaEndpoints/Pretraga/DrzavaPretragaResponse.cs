namespace eGym.Data.Endpoints.Drzava.Pretraga
{
    public class DrzavaPretragaResponse
    {
        public List<DrzavaPretragaResponseDrzava> Drzave { get; set; }
    }
    public class DrzavaPretragaResponseDrzava
    {
        public int ID { get; set; }
        public string Naziv { get; set; }
        public string Skracenica { get; set; }
    }
}
