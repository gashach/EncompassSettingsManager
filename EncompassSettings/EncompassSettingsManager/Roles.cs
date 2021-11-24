using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.RemotingServices;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Roles
    {
        public static List<RoleInfo> GetAllRoles(this EncompassSessionManager manager)
        {
            var mgr = (WorkflowManager) manager.EncompassDefaultInstance.BPM.GetBpmManager(BpmCategory.Workflow);
            return mgr.GetAllRoleFunctions().ToList();
        }
    }
}