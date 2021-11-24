using System;
using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class XdbConverter: JsonConverter<LoanXDBField>
    {
        public override LoanXDBField ReadJson(JsonReader reader, Type objectType, LoanXDBField existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            LoanXDBField result;
            result = new LoanXDBField(jo["FieldID"].ToString(),
                jo["Description"].ToString(),
                (LoanXDBTableList.TableTypes)int.Parse(jo["FieldType"].ToString()),
                jo["FieldSizeToInteger"].ToString(),
                false,
                bool.Parse(jo["Auditable"].ToString()),
                int.Parse(jo["ComortgagorPair"].ToString()),
                LoanXDBField.FieldStatus.New,
                true

            );

            return result;
        }

        public override void WriteJson(JsonWriter writer, LoanXDBField value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}