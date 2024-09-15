namespace eGym.Data.Endpoints.Obavijesti.Pretraga
{
    public class ObavijestiPretragaResponse
    {
        public List<ObavijestiPretragaResponseObavijest> Obavijesti { get; set; }
    }
    public class ObavijestiPretragaResponseObavijest
    {
        public int ID { get; set; }
        public DateTime DatumObjave { get; set; }
        public string Naslov { get; set; }
        public string Text { get; set; }
        public string Slika { get; set; }
        public string Admin { get; set; }
    }
}
