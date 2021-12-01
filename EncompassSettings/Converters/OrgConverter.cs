using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;
using System;

namespace EncompassSettings.Converters
{
    public class OrgConverter: JsonConverter<OrgInfo>
        {
        public override OrgInfo ReadJson(JsonReader reader, Type objectType, OrgInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            OrgInfo result;
            result = new OrgInfo(int.Parse(jo["Oid"].ToString()),
                jo["OrgName"].ToString(),
                jo["Description"].ToString(),
                int.Parse(jo["Parent"].ToString()),
                JsonConvert.DeserializeObject<int[]>(jo["Children"].ToString())
            );

            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, OrgInfo value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}