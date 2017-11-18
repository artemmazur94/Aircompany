using System;
using System.Collections.Generic;
using Aircompany.DataAccess.Entities;

namespace Aircompany.Services.Services.Contracts
{
    public interface IPersonService : IDisposable
    {
        void Commit();

        List<Person> GetAllPersons();

        Person GetPerson(int id);

        List<PersonLocalization> GetAllPersonLocalizations(int languageId);

        List<MovieLocalization> GetMovieLocalizations(List<int> movieIds, int languageId);

        void AddPersonLocalization(PersonLocalization personLocalization);

        PersonLocalization GetPersonLocalization(int id, int languageId);

        void RemovePerson(Person person);
    }
}