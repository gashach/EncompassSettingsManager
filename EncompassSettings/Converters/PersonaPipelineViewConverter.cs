using System;
using System.Collections.Generic;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.ClientServer.Reporting;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public class PersonaPipelineViewConverter: JsonConverter<PersonaPipelineView>
    {
        public override PersonaPipelineView ReadJson(JsonReader reader, Type objectType, PersonaPipelineView existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            Newtonsoft.Json.Linq.JObject jo = Newtonsoft.Json.Linq.JObject.Load(reader);
            //TODO: Create method to register oldID to new ID lookup
            Dictionary<int, int> newIDLookup = new Dictionary<int, int>();
            if (!newIDLookup.TryGetValue(int.Parse(jo["PersonaID"].ToString()), out var id))
                return null;
            var result = new PersonaPipelineView(id)
            {
                LoanFolders = jo["LoanFolders"].ToString(),
                Ownership = PipelineViewLoanOwnership.User,
                Name = jo["Name"].ToString()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(new PersonaPipelineViewColumnConverter());
            var cols = JsonConvert.DeserializeObject<List<PersonaPipelineViewColumn>>(jo["Columns"].ToString(), settings);

            result.Columns.AddRange(cols.ToArray());


            result.Filter = JsonConvert.DeserializeObject<FieldFilterList>(jo["Filter"].ToString());



            return result;
        }

        public override void WriteJson(JsonWriter writer, PersonaPipelineView value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}