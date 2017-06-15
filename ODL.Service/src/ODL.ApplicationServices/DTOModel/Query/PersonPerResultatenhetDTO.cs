using System.Collections.Generic;

namespace ODL.ApplicationServices.DTOModel.Query
{
    public class PersonPerResultatenhetDTO
    {
        public int Id { get; set; }
        public string Personnummer { get; set; }
        public string Fornamn { get; set; }
		public string Efternamn { get; set; }
		public string KostnadsstalleNr { get; set; }
        public bool Resultatenhetansvarig { get; set; }
        public string Anstallningsdatum { get; set; }
        public string Avgangsdatum { get; set; }
		public string Namn => $"{Fornamn} {Efternamn}";
	}
    
}