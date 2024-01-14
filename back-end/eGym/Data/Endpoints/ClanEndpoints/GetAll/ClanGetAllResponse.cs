using eGym.Data.Models;

namespace eGym.Data.Endpoints.ClanEndpoints.GetAll
{
    public class ClanGetAllResponse
    {
        public int ClanID { get; set; }
        public int BrojClana {  get; set; }
        public int KorisnikID { get; set; }
        public int ClanarinaID { get; set; }
        public Korisnik Korisnik { get; set; }
    }
}
