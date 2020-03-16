using Chat.Server.People;
using HotChocolate.Types;

namespace Chat.Server.Users
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(t => t.Person).Type<NonNullType<PersonType>>();
            descriptor.Field(t => t.Email).Type<NonNullType<StringType>>();

            descriptor.Ignore(t => t.PersonId);
            descriptor.Ignore(t => t.PasswordHash);
            descriptor.Ignore(t => t.Salt);
        }
    }
}