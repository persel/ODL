using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.ApplicationServices.Queries;
using ODL.ApplicationServices.Validation;
using ODL.DataAccess;
using ODL.DataAccess.Repositories;
using ODL.DomainModel;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IContext context;
        private readonly ILogger<PersonService> logger;

        public PersonService(IPersonRepository personRepository, IContext context, ILogger<PersonService> logger)
        {
            this.personRepository = personRepository;
            this.context = context;
            this.logger = logger;
        }

        public void SparaPerson(PersonInputDTO personInputDTO)
        {
            var valideringsfel = new PersonInputValidator().Validate(personInputDTO);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                    logger.LogError(fel.Message); 
                throw new BusinessLogicException($"Valideringsfel inträffade vid validering av Person med Id: {personInputDTO.Personnummer}.");
            }

            var person = personRepository.GetByPersonnummer(personInputDTO.Personnummer) ?? new Person(personInputDTO.Fornamn, personInputDTO.Mellannamn, personInputDTO.Efternamn, personInputDTO.Personnummer, personInputDTO.GetMetadata());

            if (person.Ny)
            {
                personRepository.Add(person);
            }
            else
            {
                person.AndraUppgifter(personInputDTO.Fornamn, personInputDTO.Mellannamn, personInputDTO.Efternamn, personInputDTO.Personnummer, personInputDTO.GetMetadata());
                personRepository.Update();
            }
        }

        public PersonDTO GetPersonByPersonnummer(string personnummer)
        {
            var person = personRepository.GetByPersonnummer(personnummer);
            return new PersonDTO
            {
                Id = person.Id,
                Namn = $" {person.Fornamn} {person.Efternamn}",
                Personnummer = person.Personnummer
            };
        }
        
        public IEnumerable<PersonPerResultatenhetDTO> GetPersonerPerResultatenhet(string kstNr)
        {
            return new PersonerPerResultatenhetQuery(context).Execute(kstNr);
        }
    }
}
