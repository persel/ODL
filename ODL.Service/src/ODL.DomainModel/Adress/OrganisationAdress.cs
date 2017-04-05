namespace ODL.DomainModel.Adress
{
    public class OrganisationAdress
    {     
        public int AdressId { get; set; }
        public int OrganisationId { get; set; }
        public virtual Adress Adress { get; set; }
    }
}
