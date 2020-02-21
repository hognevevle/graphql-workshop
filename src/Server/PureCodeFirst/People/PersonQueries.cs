using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Chat.Server.People
{
    [Authorize]
    [ExtendObjectType(Name = "Query")]
    public class PersonQueries
    {
        /// <summary>
        /// Gets the currently logged in user.
        /// </summary>
        public Task<Person> GetMeAsync(
            [GlobalState]string currentUserEmail,
            PersonByEmailDataLoader personByEmail,
            CancellationToken cancellationToken) =>
            personByEmail.LoadAsync(currentUserEmail, cancellationToken);

        /// <summary>
        /// Gets access to all the people known to this service.
        /// </summary>
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
