using eGym.Data.Models;

namespace eGym.Data.Endpoints.RadnikEndpoints.GetAll
{
    public class RadnikGetAllResponse
    {
        public List<RadnikGetAllResponseRadnik> Radnici { get; set; }
    }

    public class RadnikGetAllResponseRadnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string Spol { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string BrojTelefona { get; set; }
        public int GradID {  get; set; }
        public Grad grad {  get; set; }
        public string KorisnickoIme { get; set; }
        public string Slika {  get; set; }
        public string Email {  get; set; }
    }
}
