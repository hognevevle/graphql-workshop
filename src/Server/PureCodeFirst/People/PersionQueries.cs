using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Chat.Server.People
{
    [ExtendObjectType(Name = "Query")]
    public class PersionQueries
    {
        public Task<Person> GetMeAsync(
            [GlobalState]string currentUserEmail,
            PersonByEmailDataLoader personByEmail,
            CancellationToken cancellationToken) =>
            personByEmail.LoadAsync(currentUserEmail, cancellationToken);

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Person> GetPeople(
            [Service]IPersonRepository personRepository) =>
            personRepository.GetPersons();
 
        public Task<Person> GetPersonByEmailAsync(
            string email,
            PersonByEmailDataLoader personByEmail,
            CancellationToken cancellationToken) => 
            personByEmail.LoadAsync(email, cancellationToken);

        public Task<Person> GetPersonByIdAsync(
            Guid id,
            PersonByIdDataLoader personById,
            CancellationToken cancellationToken) => 
            personById.LoadAsync(id, cancellationToken);
    }
}
