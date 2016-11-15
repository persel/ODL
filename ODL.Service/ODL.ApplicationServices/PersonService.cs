using System.Collections.Generic;
using System.Linq;
using ODL.ApplicationServices.DTOModel;
using ODL.DataAccess.Repositories;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices
{
    public class PersonService : IPersonService
    {

        private readonly IPersonRepository _personRepository;
        private readonly IResultatenhetRepository _resultatenhetRepository;

        public PersonService(IPersonRepository personRepository, IResultatenhetRepository resultatenhetRepository)
        {
            _personRepository = personRepository;
            _resultatenhetRepository = resultatenhetRepository;
        }

        public List<PersonDTO> GetByResultatenhetId(int id)
        {
            var resultatenhet = _resultatenhetRepository.GetById(id);

            var allaOrganisationer = resultatenhet.Organisation.AllaRelaterade();

            var allaAvtal = allaOrganisationer.SelectMany(org => org.OrganisationsAvtal);

            var allaAvtalId = allaAvtal.Select(avtal => avtal.AvtalFKId).ToArray();
            
            var allaPersoner = _personRepository.GetByAvtalIdn(allaAvtalId);

            var personDtos = new List<PersonDTO>();

            foreach (var person in allaPersoner)
            {
                var personDTO = new PersonDTO { Id = person.Id, Namn = $" {person.Fornamn} {person.Efternamn}", Personnummer = person.Personnummer, Resultatenheter = new List<ResultatenhetDTO>()};

                foreach (var organisation in allaOrganisationer)
                {
                    if(person.KoppladTill(organisation)) 
                        personDTO.Resultatenheter.Add(new ResultatenhetDTO {Id = organisation.Id, KostnadsstalleNr = organisation.Resultatenhet.KstNr, Namn = organisation.Namn, Typ = organisation.Resultatenhet.Typ});
                }
                personDtos.Add(personDTO);
            }

            return personDtos;
        }
    }
}
