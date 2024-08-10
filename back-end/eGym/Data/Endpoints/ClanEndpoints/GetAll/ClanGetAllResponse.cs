using eGym.Data.Models;

namespace eGym.Data.Endpoints.ClanEndpoints.GetAll
{
    public class ClanGetAllResponse
    {
        public List<ClanGetAllResponseClan> clanovi {  get; set; }
        public class ClanGetAllResponseClan
        {
            public int ID {  get; set; }
            public string Ime { get; set; }
            public string Prezime {  get; set; }
            public string VrstaMjesecne {  get; set; }
            public int BrojClana {  get; set; }
            public DateOnly DatumUplate {  get; set; }
            public DateOnly DatumIsteka { get; set; }
        }
    }
}
