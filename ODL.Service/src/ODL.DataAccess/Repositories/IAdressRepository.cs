using System.Collections.Generic;
using ODL.DomainModel.Adress;

namespace ODL.DataAccess.Repositories
{
    public interface IAdressRepository
    {
        void Add(Adress nyAdress);

        void Update();

        Adress GetByAdressId(int adressId);
        IEnumerable<Adress> GetAdresserPerPersonId(int personId);

        IEnumerable<Adress> GetAdresserPerOrganisationsId(int organisationsId);

        IEnumerable<Adress> GetAdresserPerPersonummer(string personnummer);

        Adress GetAdressPerPersonIdAndAdressvariant(int personId, Adressvariant variant);
        
        Adress GetAdressPerOrganisationsIdAndAdressvariant(int organisationsId, Adressvariant variant);
    }
}