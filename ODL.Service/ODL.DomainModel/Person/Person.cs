using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ODL.DomainModel.Common;

namespace ODL.DomainModel.Person
{

    [Table("Person.Person")]
    public partial class Person
    {

        public Person()
        {
            AnstallningsAvtal = new HashSet<AnstallningsAvtal>();
            KonsultAvtal = new HashSet<KonsultAvtal>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string KallsystemId { get; set; }

        [Required]
        [StringLength(255)]
        public string Fornamn { get; set; }

        [StringLength(255)]
        public string Mellannamn { get; set; }

        [Required]
        [StringLength(255)]
        public string Efternamn { get; set; }

        [Required]
        [StringLength(12)]
        public string Personnummer { get; set; }

        public Metadata Metadata { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnstallningsAvtal> AnstallningsAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> AnstallningsAvtalIdn => AnstallningsAvtal.Select(anstallningsAvtal => anstallningsAvtal.AvtalFKId);

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KonsultAvtal> KonsultAvtal { get; set; }

        [NotMapped]
        public IEnumerable<int> KonsultAvtalIdn => KonsultAvtal.Select(konsultAvtal => konsultAvtal.AvtalFKId);

        [NotMapped]
        public bool IsNew => Id == 0;

        public bool IsAnstalld()
        {
            return AnstallningsAvtal.Any();
        }

        public bool IsKonsult()
        {
            return KonsultAvtal.Any();
        }

        public IEnumerable<int> AllaAvtalIdn()
        {
            if (IsAnstalld() && IsKonsult())
                return AnstallningsAvtalIdn.Concat(KonsultAvtalIdn);
            return IsAnstalld()
                ? AnstallningsAvtalIdn
                : (IsKonsult() ? KonsultAvtalIdn : new List<int>()); // Tar h�nsyn till om en person �r varken konsult eller anst�lld...
        }

        /// <summary>
        /// Personen �r kopplad till organisationen genom minst ett avtal 
        /// </summary>
        public bool KoppladTill(Organisation.Organisation organisation)
        {
            return AllaAvtalIdn().Intersect(organisation.AllaAvtalIdn).Any();
        }

    }
}
