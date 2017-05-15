namespace ODL.DomainModel.Adress
{
    public class Telefon
    {
        public Telefon(string telefonnummer)
        {
            Telefonnummer = telefonnummer;
        }

        public int AdressId { get; private set; }
        public string Telefonnummer { get; internal set; }
        public virtual Adress Adress { get; set; }
    }
}
