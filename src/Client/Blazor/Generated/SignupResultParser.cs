using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;
using StrawberryShake;
using StrawberryShake.Configuration;
using StrawberryShake.Http;
using StrawberryShake.Http.Subscriptions;
using StrawberryShake.Transport;

namespace Client
{
    [System.CodeDom.Compiler.GeneratedCode("StrawberryShake", "11.0.0")]
    public class SignUpResultParser
        : JsonResultParserBase<ISignUp>
    {
        private readonly IValueSerializer _iDSerializer;

        public SignUpResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _iDSerializer = serializerResolver.Get("ID");
        }

        protected override ISignUp ParserData(JsonElement data)
        {
            return new SignUp
            (
                ParseSignUpCreateUser(data, "createUser")
            );

        }

        private ICreateUserPayload ParseSignUpCreateUser(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new CreateUserPayload
            (
                ParseSignUpCreateUserUser(obj, "user")
            );
        }

        private IUser ParseSignUpCreateUserUser(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new User
            (
                DeserializeID(obj, "email")
            );
        }

        private string DeserializeID(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_iDSerializer.Deserialize(value.GetString());
        }
    }
}
