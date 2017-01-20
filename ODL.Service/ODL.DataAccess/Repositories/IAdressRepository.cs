using System.Collections.Generic;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Person;

namespace ODL.DataAccess.Repositories
{
    public interface IAdressRepository
    {
        void Add(Adress nyAdress);

        void Update();

        Adress GetByAdressId(int adressId);
        IEnumerable<Adress> GetAdresserPerPersonId(int personId);

        Adress GetAdressPerPersonIdAndVariantId(int personId, int variantId);
    }
}