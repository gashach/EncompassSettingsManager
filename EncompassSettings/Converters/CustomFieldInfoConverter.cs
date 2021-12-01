using System;
using EllieMae.EMLite.DataEngine;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class CustomFieldInfoConverter: JsonConverter<CustomFieldInfo>
    {
        public override CustomFieldInfo ReadJson(JsonReader reader, Type objectType, CustomFieldInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            CustomFieldInfo result;
            result = new CustomFieldInfo(jo["FieldID"].ToString(), (EllieMae.EMLite.Common.FieldFormat)(int)jo["Format"]);
            result.Options = JsonConvert.DeserializeObject<string[]>(jo["Options"].ToString());
            if (result.Format == EllieMae.EMLite.Common.FieldFormat.AUDIT)
            {
                result.AuditSettings = JsonConvert.DeserializeObject<FieldAuditSettings>(jo["AuditSettings"].ToString());
            }
            else
            {
                result.Calculation = jo["Calculation"].ToString();
            }
            result.MaxLength = int.Parse(jo["MaxLength"].ToString());
            result.Description = jo["Description"].ToString();
            return result;
        }

        public override void WriteJson(JsonWriter writer, CustomFieldInfo value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}