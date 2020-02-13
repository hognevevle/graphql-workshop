using System;
using System.Collections.Generic;

namespace Chat.Server
{
    public class Person
    {
        public Person(
            Guid id,
            Guid userId,
            string name,
            string email,
            DateTime lastSeen,
            Uri? imageUri,
            IReadOnlyList<Guid> friendIds)
        {
            Id = id;
            UserId = userId;
            Name = name;
            Email = email;
            LastSeen = lastSeen;
            FriendIds = friendIds;
        }

        public Guid Id { get; }

        public Guid UserId { get; }

        public string Name { get; }

        public string Email { get; }

        public DateTime LastSeen { get; }

        public Uri? ImageUri { get; }

        public IReadOnlyList<Guid> FriendIds { get; }
    }
}
