
using ODL.DomainModel.Common;
using System.Collections.Generic;
using System.Linq;

namespace ODL.DomainModel.Organisation
{
    public class Organisation
    {
       
        protected Organisation()
        {
            Underliggande = new HashSet<Organisation>();
        }

        private Organisation(string organisationsId, string namn, Resultatenhet resultatenhet, Metadata metadata)
        {
            OrganisationsId = organisationsId;
            Namn = namn;
            Resultatenhet = resultatenhet;
            Metadata = metadata;
        }

        public static Organisation SkapaNyResultatenhet()
        {
            var organisation = new Organisation {Resultatenhet = new Resultatenhet()};
            return organisation;
        }

        public static Organisation SkapaNyResultatenhet(string kstNr, string typ, string organisationsId, string namn, Metadata metadata)
        {
            var resultatenhet = new Resultatenhet(kstNr, typ);
            var organisation = new Organisation(organisationsId, namn, resultatenhet, metadata);

            return organisation;
        }

        public int Id { get; private set; }

        public string OrganisationsId { get; private set; }

        public string Namn { get; private set; }

        public int? IngarIOrganisationId { get; private set; }

        public Metadata Metadata { get; private set; }

        public virtual ICollection<Organisation> Underliggande { get; private set; }

        public virtual Organisation Overordnad { get; private set; }
        
        public virtual Resultatenhet Resultatenhet { get; private set; }

        public bool Ny => Id == default(int);

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

        public void BytNamn(string namn, Metadata metadata)
        {
            Namn = namn;
            Metadata = Metadata;
        }
    }
}
