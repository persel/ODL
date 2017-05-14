namespace ODL.DomainModel.Adress
{
    public class Gatuadress
    {
        public Gatuadress(string adressRad1, string postnummer, string stad, string land)
        {
            AdressRad1 = adressRad1;
            Postnummer = postnummer;
            Stad = stad;
            Land = land;
        }

        public int AdressId { get;}
        public string AdressRad1 { get; set; }
        public string AdressRad2 { get;}
        public string AdressRad3 { get;}
        public string AdressRad4 { get;}
        public string AdressRad5 { get;}
        public string Postnummer { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public virtual Adress Adress { get;}
    }
}
