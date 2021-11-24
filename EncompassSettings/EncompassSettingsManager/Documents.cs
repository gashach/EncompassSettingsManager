using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Documents
    {
        public static string GetDocumentTrackingSetup(this EncompassSessionManager manager)
        {
            var docTracking = manager.EncompassSessionObjects.ConfigurationManager.GetDocumentTrackingSetup();
            return JsonConvert.SerializeObject(docTracking);
        }
    }
}