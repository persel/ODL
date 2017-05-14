namespace ODL.DomainModel.Adress
{
    public class Mail
    {
        public Mail(string mailAdress)
        {
            MailAdress = mailAdress;
        }

        public int AdressId { get; set; }
        public string MailAdress { get; set; }
        public virtual Adress Adress { get; set; }
    }
}
