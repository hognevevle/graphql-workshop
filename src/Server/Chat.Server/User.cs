using System;
using System.Collections.Generic;

namespace Chat.Server
{
    public class User
    {
        public User(
            Guid id, 
            string name, 
            string email, 
            string passwordHash, 
            string salt, 
            IReadOnlyList<Guid> friendIds)
        {
            Id = id;
            Name = name;
            Email = email;
            PasswordHash = passwordHash;
            Salt = salt;
            FriendIds = friendIds;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Email { get; }

        public string PasswordHash { get; }

        public string Salt { get; }

        public IReadOnlyList<Guid> FriendIds { get; }
    }
}
