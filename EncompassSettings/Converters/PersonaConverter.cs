using System;
using EllieMae.EMLite.Common;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class PersonaConverter: JsonConverter<Persona>
    {
        public override Persona ReadJson(JsonReader reader, Type objectType, Persona existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            Persona result;
            result = new Persona(int.Parse(jo["ID"].ToString()),
                jo["Name"].ToString(),
                bool.Parse(jo["AclFeaturesDefault"].ToString()),
                int.Parse(jo["DisplayOrder"].ToString())
            );

            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, Persona value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}