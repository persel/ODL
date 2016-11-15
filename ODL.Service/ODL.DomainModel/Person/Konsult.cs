namespace ODL.DomainModel.Person
{
    using Common;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Person.Konsult")]
    public partial class Konsult
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Konsult()
        {
            KonsultAvtal = new HashSet<KonsultAvtal>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonFKId { get; set; }

        [Required]
        [StringLength(10)]
        public string Alias { get; set; }
        public Metadata Metadata { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonsultAvtal> KonsultAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> KonsultAvtalIdn => KonsultAvtal.Select(konsultAvtal => konsultAvtal.AvtalFKId);
    }
}
