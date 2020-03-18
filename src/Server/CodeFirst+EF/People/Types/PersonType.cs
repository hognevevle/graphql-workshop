using Chat.Server.Messages;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

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

    public class InviteFriendInputType : InputObjectType<InviteFriendInput>
    {
    }

    public class InviteFriendPayloadType : ObjectType<InviteFriendPayload>
    {
        protected override void Configure(IObjectTypeDescriptor<InviteFriendPayload> descriptor)
        {
            descriptor.Field(t => t.Me).Type<NonNullType<PersonType>>();
        }
    }

    public class PersonTypeExtension : ObjectType<PersonExtension>
    {
        protected override void Configure(IObjectTypeDescriptor<PersonExtension> descriptor)
        {
            descriptor.Name("Person");

            descriptor.Field(t => t.GetMessages(default, default!, default!))
                .UsePaging<NonNullType<MessageType>>()
                .UseSelection()
                .UseFiltering()
                .UseSorting();

            descriptor.Field(t => t.GetFriends(default!, default!))
                .UsePaging<NonNullType<PersonType>>()
                .UseSelection()
                .UseFiltering()
                .UseSorting();
        }
    }

    public class PersonMutationTypeExtension : ObjectTypeExtension<PersonMutations>
    {
        protected override void Configure(IObjectTypeDescriptor<PersonMutations> descriptor)
        {
            descriptor.Name("Mutation");

            descriptor.Field(t => t.InviteFriendAsync(
                default!, default!, default!, default!, default))
                .Argument("input", a => a.Type<NonNullType<InviteFriendInputType>>())
                .Type<NonNullType<InviteFriendPayloadType>>();

            descriptor.Field(t => t.TypingAsync(default!, default!, default!, default!, default))
                .Argument("input", a => a.Type<NonNullType<TypingInputType>>())
                .Type<NonNullType<TypingPayloadType>>();
        }
    }

    public class TypingInputType : InputObjectType<TypingInput>
    {

    }

    public class TypingPayloadType : ObjectType<TypingPayload>
    {

    }
}