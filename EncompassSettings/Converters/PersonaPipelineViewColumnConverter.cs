using System;
using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class PersonaPipelineViewColumnConverter : JsonConverter<PersonaPipelineViewColumn>
        {
        public override PersonaPipelineViewColumn ReadJson(JsonReader reader, Type objectType, PersonaPipelineViewColumn existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            PersonaPipelineViewColumn result;
            result = new PersonaPipelineViewColumn(jo["ColumnDBName"].ToString(), int.Parse(jo["OrderIndex"].ToString()), (System.Windows.Forms.SortOrder)int.Parse(jo["SortOrder"].ToString()), int.Parse(jo["Width"].ToString()));

            return result;
        }

        public override void WriteJson(JsonWriter writer, PersonaPipelineViewColumn value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    
    }
}