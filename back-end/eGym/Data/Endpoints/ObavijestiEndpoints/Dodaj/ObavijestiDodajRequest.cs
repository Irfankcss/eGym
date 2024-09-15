namespace eGym.Data.Endpoints.Obavijesti.Dodaj
{
    public class ObavijestiDodajRequest
    {
        //public int ID { get; set; }
        public DateTime DatumObjave { get; set; }
        public string Naslov { get; set; }
        public string Text { get; set; }
        public string Slika { get; set; }
        public int? AdminID { get; set; }
    }
}
