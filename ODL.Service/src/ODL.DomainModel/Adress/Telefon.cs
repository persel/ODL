namespace ODL.DomainModel.Adress
{
    public class Telefon
    {
        public Telefon(string telefonnummer)
        {
            Telefonnummer = telefonnummer;
        }

        public int AdressId { get; set; }
        public string Telefonnummer { get; set; }
        public virtual Adress Adress { get; set; }
    }
}
