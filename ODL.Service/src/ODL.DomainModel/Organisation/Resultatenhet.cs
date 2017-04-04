
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Organisation
{
        
    // Troligen �r Organisation en b�ttre Aggregate root �n Resultatenhet eftersom Resultatenhet alltid har en Organisation, medan Organisation inte alltid har Resultatenhet...

    public partial class Resultatenhet
    {
        public int OrganisationId { get; set; }

        public int KstNr { get; set; }

        public string Typ { get; set; }

        public Metadata Metadata { get; set; }

        public virtual Organisation Organisation { get; set; }

        public bool IsNew => OrganisationId == default(int);
    }
}
