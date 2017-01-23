using System.Collections.Generic;
using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class AdressDTO
    {
        public int Id { get; set; }
        public int AdressVariantFKId { get; set; }
        public virtual GatuAdressDTO GatuAdress { get; set; }
        public virtual MailDTO Mail { get; set; }
        public virtual TelefonDTO Telefon { get; set; }

    }
    
}