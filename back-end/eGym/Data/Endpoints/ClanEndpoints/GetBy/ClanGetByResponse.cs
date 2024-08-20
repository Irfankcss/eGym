using Microsoft.Identity.Client;

namespace eGym.Data.Endpoints.ClanEndpoints.GetBy
{
    public class ClanGetByResponse
    {
        public List<ClanGetByResponseClan> Clanovi { get; set; }

        public class ClanGetByResponseClan
        {
            public string Ime {  get; set; }
            public string Prezime { get; set; }
            public string Vrsta { get; set; }
            public int BrojClana { get; set; }
            public DateOnly DatumUplate {  get; set; }
            public DateOnly DatumIsteka {  get; set; }
        }
    }
}
