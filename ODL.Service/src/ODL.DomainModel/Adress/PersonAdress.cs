namespace ODL.DomainModel.Adress
{
    public class PersonAdress
    {     
        public int AdressId { get; set; }
        public int PersonId { get; set; }
        public virtual Adress Adress { get; set; }
    }
}
