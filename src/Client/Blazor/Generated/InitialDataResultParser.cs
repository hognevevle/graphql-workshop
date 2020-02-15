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
    public class InitialDataResultParser
        : JsonResultParserBase<IInitialData>
    {
        private readonly IValueSerializer _uuidSerializer;
        private readonly IValueSerializer _stringSerializer;
        private readonly IValueSerializer _urlSerializer;
        private readonly IValueSerializer _booleanSerializer;
        private readonly IValueSerializer _dateTimeSerializer;

        public InitialDataResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _uuidSerializer = serializerResolver.Get("Uuid");
            _stringSerializer = serializerResolver.Get("String");
            _urlSerializer = serializerResolver.Get("Url");
            _booleanSerializer = serializerResolver.Get("Boolean");
            _dateTimeSerializer = serializerResolver.Get("DateTime");
        }

        protected override IInitialData ParserData(JsonElement data)
        {
            return new InitialData
            (
                ParseInitialDataMe(data, "me"),
                ParseInitialDataPeople(data, "people")
            );

        }

        private IPerson ParseInitialDataMe(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Person
            (
                DeserializeUuid(obj, "id"),
                DeserializeString(obj, "name"),
                DeserializeString(obj, "email"),
                DeserializeNullableUrl(obj, "imageUri"),
                DeserializeBoolean(obj, "isOnline"),
                DeserializeDateTime(obj, "lastSeen")
            );
        }

        private IPersonConnection ParseInitialDataPeople(
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

            return new PersonConnection
            (
                ParseInitialDataPeopleNodes(obj, "nodes")
            );
        }

        private IReadOnlyList<IPerson> ParseInitialDataPeopleNodes(
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
            var list = new IPerson[objLength];
            for (int objIndex = 0; objIndex < objLength; objIndex++)
            {
                JsonElement element = obj[objIndex];
                list[objIndex] = new Person
                (
                    DeserializeUuid(element, "id"),
                    DeserializeString(element, "name"),
                    DeserializeString(element, "email"),
                    DeserializeNullableUrl(element, "imageUri"),
                    DeserializeBoolean(element, "isOnline"),
                    DeserializeDateTime(element, "lastSeen")
                );

            }

            return list;
        }

        private System.Guid DeserializeUuid(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.Guid)_uuidSerializer.Deserialize(value.GetString());
        }

        private string DeserializeString(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (string)_stringSerializer.Deserialize(value.GetString());
        }

        private System.Uri DeserializeNullableUrl(JsonElement obj, string fieldName)
        {
            if (!obj.TryGetProperty(fieldName, out JsonElement value))
            {
                return null;
            }

            if (value.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return (System.Uri)_urlSerializer.Deserialize(value.GetString());
        }

        private bool DeserializeBoolean(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (bool)_booleanSerializer.Deserialize(value.GetBoolean());
        }

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString());
        }
    }
}
