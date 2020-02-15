namespace Client.Extensions
{
    public static class PersonExtensions
    {
        public static string GetStatus(this IPerson person)
        {
            return person.IsOnline == true
                ? "online"
                : "offline";
        }
    }
}