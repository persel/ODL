
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
        protected Organisation()
        {
            Underliggande = new HashSet<Organisation>();
            OrganisationsAvtal = new HashSet<OrganisationAvtal>();
        }

        public static Organisation SkapaNyResultatenhet()
        {
            var org = new Organisation();
            org.Resultatenhet = new Resultatenhet();
            return org;
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
        public virtual ICollection<OrganisationAvtal> OrganisationsAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> AllaAvtalIdn => OrganisationsAvtal.Select(orgAvtal => orgAvtal.AvtalFKId);

        public virtual Resultatenhet Resultatenhet { get; set; }

        public bool IsNew => Id == default(int);

        public IList<Organisation> AllaRelaterade()
        {
            return Root().Flatten().ToList();
        }
        public Organisation Root()
        {
            var organisation = this;

            while (organisation.Overordnad != null)
                organisation = organisation.Overordnad;

            return organisation;
        }
        public IEnumerable<Organisation> Flatten()
        {
            var organisation = this;
            
            yield return organisation;
            foreach (var node in organisation.Underliggande.SelectMany(n => n.Flatten()))
                yield return node;
        }
    }
}
