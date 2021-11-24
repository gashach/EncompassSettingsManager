using System.Linq;
using EllieMae.EMLite.DataEngine;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class CustomFields
    {
        public static string GetAllCustomFieldInfo(this EncompassSessionManager manager)
        {
            var fields = manager.EncompassSessionObjects.ConfigurationManager.GetLoanCustomFields();
            var fieldData = fields.Cast<CustomFieldInfo>().ToList();
            return JsonConvert.SerializeObject(fieldData);
        }
    }
}