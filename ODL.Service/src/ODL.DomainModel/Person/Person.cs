using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{

    public class Person
    {
        public Person()
        {
        }

        public Person(string fornamn, string mellannamn, string efternamn, string personnummer, Metadata metadata)
        {
            Fornamn = fornamn;
            Mellannamn = mellannamn;
            Efternamn = efternamn;
            Personnummer = personnummer;
            Metadata = metadata;
        }

        public int Id { get; private set; }

        public string Fornamn { get; private set; }

        public string Mellannamn { get; private set; }

        public string Efternamn { get; private set; }

        public string Personnummer { get; private set; }

        public Metadata Metadata { get; private set; }
        
        public bool Ny => Id == 0;

        public void AndraUppgifter(string fornamn, string mellannamn, string efternamn, string personnummer, Metadata metadata)
        {
            Fornamn = fornamn;
            Mellannamn = mellannamn;
            Efternamn = efternamn;
            Personnummer = personnummer;
            Metadata = metadata;
        }
    }
}
