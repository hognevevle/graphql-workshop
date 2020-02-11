using HotChocolate.Types;

namespace Chat.Server.Types
{
    public static class UserObjectTypeExtensions
    {
        public static IObjectTypeDescriptor<User> DefaultIgnores(
            this IObjectTypeDescriptor<User> descriptor)
        {
            return descriptor
                .Ignore(t => t.FriendIds)
                .Ignore(t => t.PasswordHash)
                .Ignore(t => t.Salt)
                .Ignore(t => t.AddFriendId(default));
        }
    }
}
