using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Fees
    {
        public static string GetAllFees(this EncompassSessionManager manager)
        {
            var fees = manager.EncompassSessionObjects.ConfigurationManager.GetFeeManagement();
            return JsonConvert.SerializeObject(fees);
        }
    }
}