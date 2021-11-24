using System;
using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class LoanAccessRightsConverter: JsonConverter<LoanAccessRights>
    {
        public override LoanAccessRights ReadJson(JsonReader reader, Type objectType, LoanAccessRights existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            LoanAccessRights result;
            result = new LoanAccessRights(null);

            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, LoanAccessRights value, JsonSerializer serializer)
        {
            writer.WriteStartArray();

//TODO: FIX GLOBAL
            foreach (var persona in Global.PersonaMap)
            {
                writer.WriteStartObject();
                writer.WritePropertyName("PersonaName");
                writer.WriteValue(persona.Value);
                writer.WritePropertyName("AccessRight");
                writer.WriteValue(value.GetAccessRight(persona.Key));
                writer.WritePropertyName("editableFields");
                serializer.Serialize(writer, value.GetEditableFields(persona.Key));
                writer.WriteEndObject();
            }
            writer.WriteEndArray();


            writer.WriteEndArray();
        }
    }
}