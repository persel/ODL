
namespace ODL.DomainModel.Organisation
{
        
    // Troligen �r Organisation en b�ttre Aggregate root �n Resultatenhet eftersom Resultatenhet alltid har en Organisation, medan Organisation inte alltid har Resultatenhet...

    public class Resultatenhet
    {
        public int OrganisationId { get; set; }

        public string KstNr { get; set; }

        public string Typ { get; set; }

        public virtual Organisation Organisation { get; set; }

        public bool IsNew => OrganisationId == default(int);
    }
}
