namespace eGym.Data.Controllers.Korisnicki_nalog.Pretraga
{
    public class KorisnickiNalogPretragaResponse
    {
        public List<KorisnickiNalogPretragaResponseKorisnickiNalog> KorisnickiNalozi { get; set; }
    }
    public class KorisnickiNalogPretragaResponseKorisnickiNalog
    {
        public int ID {  get; set; }
        public string KorisnickoIme { get; set; }
        public string Email { get; set; }
        public string Lozinka { get; set; }
        public string Slika { get; set; }
        public bool isAdmin { get; set; }
        public bool isKorisnik { get; set; }
        public bool isRadnik { get; set; }
    }
}
