namespace eGym.Data.Controllers.Obavijesti.Update
{
    public class ObavijestiUpdateRequest
    {
        public int ID { get; set; }
        public string Naslov { get; set; }
        public string Sadrzaj { get; set; }
        public string Slika { get; set; } 
    }
}
