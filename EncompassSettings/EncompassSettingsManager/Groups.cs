using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.Server;
using EllieMae.EMLite.Setup;
using Newtonsoft.Json;
using User = EllieMae.Encompass.BusinessObjects.Users.User;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Groups
    {
        public static List<UserGroupExport> GetAllUserGroupsAsJson(this EncompassSessionManager manager)
        {
            var groupList = manager.EncompassSessionObjects.AclGroupManager.GetAllGroups();
            var userGroups = new List<UserGroupExport>();
            foreach (var aclGroup in  groupList)
            {
                var uge = new UserGroupExport();
                uge.Name = aclGroup.Name;
                uge.AclGroupLoanMembers =
                    manager.EncompassSessionObjects.AclGroupManager.GetMembersInGroupLoan(aclGroup.ID);
                uge.AclOrgGroupMembers =
                    manager.EncompassSessionObjects.AclGroupManager.GetOrgsInGroup(aclGroup.ID);
                uge.AclUserGroupMembers =
                    manager.EncompassSessionObjects.AclGroupManager.GetUsersInGroup(aclGroup.ID, true);
                userGroups.Add(uge);
            }

            return userGroups;
        }

        public static void ImportGroups(this EncompassSessionManager manager,
            Dictionary<int, int> oldOrgToNewOrgIdMap,
            List<UserGroupExport> incomingGroups)
        {
            var personas = manager.GetAllPersonas();
            var currentUsers = manager.GetUserInfoList(false);
            var folders = manager.GetAllFoldersInfoList();
            var roles = manager.GetAllRoles();
            var users = manager.GetAllUsers();

            foreach (var incomingGroup in incomingGroups)
            {
                var existingGroup = manager.EncompassSessionObjects.AclGroupManager.GetGroupByName(incomingGroup.Name);
                AclGroup group;
                if (existingGroup != null)
                    continue;
                else
                {
                    group = manager.EncompassSessionObjects.AclGroupManager.CreateGroup(incomingGroup.Name);
                }

                group.ViewSubordinatesContacts = false;
                manager.EncompassSessionObjects.AclGroupManager.UpdateGroup(group);
                foreach (var roleInfo in roles)
                {
                    manager.EncompassSessionObjects.AclGroupManager
                        .UpdateAclGroupRoleAccessLevel(new AclGroupRoleAccessLevel(group.ID, roleInfo.RoleID,AclGroupRoleAccessEnum.BelowInOrg,true));
                }

                foreach (var member in incomingGroup.AclGroupLoanMembers.UserMembers)
                {
                    if (users.Any(x=>x.ID == member.UserID && x.Enabled))
                        manager.EncompassSessionObjects.AclGroupManager.AddUserToGroupLoan(group.ID,member);
                }

                foreach (var orgMember in incomingGroup.AclGroupLoanMembers.OrgMembers)
                {
                    if (oldOrgToNewOrgIdMap.Any(x => x.Key == orgMember.OrgID))
                    {
                        var newId = oldOrgToNewOrgIdMap[orgMember.OrgID];
                        
                        manager.EncompassSessionObjects.AclGroupManager.AddOrgToGroupLoan(group.ID,new OrgInGroupLoan()
                        {
                            Access = orgMember.Access,
                            IsInclusive = orgMember.IsInclusive,
                            OrgName = orgMember.OrgName,
                            OrgID = newId
                        });
                    }
                }

                foreach (var userGroupMember in incomingGroup.AclUserGroupMembers)
                {
                    if (users.Any(x=>x.ID == userGroupMember && x.Enabled))
                        manager.EncompassSessionObjects.AclGroupManager.AddUserToGroup(group.ID, userGroupMember);
                }

                foreach (var groupMember in incomingGroup.AclOrgGroupMembers)
                {
                    if (oldOrgToNewOrgIdMap.ContainsKey(groupMember.OrgID))
                    {
                        var newId = oldOrgToNewOrgIdMap[groupMember.OrgID];
                        manager.EncompassSessionObjects.AclGroupManager.AddOrgToGroup(group.ID, newId, groupMember.IsInclusive);
                    }
                }
            }
        }
    }
    
    public class UserGroupExport
    {
        public string Name { get; set; }
        public AclGroupLoanMembers AclGroupLoanMembers { get; set; }
        public OrgInGroup[] AclOrgGroupMembers { get; set; }
        public string[] AclUserGroupMembers { get; set; }
    }
}