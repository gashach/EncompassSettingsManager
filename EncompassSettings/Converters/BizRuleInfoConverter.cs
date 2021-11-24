using System;
using System.Collections;
using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class BizRuleInfoConverter: JsonConverter<BizRuleInfo>
    {
        public override BizRuleInfo ReadJson(JsonReader reader, Type objectType, BizRuleInfo existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);

            BizRuleInfo result = null;
            switch (jo["RuleType"].ToString())
            {
                case "FieldAccess":
                    result = new FieldAccessRuleInfo(int.Parse(jo["RuleId"].ToString()),
                        jo["RuleName"].ToString(),
                        (BizRule.Condition)int.Parse(jo["Condition"].ToString()),
                        jo["Condition2"].ToString(),
                        jo["ConditionState"].ToString(),
                        jo["ConditionState2"].ToString(),
                        jo["AdvancedCodeXML"].ToString(),
                        jo["CommentsTxt"].ToString(),
                        JsonConvert.DeserializeObject<FieldAccessRights[]>(jo["FieldAccessRights"].ToString()));
                    break;

                case "FieldRules":
                    result = new FieldRuleInfo(int.Parse(jo["RuleId"].ToString()),
                        jo["RuleName"].ToString(),
                        (BizRule.Condition)int.Parse(jo["Condition"].ToString()),
                        jo["Condition2"].ToString(),
                        jo["ConditionState"].ToString(),
                        jo["ConditionState2"].ToString(),
                        jo["AdvancedCodeXML"].ToString(),
                        jo["CommentsTxt"].ToString(),
                        JsonConvert.DeserializeObject<Hashtable>(jo["RequiredFields"].ToString()),
                        JsonConvert.DeserializeObject<Hashtable>(jo["FieldRules"].ToString())
                        );
                    break;
            }


            serializer.Populate(jo.CreateReader(), result);
            return result;
        }

        public override void WriteJson(JsonWriter writer, BizRuleInfo value, JsonSerializer serializer)
        {
            JsonSerializer ks = new JsonSerializer();
            ks.Serialize(writer, value);
        }
    }
}