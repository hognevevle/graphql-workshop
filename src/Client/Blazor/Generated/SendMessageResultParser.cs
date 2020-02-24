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
    public class SendMessageResultParser
        : JsonResultParserBase<ISendMessage>
    {
        private readonly IValueSerializer _dateTimeSerializer;

        public SendMessageResultParser(IValueSerializerCollection serializerResolver)
        {
            if (serializerResolver is null)
            {
                throw new ArgumentNullException(nameof(serializerResolver));
            }
            _dateTimeSerializer = serializerResolver.Get("DateTime");
        }

        protected override ISendMessage ParserData(JsonElement data)
        {
            return new SendMessage1
            (
                ParseSendMessageSendMessage(data, "sendMessage")
            );

        }

        private ISendMessagePayload ParseSendMessageSendMessage(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new SendMessagePayload
            (
                ParseSendMessageSendMessageMessage(obj, "message")
            );
        }

        private IMessage1 ParseSendMessageSendMessageMessage(
            JsonElement parent,
            string field)
        {
            JsonElement obj = parent.GetProperty(field);

            return new Message1
            (
                DeserializeDateTime(obj, "sent")
            );
        }

        private System.DateTimeOffset DeserializeDateTime(JsonElement obj, string fieldName)
        {
            JsonElement value = obj.GetProperty(fieldName);
            return (System.DateTimeOffset)_dateTimeSerializer.Deserialize(value.GetString());
        }
    }
}
