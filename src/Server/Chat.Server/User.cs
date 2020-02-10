using System;
using System.Collections.Generic;

namespace Chat.Server
{
    public class User
    {
        public User(Guid id, string name, string email, Uri image, IReadOnlyList<Guid> friendIds)
        {
            Id = id;
            Name = name;
            Email = email;
            Image = image;
            FriendIds = friendIds;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Email { get; }

        public Uri Image { get; }

        public IReadOnlyList<Guid> FriendIds { get; }
    }
}
