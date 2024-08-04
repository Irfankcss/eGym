namespace eGym.Data.Endpoints.KategorijaEndpoints.GetAll
{
    public class KategorijaGetByIdResponse
    {
        public List<KategorijaGetResponseKategorija> Kategorije {  get; set; }
    }
    public class KategorijaGetByIdResponseKategorija
    {
        public int KategorijaId {get;set;}
        public string Naziv { get;set;}
        public string Opis { get;set;}
    }
}
