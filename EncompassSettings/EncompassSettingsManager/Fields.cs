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
    }
}