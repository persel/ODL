
using System.Collections.Generic;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Repositories
{
    public interface IAdressVariantRepository
    {
        void Update();

        void Add(AdressVariant nyAdressVariant);

        AdressVariant GetVariantByVariantName(string adressVariant);
    }
}
