using System.Linq;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Users
    {
        public static string GetAllUsers(this EncompassSessionManager manager, bool isEnabled)
        {
            var users = manager.EncompassSessionObjects.OrganizationManager.GetAllUsers().ToList();
            if (isEnabled)
                users = users.Where(x => manager.EncompassSession.Users.GetUser(x.Userid).Enabled).ToList();
            return JsonConvert.SerializeObject(users);
        }
    }
}