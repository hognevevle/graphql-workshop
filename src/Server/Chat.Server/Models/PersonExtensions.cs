using System.Linq;
using System.Collections.Immutable;
using System;
using System.Collections.Generic;

namespace Chat.Server
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
                new List<Guid>(person.FriendIds) { id });
        }
    }

    
}
