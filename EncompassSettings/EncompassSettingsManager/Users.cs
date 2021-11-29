using System;
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

        public static void AddUser(this EncompassSessionManager manager, UserInfo user, string password, int orgId)
        {
            var personaArray = new EllieMae.EMLite.Common.Persona[1];
            personaArray[0] = manager.EncompassSessionObjects.PersonaManager.GetPersonaByName("Every User");
            UserInfo newUser = new UserInfo(user.Userid, password, user.LastName, user.SuffixName, user.FirstName,
                user.MiddleName, user.EmployeeID,
                user.ProfileURL, personaArray, user.WorkingFolder, orgId, false, user.AccessMode, user.Status,
                user.Email, user.Phone,
                user.CellPhone, user.Fax, false, true, false, user.PeerView, user.DataServicesOptOutKey,
                user.LegacyDelegateTasksRight, DateTime.MinValue, user.CHUMId,
                user.NMLSOriginatorID, user.NMLSExpirationDate, user.EncompassVersion, user.EmailSignature,
                user.PersonalStatusOnline, user.InheritParentCompPlan,
                user.ApiUser, user.OAuthClientId, user.AllowImpersonation, user.InheritParentCCSite);
            manager.EncompassSessionObjects.OrganizationManager.CreateNewUser(newUser);
            var createdUser = manager.EncompassSession.Users.GetUser(newUser.Userid);
            List<string> personaNames = new List<string>(){"Every User"};
            var currentPersonas = manager.GetAllPersonasStandard();
            foreach (var persona in user.UserPersonas)
            {
                var oldPersonaName = persona.Name;
                if (!personaNames.Contains(oldPersonaName) && currentPersonas.Select(x=>x.Name).Contains(oldPersonaName))
                {
                    createdUser.Personas.Add(currentPersonas.Single(x=>x.Name == oldPersonaName));
                }
            }
            createdUser.Commit();
        }
    }
}