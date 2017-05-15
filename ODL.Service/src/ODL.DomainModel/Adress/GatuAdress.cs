namespace ODL.DomainModel.Adress
{
    public class Gatuadress
    {

        public Gatuadress()
        {
                
        }
        public Gatuadress(string adressRad1, string postnummer, string stad, string land)
        {
            AdressRad1 = adressRad1;
            Postnummer = postnummer;
            Stad = stad;
            Land = land;
        }

        public int AdressId { get; private set; }
        public string AdressRad1 { get; internal set; }
        public string AdressRad2 { get; internal set; }
        public string AdressRad3 { get; internal set; }
        public string AdressRad4 { get; internal set; }
        public string AdressRad5 { get; internal set; }
        public string Postnummer { get; internal set; }
        public string Stad { get; internal set; }
        public string Land { get; internal set; }
        public virtual Adress Adress { get;}
    }
}
