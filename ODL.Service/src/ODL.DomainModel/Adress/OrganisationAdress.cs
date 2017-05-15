namespace ODL.DomainModel.Adress
{
    public class OrganisationAdress
    {     
        public int AdressId { get; private set; }
        public int OrganisationId { get; internal set; }
        public virtual Adress Adress { get; set; }
    }
}
