using ODL.DomainModel.Adress;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class MailDTO 
    {

        public static MailDTO FromMail(Mail mail)
        {
            if (mail == null)
                return null;

            var mailDTO = new MailDTO();
            mailDTO.MailAdress = mail.MailAdress;

            return mailDTO;
        }


        public string MailAdress { get; set; }
    }
}