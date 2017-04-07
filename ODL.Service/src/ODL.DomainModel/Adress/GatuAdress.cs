namespace ODL.DomainModel.Adress
{
    public class GatuAdress
    {       
        public int AdressId { get; set; }
        public string AdressRad1 { get; set; }
        public string AdressRad2 { get; set; }
        public string AdressRad3 { get; set; }
        public string AdressRad4 { get; set; }
        public string AdressRad5 { get; set; }
        public string Postnummer { get; set; }
        public string Stad { get; set; }
        public string Land { get; set; }
        public virtual Adress Adress { get; set; }
    }
}
