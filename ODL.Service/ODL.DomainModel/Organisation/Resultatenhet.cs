
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Organisation
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    // Troligen är Organisation en bättre Aggregate root än Resultatenhet eftersom Resultatenhet alltid har en Organisation, medan Organisation inte alltid har Resultatenhet...

    [Table("Organisation.Resultatenhet")]
    public partial class Resultatenhet
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrganisationFKId { get; set; }

        public int KstNr { get; set; }

        [StringLength(10)]
        public string Typ { get; set; }

        public Metadata Metadata { get; set; }

        public virtual Organisation Organisation { get; set; }

        public bool IsNew => OrganisationFKId == default(int);
    }
}
