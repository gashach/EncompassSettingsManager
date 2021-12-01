using Newtonsoft.Json;
using System;
using EllieMae.EMLite.RemotingServices;

namespace EncompassSettings.Converters
{
    public class StateLicenseExtTypeConverter : JsonConverter<StateLicenseExtType>
        {
        public override StateLicenseExtType ReadJson(JsonReader reader, Type objectType, StateLicenseExtType existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            StateLicenseExtType result = new StateLicenseExtType(jo["StateAbbreviation"].ToString(), jo["LicenseType"].ToString(), jo["LicenseNo"].ToString(),
                DateTime.Parse(jo["IssueDate"].ToString()), DateTime.Parse(jo["StartDate"].ToString()), DateTime.Parse(jo["EndDate"].ToString()),
                jo["LicenseStatus"].ToString(), DateTime.Parse(jo["StatusDate"].ToString()), bool.Parse(jo["Approved"].ToString()), bool.Parse(jo["Exempt"].ToString()),
                DateTime.Parse(jo["LastChecked"].ToString()), int.Parse(jo["SortIndex"].ToString()));

            return result;
        }

        public override void WriteJson(JsonWriter writer, StateLicenseExtType value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);;
        }
    
    }
}