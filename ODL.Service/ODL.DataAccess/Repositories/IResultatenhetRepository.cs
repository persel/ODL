
using System.Collections.Generic;

using ODL.DomainModel.Organisation;

namespace ODL.DataAccess.Repositories
{
    public interface IResultatenhetRepository
    {

        Resultatenhet GetById(int id);

        Resultatenhet GetResultatenhetByKstnr(int kstnr);

        /// <summary>
        /// Hämta alla Resultatenheter på dessa avtal.
        /// </summary>
        IList<Resultatenhet> GetByAvtalIdn(IEnumerable<int> avtalIdn);

        IList<Resultatenhet> GetAll();

        void Update();

        void Add(Resultatenhet resultatenhet);

    }
}
