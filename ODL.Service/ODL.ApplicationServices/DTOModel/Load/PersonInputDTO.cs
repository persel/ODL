using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ODL.DomainModel.Common;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices.DTOModel.Load
{
    public class PersonInputDTO
    {
        public string SystemId { get; set; }
        public string Personnummer { get; set; }
        public string Namn { get; set; }
        public string Fornamn { get; set; }
        public string Mellannamn { get; set; }
        public string Efternamn { get; set; }
        public string Alias { get; set; }
        public string AnstalldTyp { get; set; }
        public bool IsKonsult { get; set; }
        public bool IsAnstalld { get; set; }
        public string UppdateradDatum { get; set; }
        public string UppdateradAv { get; set; }
        public string SkapadDatum { get; set; }
        public string SkapadAv { get; set; }
        
    }
}