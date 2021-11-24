using System;
using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class FRRangeConverter: JsonConverter<FRRange>
    {
        public override FRRange ReadJson(JsonReader reader, Type objectType, FRRange existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            FRRange result;
            result = new FRRange(jo["LowerBound"].ToString(), jo["UpperBound"].ToString());

            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, FRRange value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("LowerBound");
            serializer.Serialize(writer, value.LowerBound);
            writer.WritePropertyName("UpperBound");
            serializer.Serialize(writer, value.UpperBound);


            writer.WriteEndObject();
        }
    }
}