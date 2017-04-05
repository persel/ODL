
using ODL.DomainModel.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ODL.DomainModel.Organisation
{
  

    public partial class Organisation
    {
       
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

        public string OrganisationsId { get; set; }

        public string Namn { get; set; }

        public int? IngarIOrganisationId { get; set; }

        public Metadata Metadata { get; set; }

        public virtual ICollection<Organisation> Underliggande { get; set; }

        public virtual Organisation Overordnad { get; set; }

        public virtual ICollection<OrganisationAvtal> OrganisationsAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> AllaAvtalIdn => OrganisationsAvtal.Select(orgAvtal => orgAvtal.AvtalId);

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
