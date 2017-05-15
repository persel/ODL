
namespace ODL.DomainModel.Organisation
{
        
    // Troligen är Organisation en bättre Aggregate root än Resultatenhet eftersom Resultatenhet alltid har en Organisation, medan Organisation inte alltid har Resultatenhet...

    public class Resultatenhet
    {
        public Resultatenhet()
        {
        }

        public Resultatenhet(string kstNr, string typ)
        {
            KstNr = kstNr;
            Typ = typ;
        }

        public int OrganisationId { get; private set; }

        public string KstNr { get; private set; }

        public string Typ { get; private set; }

        public virtual Organisation Organisation { get; private set; }

        public bool Ny => OrganisationId == default(int);
    }
}
