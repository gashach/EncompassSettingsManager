using System.Collections;
using System.Collections.Generic;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.RemotingServices;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Secondary
    {
        public static string GetAllSecondaryFields(this EncompassSessionManager manager)
        {
            Dictionary<SecondaryFieldTypes, ArrayList> secondary = new Dictionary<SecondaryFieldTypes, ArrayList>();
            secondary[SecondaryFieldTypes.BaseRate] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BaseRate);
            secondary[SecondaryFieldTypes.BaseMargin] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BaseMargin);
            secondary[SecondaryFieldTypes.BasePrice] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BasePrice);
            secondary[SecondaryFieldTypes.ProfitabilityOption] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.ProfitabilityOption);
            secondary[SecondaryFieldTypes.LockTypeOption] = manager.EncompassSessionObjects.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.LockTypeOption);

            return JsonConvert.SerializeObject(secondary);
        }

        public static string GetSRPTemplates(this EncompassSessionManager manager)
        {
            var SRPList =
                manager.EncompassSessionObjects.ConfigurationManager.GetAllPublicTemplateSettingsFileEntries(
                    TemplateSettingsType.SRPTable, true);
            var investorData = new Dictionary<string, BinaryObject>();
            foreach (var entry in SRPList)
            {
                var template =
                    manager.EncompassSessionObjects.ConfigurationManager.GetTemplateSettings(
                        TemplateSettingsType.SRPTable, entry);
                if (template!=null)
                    investorData.Add(entry.Name, template);
            }

            return JsonConvert.SerializeObject(investorData);
        }
    }
}