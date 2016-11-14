namespace ODL.DataAccess.Models.Person
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    [Table("Person.Anstalld")]
    public partial class Anstalld
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Anstalld()
        {
            AnstallningsAvtal = new HashSet<AnstallningsAvtal>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PersonFKId { get; set; }

        public byte? Typ { get; set; }

        [Required]
        [StringLength(10)]
        public string Alias { get; set; }

        public DateTime UppdateradDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string UppdateradAv { get; set; }

        public DateTime SkapadDatum { get; set; }

        [Required]
        [StringLength(10)]
        public string SkapadAv { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnstallningsAvtal> AnstallningsAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> AnstallningsAvtalIdn => AnstallningsAvtal.Select(anstallningsAvtal => anstallningsAvtal.AvtalFKId);
    }
}
