using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.DataEngine.Log;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class MilestoneTasks
    {
        public static List< MilestoneTaskDefinition> GetAllMilestoneTasks(
            this EncompassSessionManager manager)
        {
            return manager.EncompassSessionObjects.ConfigurationManager.GetMilestoneTasks().Cast<MilestoneTaskDefinition>().ToList();
        }

        public static void AddMilestoneTasks(this EncompassSessionManager manager,
            Dictionary<Guid, MilestoneTaskDefinition> taskList)
        {
            foreach (var taskItem in taskList)
            {
                manager.EncompassSessionObjects.ConfigurationManager.AddMilestoneTask(taskItem.Value);
            }
        }
    }
}