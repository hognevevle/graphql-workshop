using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace Chat.Server.People
{
    public static class PersonExtensions
    {
        public static Person AddFriendId(this Person person, Guid id)
        {
            if (person.FriendIds.Contains(id))
            {
                return person;
            }

            return new Person(
                person.Id,
                person.UserId,
                person.Name,
                person.Email,
                person.LastSeen,
                person.ImageUri,
                new List<Guid>(person.FriendIds) { id });
        }
    }

    
}
