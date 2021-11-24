using System;
using System.Linq;
using System.Reflection;
using EllieMae.EMLite.DataEngine.eFolder;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class DocumentTemplateConverter: JsonConverter<DocumentTemplate>
    {
        public override DocumentTemplate ReadJson(JsonReader reader, Type objectType, DocumentTemplate existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);
            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new DocumentCriteriaConverter());
            settings.Converters.Add(new PreClosingCriteriaConverter());
            settings.Converters.Add(new OpeningCriteriaConverter());
            DocumentTemplate result;
            result = new DocumentTemplate(jo["Guid"].ToString(), jo["Name"].ToString())
            {
                Description = jo["Description"].ToString(),
                Source = jo["Source"].ToString(),
                SourceType = jo["SourceType"].ToString(),
                DaysTillDue = int.Parse(jo["DaysTillDue"].ToString()),
                DaysTillExpire = int.Parse(jo["DaysTillExpire"].ToString()),
                IsCondition = int.Parse(jo["IsCondition"].ToString()),
                //ConditionInfo = jo["ConditionInfo"].ToString(),
                //eFolder = jo["eFolder"].ToString(),
                OpeningDocument = bool.Parse(jo["OpeningDocument"].ToString()),
                OpeningCriteria = jo["OpeningCriteria"].ToString() == "" ? null : JsonConvert.DeserializeObject<OpeningCriteria>(jo["OpeningCriteria"].ToString(), settings),
                PreClosingDocument = bool.Parse(jo["PreClosingDocument"].ToString()),
                PreClosingCriteria = jo["PreClosingCriteria"].ToString() == "" ? null : JsonConvert.DeserializeObject<PreClosingCriteria>(jo["PreClosingCriteria"].ToString(), settings),
                ClosingDocument = bool.Parse(jo["ClosingDocument"].ToString()),
                ClosingCriteria = jo["ClosingCriteria"].ToString() == "" ? null : JsonConvert.DeserializeObject<DocumentCriteria>(jo["ClosingCriteria"].ToString(), settings),
                IsWebcenter = bool.Parse(jo["IsWebcenter"].ToString()),
                IsTPOWebcenterPortal = bool.Parse(jo["IsTPOWebcenterPortal"].ToString()),
                IsThirdPartyDoc = bool.Parse(jo["IsThirdPartyDoc"].ToString()),
                SignatureType = jo["SignatureType"].ToString(),
                ConversionType = (EllieMae.EMLite.Common.eFolder.ImageConversionType)int.Parse(jo["ConversionType"].ToString()),
                SaveOriginalFormat = bool.Parse(jo["SaveOriginalFormat"].ToString()),
                SourceBorrower = jo["SourceBorrower"].ToString(),
                SourceCoborrower = jo["SourceCoborrower"].ToString(),
                //IsPrintable = bool.Parse(jo["IsPrintable"].ToString()),

            };
            FieldInfo[] fields = typeof(DocumentTemplate).GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
            fields.First(x => x.Name == "conditionInfo").SetValue(result, jo["ConditionInfo"].ToString());
            fields.First(x => x.Name == "efolder").SetValue(result, bool.Parse(jo["eFolder"].ToString()));


            return result;
        }

        public override void WriteJson(JsonWriter writer, DocumentTemplate value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}