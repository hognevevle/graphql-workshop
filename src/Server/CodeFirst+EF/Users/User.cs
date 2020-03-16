using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Chat.Server.People;
using HotChocolate;

#nullable disable

namespace Chat.Server.Users
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public Guid PersonId { get; set; }

        public Person Person { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Salt { get; set; }
    }
}
