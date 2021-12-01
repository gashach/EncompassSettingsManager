using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Fees
    {
        public static List<FeeManagementRecord> GetAllFees(this EncompassSessionManager manager)
        {
            var fees = manager.EncompassSessionObjects.ConfigurationManager.GetFeeManagement().GetAllFees().ToList();
            return fees;
        }

        public static void AddUpdateFees(this EncompassSessionManager manager, List<FeeManagementRecord> feeRecords)
        {
            FeeManagementSetting feeManagementSetting = new FeeManagementSetting();
            foreach (var feeRecord in feeRecords)
            {
                feeManagementSetting.AddFee(feeRecord);
            }

            feeManagementSetting.CompanyOptIn = true;
            manager.EncompassSessionObjects.ConfigurationManager.UpdateFeeManagement(feeManagementSetting);
        }
    }
}