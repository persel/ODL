namespace ODL.DomainModel.Adress
{
    public partial class Telefon
    {
        public int AdressId { get; set; }

        public string Telefonnummer { get; set; }
       
        public virtual Adress Adress { get; set; }
    }
}
