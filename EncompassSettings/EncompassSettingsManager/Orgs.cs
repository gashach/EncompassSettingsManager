using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EllieMae.EMLite.ClientServer;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Orgs
    {
        public static List<OrgInfo> GetAllOrgs(this EncompassSessionManager manager)
        {
            var orgs = manager.EncompassDefaultInstance.OrganizationManager.GetAllOrganizations();
            return orgs.ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="jsonData"></param>
        /// <returns>Old OrgID to New OrgID map</returns>
        public static Dictionary<int, int> PushOrgs(this EncompassSessionManager manager, string jsonData)
        {
            var incomingOrgs =
                JsonConvert.DeserializeObject<List<OrgInfo>>(jsonData, Converters.ConverterRegistry.JsonSettings);
            var existingOrgs = manager.EncompassSessionObjects.OrganizationManager.GetAllOrganizations().ToList();
            var OldToNewIDMap = new Dictionary<int, int>();

            foreach (var incomingOrg in incomingOrgs)
            {
                var existsList = existingOrgs.Where(x => x.OrgCode == incomingOrg.OrgCode).ToList();
                if (existsList.Count != 1 && incomingOrg.Oid > 0)
                {
                    if (existsList.Count > 0)
                    {
                        var secondaryCheck = existsList.Where(x => x.OrgName == incomingOrg.OrgName).ToList();
                        if (secondaryCheck.Count == 1)
                            OldToNewIDMap.Add(incomingOrg.Oid, secondaryCheck.First().Oid);
                        else if (secondaryCheck.Count > 1)
                        {
                            //TODO: add error handler for this and return useful info
                        }

                        else
                        {
                            incomingOrg.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                                .Single(x => x.Name == "parent")
                                .SetValue(incomingOrg, OldToNewIDMap[incomingOrg.Parent]);
                            var id = manager.EncompassSessionObjects.OrganizationManager
                                .CreateOrganization(incomingOrg);
                            OldToNewIDMap.Add(incomingOrg.Oid, id);
                        }
                    }
                    else
                    {
                        incomingOrg.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                            .Single(x => x.Name == "parent")
                            .SetValue(incomingOrg, OldToNewIDMap[incomingOrg.Parent]);
                        var id = manager.EncompassSessionObjects.OrganizationManager.CreateOrganization(incomingOrg);
                        OldToNewIDMap.Add(incomingOrg.Oid, id);
                    }
                }
                else if (incomingOrg.Oid == 0)
                {
                    OldToNewIDMap.Add(0,0);
                }
                else
                {
                    OldToNewIDMap.Add(incomingOrg.Oid,existsList.First().Oid);
                }
            }

            return OldToNewIDMap;
        }
    }
}