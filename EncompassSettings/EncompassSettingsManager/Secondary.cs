using System.Collections;
using System.Collections.Generic;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.RemotingServices;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Secondary
    {
        public static Dictionary<SecondaryFieldTypes, ArrayList> GetAllSecondaryFields(this EncompassSessionManager manager)
        {
            Dictionary<SecondaryFieldTypes, ArrayList> secondary = new Dictionary<SecondaryFieldTypes, ArrayList>();
            secondary[SecondaryFieldTypes.BaseRate] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BaseRate);
            secondary[SecondaryFieldTypes.BaseMargin] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BaseMargin);
            secondary[SecondaryFieldTypes.BasePrice] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BasePrice);
            secondary[SecondaryFieldTypes.ProfitabilityOption] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.ProfitabilityOption);
            secondary[SecondaryFieldTypes.LockTypeOption] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.LockTypeOption);

            return secondary;
        }

        public static Dictionary<FileSystemEntry, BinaryObject> GetSRPTemplates(this EncompassSessionManager manager) =>
             manager.GetTemplates(TemplateSettingsType.SRPTable);
    }
}