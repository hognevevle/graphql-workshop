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
    public class ChatResultParser
        : JsonResultParserBase<IChat>
    {
        private readonly IValueSerializer _directionSerializer;
        private readonly IValueSerializer _uuidSerializer;
        private readonly IValueSerializer _dateTimeSerializer;
        private readonly IValueSerializer _stringSerializer;

        public ChatResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _directionSerializer = serializerResolver.Get("Direction");
            _uuidSerializer = serializerResolver.Get("Uuid");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
            _stringSerializer = serializerResolver.Get("String");
        }

        protected override IChat ParserData(JsonElement data)
        {
            return new Chat
            (
                ParseChatMe(data, "me")
            );

        }

        private IPerson1 ParseChatMe(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Person1
            (
                ParseChatMeMessages(obj, "messages")
            );
        }

        private IMessageConnection ParseChatMeMessages(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return new MessageConnection
            (
                ParseChatMeMessagesNodes(obj, "nodes")
            );
        }

        private IReadOnlyList<IMessage> ParseChatMeMessagesNodes(
            JsonElement parent,
            string field)
        {
            if (!parent.TryGetProperty(field, out JsonElement obj))
            {
                return null;
            }

            if (obj.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            int objLength = obj.GetArrayLength();
            var list = new IMessage[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Message
                (
                    DeserializeDirection(element, "direction"),
                    DeserializeUuid(element, "id"),
                    DeserializeDateTime(element, "sent"),
                    DeserializeString(element, "text")
                );

            }

            return list;
        }

        private Direction DeserializeDirection(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (Direction)_directionSerializer.Deserialize(value.GetString());
        }

        private System.Guid DeserializeUuid(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.Guid)_uuidSerializer.Deserialize(value.GetString());
        }

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString());
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }
    }
}
