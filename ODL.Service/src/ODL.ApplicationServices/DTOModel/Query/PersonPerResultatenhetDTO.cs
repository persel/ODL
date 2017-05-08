using System.Collections.Generic;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class PersonPerResultatenhetDTO
    {
        public int Id { get; set; }
        public string Personnummer { get; set; }
        public string Namn { get; set; }
        public string KostnadsstalleNr { get; set; }
        public bool? Resultatenhetansvarig { get; set; }
    }
    
}