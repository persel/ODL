
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Organisation
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

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
    }
}
