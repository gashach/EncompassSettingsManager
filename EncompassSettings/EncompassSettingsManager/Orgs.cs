using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Orgs
    {
        public static string GetAllOrgs(this EncompassSessionManager manager)
        {
            var orgs = manager.EncompassDefaultInstance.OrganizationManager.GetAllOrganizations();
            return JsonConvert.SerializeObject(orgs);
        }
    }
}