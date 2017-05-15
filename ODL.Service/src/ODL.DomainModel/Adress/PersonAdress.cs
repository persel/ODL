namespace ODL.DomainModel.Adress
{
    public class PersonAdress
    {     
        public int AdressId { get; private set; }
        public int PersonId { get; internal set; }
        public virtual Adress Adress { get; set; }
    }
}
