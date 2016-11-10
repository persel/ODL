using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ODL.DataAccess.Models.Extensions
{
    public static class OrganisationExtensions
    {
        public static IEnumerable<Organisation> Flatten(this Organisation organisation)
        {
            yield return organisation;
            foreach (var node in organisation.Underliggande.SelectMany(n => n.Flatten()))
                yield return node;
        }

        public static Organisation Root(this Organisation organisation)
        {
            while (organisation.Överordnad != null)
                organisation = organisation.Överordnad;

            return organisation;

        }

    }
}
