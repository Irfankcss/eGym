namespace eGym.Data.Controllers.Clanarina.Pretrazi
{
    public class ClanarinaPretraziResponse
    {
        public List<ClanarinaPretraziResponseClanarina> Clanarina {  get; set; }
    }
    public class ClanarinaPretraziResponseClanarina
    {
        public int ClanarinaID { get; set; }
        public DateTime DatumUplate { get; set; }
        public DateTime DatumIsteka { get; set; }
    }
}
