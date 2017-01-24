using System.Collections.Generic;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.DomainModel.Adress;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices
{
    public interface IAdressService
    {
        Adress GetByAdressId(int adressId);
        IEnumerable<AdressDTO> GetAdresserPerKostnadsstalleNr(int kstnr);
        IEnumerable<AdressDTO> GetAdresserPerPersonnummer(string personnummer);
        void SparaPersonAdress(PersonAdressInputDTO personAdress);
        void SparaOrganisationAdress(OrganisationAdressInputDTO organisationAdress);
    }
}
