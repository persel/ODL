using System.Collections.Generic;

namespace ODL.ApplicationServices.Models
{
    public class PersonDTO
    {
        public int Id { get; set; }
        public string Personnummer { get; set; }
        public string Namn { get; set; }
        public List<ResultatenhetDTO> Resultatenheter { get; set; }
    }
}