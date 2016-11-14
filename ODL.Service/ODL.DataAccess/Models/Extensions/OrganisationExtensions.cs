using System;
using System.Collections.Generic;
using System.Linq;
using ODL.DataAccess.Models.Organisation;

namespace ODL.DataAccess.Models.Extensions
{
    public static class OrganisationExtensions
    {
        public static IList<Organisation.Organisation> AllaRelaterade(this Organisation.Organisation organisation)
        {
            return organisation.Root().Flatten().ToList();
        }
        public static Organisation.Organisation Root(this Organisation.Organisation organisation)
        {
            while (organisation.Overordnad != null)
                organisation = organisation.Overordnad;

            return organisation;
        }
        public static IEnumerable<Organisation.Organisation> Flatten(this Organisation.Organisation organisation)
        {
            yield return organisation;
            foreach (var node in organisation.Underliggande.SelectMany(n => n.Flatten()))
                yield return node;
        }
    }
}
