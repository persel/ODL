namespace ODL.DomainModel.Adress
{
  
    public partial class Mail
    {       
        public int AdressId { get; set; }

        public string MailAdress { get; set; }
        
        public virtual Adress Adress { get; set; }
    }
}
