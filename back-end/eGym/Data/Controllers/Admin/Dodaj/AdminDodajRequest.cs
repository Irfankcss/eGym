namespace eGym.Data.Controllers.Admin.Dodaj
{
    public class AdminDodajRequest
    {
        public int AdminID {  get; set; }
        public string AdminKod { get; set; }
        public string Email {  get; set; }
        public string Slika {  get; set; }
        public string KorisnickoIme {  get; set; }
        public string Lozinka {  get; set; }
    }
}
