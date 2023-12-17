namespace eGym.Data.Endpoints.KategorijaEndpoints.GetAll
{
    public class KategorijaGetResponse
    {
        public List<KategorijaGetResponseKategorija> Kategorije {  get; set; }
    }
    public class KategorijaGetResponseKategorija
    {
        public int KategorijaId {get;set;}
        public string Naziv { get;set;}
        public string Opis { get;set;}
    }
}
