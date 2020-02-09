using System;

namespace Chat.Server
{
    public class User
    {
        public User(Guid id, string name, string email, Uri image)
        {
            Id = id;
            Name = name;
            Email = email;
            Image = image;
        }

        public Guid Id { get; }

        public string Name { get; }

        public string Email { get; }

        public Uri Image { get; }
    }
}
