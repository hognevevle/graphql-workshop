using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using HotChocolate;
using HotChocolate.Types;

#nullable disable

namespace Chat.Server.People
{
    public class Person
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public DateTime LastSeen { get; set; }

        public Uri ImageUri { get; set; }

        public List<PersonToFriend> Friends { get; } = new List<PersonToFriend>();

        public List<PersonToFriend> FriendOf { get; } = new List<PersonToFriend>();
    }
}
