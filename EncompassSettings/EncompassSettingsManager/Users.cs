using System.Collections.Generic;
using System.Linq;
using Elli.Common.Extensions;
using EllieMae.EMLite.RemotingServices;
using EllieMae.Encompass.BusinessObjects.Users;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Users
    {
        public static string GetAllUsersAsJson(this EncompassSessionManager manager, bool isEnabled)
        {
            var users = manager.EncompassSessionObjects.OrganizationManager.GetAllUsers().ToList();
            if (isEnabled)
                users = users.Where(x => manager.EncompassSession.Users.GetUser(x.Userid).Enabled).ToList();
            return JsonConvert.SerializeObject(users);
        }

        public static List<UserInfo> GetUserInfoList(this EncompassSessionManager manager, bool isEnabled)
        {
            var users = manager.EncompassSessionObjects.OrganizationManager.GetAllUsers().ToList();
            if (isEnabled)
                users = users.Where(x => manager.EncompassSession.Users.GetUser(x.Userid).Enabled).ToList();
            return users;
        }

        public static List<User> GetAllUsers(this EncompassSessionManager manager)
        {
            return manager.EncompassSession.Users.GetAllUsers().Cast<User>()
                .ToList();
        }
    }
}