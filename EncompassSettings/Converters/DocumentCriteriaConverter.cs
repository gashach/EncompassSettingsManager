using System;
using EllieMae.EMLite.DataEngine.eFolder;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class DocumentCriteriaConverter: JsonConverter<DocumentCriteria>
    {
        public override DocumentCriteria ReadJson(JsonReader reader, Type objectType, DocumentCriteria existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            DocumentCriteria result;
            result = new DocumentCriteria(JsonConvert.DeserializeObject<string[]>(jo["AmortTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["LienTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["LoanPurposeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["LoanTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["OccupancyTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["PropertyStateValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["PlanCodeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["FormVersionValues"].ToString()));
            return result;
        }

        public override void WriteJson(JsonWriter writer, DocumentCriteria value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}