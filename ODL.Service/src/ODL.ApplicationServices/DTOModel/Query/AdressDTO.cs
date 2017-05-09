using System.Collections.Generic;
using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class AdressDTO
    {
        public int Id { get; set; }
        public virtual GatuadressDTO Gatuadress { get; set; }
        public virtual MailDTO Mail { get; set; }
        public virtual TelefonDTO Telefon { get; set; }

    }
}