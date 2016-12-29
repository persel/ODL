
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Organisation
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Organisation.Organisation")]
    public partial class Organisation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Organisation()
        {
            Underliggande = new HashSet<Organisation>();
            OrganisationsAvtal = new HashSet<OrganisationsAvtal>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string OrganisationsId { get; set; }

        [StringLength(100)]
        public string Namn { get; set; }

        public int? IngarIOrganisationFKId { get; set; }

        public Metadata Metadata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Organisation> Underliggande { get; set; }

        public virtual Organisation Overordnad { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganisationsAvtal> OrganisationsAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> AllaAvtalIdn => OrganisationsAvtal.Select(orgAvtal => orgAvtal.AvtalFKId);

        public virtual Resultatenhet Resultatenhet { get; set; }

        public bool IsNew => Id == default(int);
    }
}
