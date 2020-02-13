using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Chat.Server.DataLoader;
using Chat.Server.Repositories;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace Chat.Server
{
    public class Query
    {
        public Task<Person> GetMeAsync(
            [State("CurrentUserEmail")]string email,
            [DataLoader]PersonByEmailDataLoader personByEmail,
            CancellationToken cancellationToken) =>
            personByEmail.LoadAsync(email, cancellationToken);

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Person> GetPeople(
            [Service]IPersonRepository personRepository) =>
            personRepository.GetPersons();
    }
}
