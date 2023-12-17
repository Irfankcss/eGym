namespace eGym.Data.Controllers.Kreditna_kartica.Pretrazi
{
    public class KreditnaKarticaPretraziResponse
    {
        public List<KreditnaKarticaPretraziResponseKreditnaKartica> kartice {  get; set; }
    }
    public class KreditnaKarticaPretraziResponseKreditnaKartica
    {
        public string BrojKartice { get; set; }
        public DateTime DatumIsteka {  get; set; }
        public int SigurnosniBroj { get; set; }
        public string TipKartice { get; set; }
        public int KorisnikID {  get; set; }
    }
}
