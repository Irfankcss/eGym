namespace eGym.Data.Endpoints.BrendEndpoints.GetAll
{

        public class BrendGetAllResponse
        {
            public List<BrendGetAllResponseBrend> Brendovi { get; set; }
        }
        public class BrendGetAllResponseBrend
        {
            public int BrendID { get; set; }
            public string Naziv { get; set; }
        }
    
}

