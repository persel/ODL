using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices
{
    public interface IAdressService
    {
        void SparaPersonAdress(PersonAdressInputDTO personAdress);

        void SparaOrganisationAdress(OrganisationAdressInputDTO organisationAdress);
    }
}
