using System.Collections.Generic;
using System.Linq;

namespace ODL.DomainModel.Organisation
{

    // Extension methods används för implementation av logik i domain model, så att ev. omskapande av modellen via "EF database first" inte 
    // skriver över egenskriven kod i modellklasserna. Kan flyttas till resp. klass när vi inte längre genererar från databasen.

    public static class OrganisationExtensions
    {
        public static IList<Organisation> AllaRelaterade(this Organisation organisation)
        {
            return organisation.Root().Flatten().ToList();
        }
        public static Organisation Root(this Organisation organisation)
        {
            while (organisation.Overordnad != null)
                organisation = organisation.Overordnad;

            return organisation;
        }
        public static IEnumerable<Organisation> Flatten(this Organisation organisation)
        {
            yield return organisation;
            foreach (var node in organisation.Underliggande.SelectMany(n => n.Flatten()))
                yield return node;
        }
    }
}
