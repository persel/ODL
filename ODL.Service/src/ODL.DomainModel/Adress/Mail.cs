namespace ODL.DomainModel.Adress
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Adress.Mail")]
    public partial class Mail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AdressFKId { get; set; }

        [Required]
        [StringLength(255)]
        public string MailAdress { get; set; }

        
        public virtual Adress Adress { get; set; }
    }
}
