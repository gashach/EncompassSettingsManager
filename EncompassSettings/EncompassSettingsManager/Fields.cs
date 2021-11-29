using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.DataEngine;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Fields
    {
        public static string GetAllPiggybackFields(this EncompassSessionManager manager)
        {
            var pfFields = (PiggybackFields)manager.EncompassDefaultInstance.GetSystemSettings(typeof(PiggybackFields));
            return JsonConvert.SerializeObject(pfFields.GetSyncFields());
        }

        public static void AddUpdateCustomFields(this EncompassSessionManager manager, List<CustomFieldInfo> fields)
        {
            var existingFields = manager.EncompassSessionObjects.ConfigurationManager.GetLoanCustomFields()
                .Cast<CustomFieldInfo>().ToList();
            var cfi = new CustomFieldsInfo(false);
            foreach (var newField in fields)
            {
                cfi.Add(newField);
            }
            manager.EncompassSessionObjects.ConfigurationManager.UpdateLoanCustomFields(cfi,false);
        }
    }
}