using System;
using EllieMae.EMLite.DataEngine.eFolder;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class PreClosingCriteriaConverter: JsonConverter<PreClosingCriteria>
    {
        public override PreClosingCriteria ReadJson(JsonReader reader, Type objectType, PreClosingCriteria existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            PreClosingCriteria result;
            result = new PreClosingCriteria(JsonConvert.DeserializeObject<string[]>(jo["AmortTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["LienTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["LoanPurposeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["LoanTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["OccupancyTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["PropertyStateValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["PlanCodeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["ChannelTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["EntityTypeValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["LoanLockValues"].ToString()),
                JsonConvert.DeserializeObject<string[]>(jo["ChangedCircumstance"].ToString())
            );
            return result;
        }

        public override void WriteJson(JsonWriter writer, PreClosingCriteria value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}