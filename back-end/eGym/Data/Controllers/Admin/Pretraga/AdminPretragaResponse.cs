namespace eGym.Data.Controllers.Admin.Pretraga
{
    public class AdminPretragaResponse
    {
        public List<AdminPretragaResponseAdmin> Admini {  get; set; }
    }
    public class AdminPretragaResponseAdmin
    {
        public int ID { get; set; }
        public string AdminKod {  get; set; }
    }
}
