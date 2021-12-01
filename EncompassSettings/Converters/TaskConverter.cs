using System;
using EllieMae.EMLite.DataEngine.Log;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class TaskConverter: JsonConverter<MilestoneTaskDefinition>
    {
        public override MilestoneTaskDefinition ReadJson(JsonReader reader, Type objectType, MilestoneTaskDefinition existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            MilestoneTaskDefinition result;
            result = new MilestoneTaskDefinition(jo["TaskName"].ToString(), jo["TaskDescription"].ToString(), int.Parse(jo["DaysToComplete"].ToString()), (MilestoneTaskDefinition.MilestoneTaskPriority)int.Parse(jo["TaskPriority"].ToString()));
            result.TaskGUID = jo["TaskGUID"].ToString();
            return result;
        }

        public override void WriteJson(JsonWriter writer, MilestoneTaskDefinition value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}