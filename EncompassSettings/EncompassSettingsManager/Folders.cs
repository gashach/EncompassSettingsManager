using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.ClientServer;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Folders
    {
        public static List<LoanFolderInfo> GetAllFoldersInfoList(this EncompassSessionManager manager)
        {
            return manager.EncompassSessionObjects.LoanManager.GetAllLoanFolderInfos(false, false).ToList();
        }
    }
}