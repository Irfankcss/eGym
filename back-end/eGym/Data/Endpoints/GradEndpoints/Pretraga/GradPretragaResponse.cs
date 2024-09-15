namespace eGym.Data.Endpoints.Grad.Pretraga
{
    public class GradPretragaResponse
    {
        public List<GradPretragaResponseGrad> Gradovi { get; set; }
        public class GradPretragaResponseGrad
        {
            public int ID { get; set; }
            public string Naziv { get; set; }
            public string PostanskiBroj { get; set; }
            public string Drzava { get; set; }
        }
    }
}
