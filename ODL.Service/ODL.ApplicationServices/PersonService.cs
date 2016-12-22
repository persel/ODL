﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using ODL.ApplicationServices.DTOModel;
using ODL.ApplicationServices.DTOModel.Load;
using ODL.ApplicationServices.DTOModel.Query;
using ODL.ApplicationServices.Validation;
using ODL.DataAccess.Repositories;
using ODL.DomainModel.Organisation;
using ODL.DomainModel.Person;

namespace ODL.ApplicationServices
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        private readonly IResultatenhetRepository resultatenhetRepository;
        private readonly IAvtalRepository avtalRepository;
        private readonly ILogger<PersonService> logger;

        public PersonService(IPersonRepository personRepository, IResultatenhetRepository resultatenhetRepository, IAvtalRepository avtalRepository, ILogger<PersonService> logger)
        {
            this.personRepository = personRepository;
            this.resultatenhetRepository = resultatenhetRepository;
            this.avtalRepository = avtalRepository;
            this.logger = logger;
    }

        public List<PersonDTO> GetByResultatenhetId(int id)
        {
            var resultatenhet = resultatenhetRepository.GetById(id);

            var allaOrganisationer = resultatenhet.Organisation.AllaRelaterade();

            var allaAvtal = allaOrganisationer.SelectMany(org => org.OrganisationsAvtal);

            var allaAvtalId = allaAvtal.Select(avtal => avtal.AvtalFKId).ToArray();
            
            var allaPersoner = personRepository.GetByAvtalIdn(allaAvtalId);

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

        public void SparaAvtal(AvtalInputDTO avtalDTO)
        {

            var valideringsfel = new AvtalInputValidator().Validate(avtalDTO);

            if (valideringsfel.Any())
            {
                foreach (var fel in valideringsfel)
                        logger.LogError(fel.Message); // Hmm, borde vi logga detta med Info? 
                throw new ApplicationException($"Valideringsfel inträffade vid validering av Avtal med Id: {avtalDTO.SystemId}.");
            }

            var avtal = personRepository.GetByKallsystemId(avtalDTO.SystemId) ?? new Avtal();
            
            // TODO: Skapa DTOMapper-klass! (Automapper?)

            avtal.KallsystemId = avtalDTO.SystemId;
            avtal.Avtalskod = avtalDTO.Avtalskod;
            avtal.Avtalstext = avtalDTO.Avtalstext;
            avtal.ArbetstidVecka = avtalDTO.ArbetstidVecka;
            avtal.Befkod = avtalDTO.Befkod;
            avtal.BefText = avtalDTO.BefText;
            avtal.Aktiv = avtalDTO.Aktiv;
            avtal.Ansvarig = avtalDTO.Ansvarig;
            avtal.Chef = avtalDTO.Chef;
            avtal.TjledigFran = avtalDTO.TjledigFran.ToDateTime();
            avtal.TjledigTom = avtalDTO.TjledigTom.ToDateTime();
            avtal.Fproc = avtalDTO.Fproc;
            avtal.DeltidFranvaro = avtalDTO.DeltidFranvaro;
            avtal.FranvaroProcent = avtalDTO.FranvaroProcent;
            avtal.SjukP = avtalDTO.SjukP;
            avtal.GrundArbtidVecka = avtalDTO.GrundArbtidVecka;
            avtal.Lon = avtalDTO.TimLon;
            avtal.LonDatum = avtalDTO.LonDatum.ToDateTime();
            avtal.LoneTyp = avtalDTO.LoneTyp;
            avtal.LoneTillagg = avtalDTO.LoneTillagg;
            avtal.TimLon = avtalDTO.TimLon;
            avtal.Anstallningsdatum = avtalDTO.Anstallningsdatum.ToDateTime();
            avtal.Avgangsdatum = avtalDTO.Avgangsdatum.ToDateTime();
            avtal.Metadata = avtalDTO.GetMetadata();

            if(avtal.IsNew)
                avtalRepository.Add(avtal);
            else
                personRepository.Update();
        }

    }
}
