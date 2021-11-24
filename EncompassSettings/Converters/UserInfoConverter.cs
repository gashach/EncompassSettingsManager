using System;
using EllieMae.EMLite.RemotingServices;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class UserInfoConverter: JsonConverter<UserInfo>
    {
        public override UserInfo ReadJson(JsonReader reader, Type objectType, UserInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            UserInfo result;
            result = new UserInfo(jo["Userid"].ToString(),
                jo["Password"].ToString(),
                int.Parse(jo["OrgId"].ToString()),
                null
            );

            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, UserInfo value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}