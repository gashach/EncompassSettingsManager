using System;
using System.Collections;
using System.Collections.Generic;
using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class FieldAccessRightsConverter: JsonConverter<FieldAccessRights>
    {
        public override FieldAccessRights ReadJson(JsonReader reader, Type objectType, FieldAccessRights existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            var result = new FieldAccessRights(jo["FieldId"].ToString(), null);

            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, FieldAccessRights value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("FieldId");
            serializer.Serialize(writer, value.FieldID);
            writer.WritePropertyName("Rights");
            Dictionary<string, int> rights = new Dictionary<string, int>();
            foreach (DictionaryEntry right in value.AccessRights)
            {
                rights.Add(Global.PersonaMap[(int)right.Key], (int)right.Value);
            }
            serializer.Serialize(writer, rights);


            writer.WriteEndObject();
        }
    }
}