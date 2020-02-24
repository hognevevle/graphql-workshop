using System;

namespace Client.Extensions
{
    public static class PersonExtensions
    {
        public static string GetStatus(this IPerson? person)
        {
            return person != null && person.IsOnline == true
                ? "online"
                : "offline";
        }

        public static IPerson ToPerson(this PersonFromStore personFromStore)
        {
            return new Person(
                personFromStore.Name,
                personFromStore.ImageUri,
                personFromStore.IsOnline,
                personFromStore.LastSeen,
                personFromStore.Id,
                personFromStore.Email);
        }
    }

    public class PersonFromStore
        : IPerson
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Uri ImageUri { get; set; }
        public bool IsOnline { get; set; }
        public DateTimeOffset LastSeen { get; set; }
    }
}