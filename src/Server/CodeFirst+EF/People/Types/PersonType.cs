using HotChocolate.Types;

namespace Chat.Server.People
{
    public class PersonType : ObjectType<Person>
    {
        protected override void Configure(IObjectTypeDescriptor<Person> descriptor)
        {
            descriptor.Field(t => t.Name).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.Email).Type<NonNullType<StringType>>();
            
            descriptor.Ignore(t => t.UserId);
            descriptor.Ignore(t => t.Friends);
            descriptor.Ignore(t => t.FriendOf);
        }
    }

}