using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{

    public class Person
    {

        public int Id { get; set; }
        public string KallsystemId { get; set; }

        public string Fornamn { get; set; }

        public string Mellannamn { get; set; }

        public string Efternamn { get; set; }

        public string Personnummer { get; set; }

        public Metadata Metadata { get; set; }
        
        public bool IsNew => Id == 0;

    }
}
