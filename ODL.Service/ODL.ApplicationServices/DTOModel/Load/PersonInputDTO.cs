

namespace ODL.ApplicationServices.DTOModel.Load
{
    public class PersonInputDTO : InputDTO
    {
        public string Personnummer { get; set; }

        public string Namn { get; set; }

        public string Fornamn { get; set; }

        public string Mellannamn { get; set; }

        public string Efternamn { get; set; }

        public string Alias { get; set; }

        public bool IsKonsult { get; set; }

        public bool IsAnstalld { get; set; }
        
    }
}