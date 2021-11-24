using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.ClientServer.Contacts;
using EllieMae.EMLite.ClientServer.Reporting;
using Newtonsoft.Json; 
//using EncompassSettings.Converters;

namespace EncompassSettings
{
    public static class Global
    {
        public static Dictionary<int, string> PersonaMap = new Dictionary<int, string>();
    }
    class Program
    {
        static void Main(string[] args)
        {
            new EllieMae.Encompass.Runtime.RuntimeServices().Initialize();
            BLAH.RUN();
        }
    }

    class BLAH
    {
        static JsonSerializerSettings settings = new JsonSerializerSettings();


        public static void RUN()
        {
            global::EncompassSettings.Converters.ConverterRegistry.Register(settings);

            //settings.Converters.Add(new BusinessRuleConverter());

            //Task.Run(async () =>
            //    await restTestAsync()
            //).Wait();
            //fix();
            //fixe1Test();
            fixnewPROD();
            //DBStuff();
            //EmailTest();
            //ExtractFields();
            //generateMERS();
            //fixblob();
            //jiraCreate();
            //EmailTest1();
            //FilewriteTest();
            //JSONTest();
            //quickTest();
            //ServiceBusStuff();
        }







        
        static void fixnewPROD()
        {
            EllieMae.Encompass.Client.Session session = new EllieMae.Encompass.Client.Session();
            session.Start(@"server", "user", "pass");
            //var ts = EllieMae.EMLite.RemotingServices.Sessions.GetSession("", true);
            //EllieMae.EMLite.Client.IConnection con = new Connection();
            //var startupInfo = con.Session.GetSessionStartupInfo();
            //Sessions.AddSession(ts, false);

            //OAuth2 oa = new OAuth2(Session.DefaultInstance.StartupInfo.OAPIGatewayBaseUri, Session.StartupInfo.SSFClientId, Session.StartupInfo.SSFClientSecret, new RetrySettings(Session.SessionObjects), CacheItemRetentionPolicy.NoRetention);
            //var auth = oa.GenerateGuestApplicationAuthCode(Session.DefaultInstance.ServerIdentity.InstanceName, Session.SessionObjects.SessionID,Session.CompanyInfo.ClientID);
            EllieMaeIdpClient emc = new EllieMaeIdpClient();
            var auth = emc.GetAuthCode("serverID", "user", "pass").GetAwaiter().GetResult();
            EllieMae.EMLite.RemotingServices.Session.Start(@"server", "user", "pass", "API-Tools", false, null, auth);
            var so = session.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "SessionObjects").GetValue(session) as SessionObjects;



            

            //File.WriteAllText("personaMap.json", JsonConvert.SerializeObject(personaMap));
            var personaMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(File.ReadAllText("personaMap.json"));










            //var identity = new EllieMae.EMLite.DataEngine.LoanIdentity("04f0f88c - 95e5 - 4274 - 83e4 - 59624e36b765");

            //so.LoanManager.OpenLoan(identity);
            //session.Loans.Open("{0e27ee61-7f09-4a20-b850-9049f154a364}");
            //var origFeeManagement = so.ConfigurationManager.GetFeeManagement();
            //using (StreamWriter sw = new StreamWriter("fees.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(origFeeManagement.GetAllFees()));
            //}
            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.Converters.Add(new StateLicenseExtTypeConverter());
            //settings.Converters.Add(new OrgConverter());


            //Dictionary<int, int> OldNewID = new Dictionary<int, int>();
            //List<OrgInfo> oldOrgs = JsonConvert.DeserializeObject<List<OrgInfo>>(File.ReadAllText("orgs.json"), settings);
            //List<OrgInfo> newOrgs = so.OrganizationManager.GetAllOrganizations().ToList();

            //foreach (var old in oldOrgs)
            //{
            //    var res = newOrgs.Where(x => x.OrgCode == old.OrgCode).ToList();
            //    if (res.Count != 1 && old.Oid > 0)
            //    {
            //        if (res.Count > 0)
            //        {
            //            var recheck = res.Where(c => c.OrgName == old.OrgName).ToList();
            //            if (recheck.Count == 1)
            //            {
            //                OldNewID.Add(old.Oid, recheck.First().Oid);
            //            }
            //            else if (recheck.Count > 0)
            //            {
            //                if (recheck.Count < 5)
            //                {
            //                    OldNewID.Add(old.Oid, recheck.First().Oid);
            //                }
            //                else
            //                {
            //                    recheck = res.Where(c => c.CompanyAddress.Street1 == old.CompanyAddress.Street1).ToList();
            //                    Console.WriteLine("ack");
            //                }
            //            }
            //            else
            //            {
            //                Console.WriteLine($"Cannot match old {old.Oid} {old.OrgName}");
            //                old.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Single(p => p.Name == "parent").SetValue(old, OldNewID[old.Parent]);
            //                var id = so.OrganizationManager.CreateOrganization(old);
            //                OldNewID.Add(old.Oid, id);
            //            }
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Cannot match old {old.Oid} {old.OrgName}");
            //            old.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance).Single(p => p.Name == "parent").SetValue(old, OldNewID[old.Parent]);
            //            var id = so.OrganizationManager.CreateOrganization(old);

            //            OldNewID.Add(old.Oid, id);
            //        }

            //    }
            //    else if (old.Oid == 0)
            //    {
            //        OldNewID.Add(old.Oid, 0);
            //    }
            //    else
            //    {
            //        OldNewID.Add(old.Oid, res.First().Oid);
            //    }

            //}
            //File.WriteAllText("oldnew.json", JsonConvert.SerializeObject(OldNewID));

            //var oldUsers = JsonConvert.DeserializeObject<List<UserInfo>>(File.ReadAllText("EnabledUsers.json"), settings);
            //var map = JsonConvert.DeserializeObject<Dictionary<int, int>>(File.ReadAllText("oldnew.json"));
            //var personas = so.PersonaManager.GetAllPersonas().ToList();
            //var currentUsers = so.OrganizationManager.GetAllUsers().ToList();
            //var oldGroups = JsonConvert.DeserializeObject<List<UserGroupExport>>(File.ReadAllText("UserGroup Export.json"),settings);
            //var allLoanFOlders = so.LoanManager.GetAllLoanFolderInfos(false, false);
            //var allRoles = ((WorkflowManager)Session.BPM.GetBpmManager(BpmCategory.Workflow)).GetAllRoleFunctions();
            //var allUsers = session.Users.GetAllUsers().Cast<EllieMae.Encompass.BusinessObjects.Users.User>();

            //foreach (var importGroup in oldGroups)
            //{
            //    var t = so.AclGroupManager.GetGroupByName(importGroup.Name);
            //    AclGroup group;
            //    if (t != null)
            //        continue;
            //    else
            //        group = so.AclGroupManager.CreateGroup(importGroup.Name);
            //    group.ViewSubordinatesContacts = false;
            //    so.AclGroupManager.UpdateGroup(group);
            //    foreach( RoleInfo allRoleFunction in allRoles)
            //    {
            //        so.AclGroupManager.UpdateAclGroupRoleAccessLevel(new AclGroupRoleAccessLevel(group.ID, allRoleFunction.RoleID, AclGroupRoleAccessEnum.BelowInOrg, true));
            //    }
            //    foreach (var user in importGroup.AclGroupLoanMembers.UserMembers)
            //    {
            //        if (allUsers.Any(x => x.ID == user.UserID && x.Enabled))
            //        {
            //            so.AclGroupManager.AddUserToGroupLoan(group.ID, user);
            //        }
            //    }

            //    foreach (var org in importGroup.AclGroupLoanMembers.OrgMembers)
            //    {
            //        if (map.Any(x => x.Key == org.OrgID))
            //        {
            //            var newId = map[org.OrgID];

            //            so.AclGroupManager.AddOrgToGroupLoan(group.ID, new OrgInGroupLoan()
            //            {
            //                Access = org.Access,
            //                IsInclusive = org.IsInclusive,
            //                OrgName = org.OrgName,
            //                OrgID = newId,
            //            });
            //        }
            //    }

            //    foreach (var user in importGroup.AclUserGroupMembers)
            //    {
            //        if (allUsers.Any(x => x.ID == user && x.Enabled))
            //        {
            //            so.AclGroupManager.AddUserToGroup(group.ID, user);
            //        }
            //    }

            //    foreach (var org in importGroup.AclOrgGroupMembers)
            //    {
            //        if (map.ContainsKey(org.OrgID))
            //        {
            //            var newId = map[org.OrgID];
            //            so.AclGroupManager.AddOrgToGroup(group.ID, newId, org.IsInclusive);
            //        }
            //    }
            //}

            //foreach (var disable in currentUsers)
            //{
            //    var u = session.Users.GetUser(disable.Userid);
            //    if (u.Enabled)
            //    {
            //        if (!oldUsers.Any(x=>x.Userid == u.ID))
            //        {
            //            u.Disable();
            //        }
            //    }
            //}


            //var lst = oldUsers.Where(x => !currentUsers.Any(y => y.Userid == x.Userid)).ToList();
            //foreach (var addUser in lst)
            //{
            //    Persona[] newP = new Persona[1];
            //    newP[0] = so.PersonaManager.GetPersonaByName("Every User");

            //    UserInfo newUser = new UserInfo(addUser.Userid, "Password1!", addUser.LastName, addUser.SuffixName, addUser.FirstName, addUser.MiddleName, addUser.EmployeeID,
            //        addUser.ProfileURL, newP, addUser.WorkingFolder, map[addUser.OrgId], false, addUser.AccessMode, addUser.Status, addUser.Email, addUser.Phone,
            //        addUser.CellPhone, addUser.Fax, false, true, false, addUser.PeerView, addUser.DataServicesOptOutKey, addUser.LegacyDelegateTasksRight, DateTime.MinValue, addUser.CHUMId,
            //        addUser.NMLSOriginatorID, addUser.NMLSExpirationDate, addUser.EncompassVersion, addUser.EmailSignature, addUser.PersonalStatusOnline, addUser.InheritParentCompPlan,
            //        addUser.ApiUser, addUser.OAuthClientId, addUser.AllowImpersonation, addUser.InheritParentCCSite);
            //    so.OrganizationManager.CreateNewUser(newUser);
            //    var user = session.Users.GetUser(newUser.Userid);
            //    Console.WriteLine(newUser.Userid);
            //    //user.Personas.Add(session.Users.Personas.GetPersonaByName("Every User"));
            //    var CurrentPersona = session.Users.Personas.Cast<EllieMae.Encompass.BusinessObjects.Users.Persona>().ToList();
            //    List<string> personaNames = new List<string>();
            //    personaNames.Add("Every User");
            //    foreach (var p in addUser.UserPersonas)
            //    {
            //        var oldPersonaName = p.Name;
            //        if (personaMap.ContainsKey(oldPersonaName))
            //        {
            //            if (personaMap[oldPersonaName] != "")
            //            {
            //                if (!personaNames.Contains(personaMap[oldPersonaName]))
            //                {
            //                    user.Personas.Add(CurrentPersona.Single(x=>x.Name ==personaMap[oldPersonaName]));
            //                    personaNames.Add(personaMap[oldPersonaName]);
            //                }
            //            }

            //        }
            //        else
            //        {
            //            if (!personaNames.Contains(p.Name))
            //            {
            //                user.Personas.Add(CurrentPersona.Single(x => x.Name == p.Name));
            //                personaNames.Add(p.Name);
            //            }
            //        }
            //    }
            //    user.Commit();


            //}

            //var fields = so.ConfigurationManager.GetLoanCustomFields().Cast<CustomFieldInfo>().ToList();
            //var fieldData = JsonConvert.DeserializeObject < List<de.CustomFieldInfo> > (File.ReadAllText("fields.json"),settings);
            //CustomFieldsInfo cfi = new CustomFieldsInfo(false);

            //foreach(var f in fieldData)
            //{
            //    cfi.Add(f);
            //}
            //so.ConfigurationManager.UpdateLoanCustomFields(cfi, false);

            //var jsonData = JsonConvert.SerializeObject(fieldData);
            //using (StreamWriter sw = new StreamWriter("fields.json"))
            //    sw.Write(jsonData);



            var contacts = JsonConvert.DeserializeObject<List<BizPartnerInfo>>(File.ReadAllText("contacts.json"));
            foreach (var c in contacts)
            {
                try
                {
                    so.ContactManager.CreateBizPartner(c);
                }
                catch
                { }
            }

            session.End();
        }

        static void fixe1Test()
        {
            EllieMae.Encompass.Client.Session session = new EllieMae.Encompass.Client.Session();
            session.Start(@"server", "user", "pass");
            EllieMae.EMLite.RemotingServices.Session.Start(@"server", "user", "pass", "Encompass", false);
            var so = session.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "SessionObjects").GetValue(session) as SessionObjects;
            var s = EllieMae.EMLite.RemotingServices.Session.DefaultInstance;
            //var identity = new EllieMae.EMLite.DataEngine.LoanIdentity("04f0f88c - 95e5 - 4274 - 83e4 - 59624e36b765");

            //so.LoanManager.OpenLoan(identity);
            var loan = session.Loans.Open("{317794db-c317-4007-b2d5-90c9bd8b96ee}");
            //loan.ForceLock();
            //C:\SmartClientCache\Apps\UAC\Ellie Mae\A#DkGCbu#+nkEVpfk0ToMIgKcr8=\Encompass360
            var dataMgr = (EllieMae.EMLite.DataEngine.LoanDataMgr)
                    loan.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .Single(pi => pi.Name == "dataMgr").GetValue(loan);
            var asm = Assembly.LoadFile(@"C:\Users\Jesse.Weinstock\Downloads\ePASS.Appraisal.PreferredAppraiser.dll");
            //var asm2 = Assembly.LoadFile(@"C:\SmartClientCache\Apps\UAC\Ellie Mae\hwV988goe69Au+JE3YZcq1THDOI=\Encompass360\EMePass.dll");
            var bamType = typeof(EllieMae.EMLite.ePass.Bam);
            var bam = Activator.CreateInstance(bamType, new object[] { null, dataMgr, dataMgr.LoanData });
            var OrderHistoryType = asm.GetTypes().First(x => x.Name == "OrderHistory");
            StringBuilder sb = new StringBuilder();
            foreach (var order in OrderHistoryType.GetProperty("GetHistory").GetValue(Activator.CreateInstance(OrderHistoryType, new object[] { bam, true })) as IEnumerable)
            {
                foreach (var his in order.GetType().GetField("History").GetValue(order) as IEnumerable)
                {
                    var value = his.GetType().GetField("Comments").GetValue(his);
                }
            }
            session.End();
        }
        static void fix()
        {
            EllieMae.Encompass.Client.Session session = new EllieMae.Encompass.Client.Session();
            session.Start(@"server", "user", "pass");
            //EllieMae.EMLite.RemotingServices.Session.Start(@"server", "user", "pass", "AdminTools", false);
            var so = session.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "SessionObjects").GetValue(session) as SessionObjects;
            //var s = EllieMae.EMLite.RemotingServices.Session.DefaultInstance;

            //var identity = new EllieMae.EMLite.DataEngine.LoanIdentity("04f0f88c - 95e5 - 4274 - 83e4 - 59624e36b765");

            //so.LoanManager.OpenLoan(identity);
            //var l = session.Loans.Open("{93281470-3a86-4334-821e-b370dd098030}");
            //var res  = EllieMae.EMLite.RemotingServices.SystemSettings.AllFolders;
            //var so = session.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "SessionObjects").GetValue(session) as SessionObjects;
            //var orgs = so.OrganizationManager.GetAllOrganizations();

            //foreach (var org in orgs.Where(x=>x.OrgBranchLicensing.StatutoryElectionInMaryland == false))
            //{
            //    //org.OrgBranchLicensing.StatutoryElectionInKansas = true;
            //    org.OrgBranchLicensing.StatutoryElectionInMaryland = true;
            //    so.OrganizationManager.UpdateOrganization(org);
            //}
            //var users = so.OrganizationManager.GetAllUsers();
            //var results = users.Select(x => getUserMap(x)).ToList();
            //using (StreamWriter sw = new StreamWriter("users.txt")) sw.Write(JsonConvert.SerializeObject(results));

            //var loan = session.Loans.Open("{80e723ed-edc9-40a8-8f8c-4ad7ce0d8236}");
            //loan.Lock(true);
            //loan.Fields["CX.ZERO.APPROVEDPROGRAM"].Value = "Y";
            //loan.Commit();
            //var so = session.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "SessionObjects").GetValue(session) as SessionObjects;
            //EllieMae.EMLite.RemotingServices.Session.Start(@"server", "user", "pass", "AdminTools", false);

            //var fields = so.ConfigurationManager.GetLoanCustomFields();
            //var fieldData = fields.Cast<de.CustomFieldInfo>().ToList();

            //var jsonData = JsonConvert.SerializeObject(fieldData);
            //using (StreamWriter sw = new StreamWriter("fields.json"))
            //    sw.Write(jsonData);
            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.Converters.Add(new JConverter());

            ////var existingFields = so.ConfigurationManager.GetLoanCustomFields().Cast<de.CustomFieldInfo>();
            ////var existingFieldIDs = existingFields.Select(s => s.FieldID).ToList();

            //using (StreamReader sr = new StreamReader("tasks.json"))
            //{
            //    var taskList = JsonConvert.DeserializeObject<Dictionary<Guid, MilestoneTaskDefinition>>(sr.ReadToEnd(),settings);
            //    foreach (var task in taskList)
            //    {
            //        if (existingFieldIDs.Contains( field.FieldID ))
            //        {
            //            if (existingFields.First(x=>x.FieldID == field.FieldID).Format != EllieMae.EMLite.Common.FieldFormat.X)
            //            {
            //                continue;
            //            }
            //        }
            //        so.ConfigurationManager.UpdateLoanCustomField(field);
            //    }
            //}


            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.Converters.Add(new TaskConverter());

            ////var existingFields = so.ConfigurationManager.GetLoanCustomFields().Cast<de.CustomFieldInfo>();
            ////var existingFieldIDs = existingFields.Select(s => s.FieldID).ToList();

            //using (StreamReader sr = new StreamReader("tasks.json"))
            //{
            //    var taskList = JsonConvert.DeserializeObject<Dictionary<Guid, MilestoneTaskDefinition>>(sr.ReadToEnd(), settings);
            //    foreach (var task in taskList)
            //    {


            //        so.ConfigurationManager.AddMilestoneTask(task.Value);

            //    }
            //}

            //var activateList = so.BpmManager.GetRules(BizRuleType.MilestoneRules).ToList().Where(x=>x.Inactive).ToList();
            //var activateList = rulelist.Where(x => x.Inactive && x.LastModifiedByUserId == "jweinstock" && x.LastModTime > DateTime.Parse("7/25/2020")).ToList();
            //foreach (var rule in activateList)
            //    so.BpmManager.ActivateRule(rule.RuleType, rule.RuleID);
            //var personaList = so.PersonaManager.GetAllPersonas().ToList();


            //PipelineViewAclManager mgr = (PipelineViewAclManager)so.Session.GetAclManager(AclCategory.PersonaPipelineView);
            //foreach (var persona in personaList)
            //{
            //    var viewList = mgr.GetPersonaPipelineViews(persona.ID).ToList();
            //    //mgr.
            //}

            //List<LoanXDBField> fields = null;

            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.Converters.Add(new xdbConverter());

            //using (StreamReader sr = new StreamReader("test.json"))
            //{
            //    fields = JsonConvert.DeserializeObject<List<LoanXDBField>>(sr.ReadToEnd(), settings);
            //}

            //var existingFields = so.LoanManager.GetLoanXDBTableList(false);
            //var exFieldName = existingFields.GetAllFields().Select(s => s.FieldID).ToList();
            //var status = so.LoanManager.GetLoanXDBStatus(false);

            //var addList = fields.Where(x => !existingFields.GetAllFields().Any(y => y.FieldID == x.FieldID && y.ComortgagorPair == x.ComortgagorPair)).ToList();

            //foreach (var a in fields)
            //{
            //    if (existingFields.GetAllFields().Any(y => y.FieldID == a.FieldID && y.ComortgagorPair == a.ComortgagorPair))
            //    {
            //        existingFields.AddUpdateList(new LoanXDBField(a), LoanXDBField.FieldStatus.Updated);
            //    }
            //    else
            //    {
            //        var newField = new LoanXDBField(a);
            //        newField.Auditable = a.Auditable;
            //        newField.TableName = string.Empty;
            //        existingFields.AddUpdateList(newField, LoanXDBField.FieldStatus.New);
            //    }

            //}

            //existingFields.UpdateTable();


            //so.LoanManager.RebuildReportingDb(false, true, (IServerProgressFeedback2)feedback)
            //status = so.LoanManager.GetLoanXDBStatus(false);

            //using (StreamWriter sw = new StreamWriter("personaNEW.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(so.PersonaManager.GetAllPersonas()));
            //}


            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.Converters.Add(new personaPipelineViewConverter());



            //PipelineViewAclManager mgr = (PipelineViewAclManager)s.ACL.GetAclManager(AclCategory.PersonaPipelineView);
            //var fileList = Directory.GetFiles("pipelineViews\\");
            //foreach (var filename in fileList.Where(x=>x.Contains("Servicer")))
            //    using (StreamReader sr = new StreamReader(filename))
            //    {

            //        var viewList = JsonConvert.DeserializeObject<List<PersonaPipelineView>>(sr.ReadToEnd(), settings);
            //        if (viewList != null)
            //            foreach (var view in viewList)
            //            {
            //                if (view != null)
            //                    if (!mgr.GetPersonaPipelineViews(view.PersonaID).Any(x => x.Name == view.Name))
            //                        mgr.CreatePipelineView(view);
            //            }
            //    }

            //PipelineViewAclManager mgr = (PipelineViewAclManager)s.ACL.GetAclManager(AclCategory.PersonaPipelineView);
            //var fileList = Directory.GetFiles("pipelineViews\\");
            //foreach (var filename in fileList.Where(x=>x.Contains("Processing Manager")))
            //    using (StreamReader sr = new StreamReader(filename))
            //    {

            //        var viewList = JsonConvert.DeserializeObject<List<PersonaPipelineView>>(sr.ReadToEnd(), settings);
            //        if (viewList != null)
            //            foreach (var view in viewList.Where(x=>x != null))
            //            {

            //                if (!mgr.GetPersonaPipelineViews(view.PersonaID).Any(x => x.Name == view.Name))
            //                    mgr.CreatePipelineView(view);
            //                else
            //                {
            //                    var updateView = mgr.GetPersonaPipelineView(view.PersonaID, view.Name);
            //                    updateView.Columns.Clear();
            //                    updateView.Columns.AddRange(view.Columns.ToArray());
            //                    updateView.Filter = view.Filter;
            //                    mgr.UpdatePipelineView(updateView);
            //                }
            //            }
            //    }

            //using (StreamReader sr = new StreamReader("investors.json"))
            //{
            //    var investors = JsonConvert.DeserializeObject<Dictionary<string,BinaryObject>>(sr.ReadToEnd());
            //    foreach (var inv in investors)
            //    {
            //        so.ConfigurationManager.SaveTemplateSettings(TemplateSettingsType.Investor, new FileSystemEntry(FileSystemEntry.PublicRoot.Path, inv.Key, FileSystemEntry.Types.File, null), inv.Value);
            //    }
            //}

            //using (StreamReader sr = new StreamReader("srp.json"))
            //{
            //    var investors = JsonConvert.DeserializeObject<Dictionary<string, BinaryObject>>(sr.ReadToEnd());
            //    foreach (var inv in investors)
            //    {
            //        so.ConfigurationManager.SaveTemplateSettings(TemplateSettingsType.SRPTable, new FileSystemEntry(FileSystemEntry.PublicRoot.Path, inv.Key, FileSystemEntry.Types.File, null), inv.Value);
            //    }
            //}

            //JsonSerializerSettings settings = new JsonSerializerSettings();
            //settings.Converters.Add(new DocumentTemplateConverter());

            //using (StreamReader sr = new StreamReader("Docs.json"))
            //{
            //    var newsystem = so.ConfigurationManager.GetDocumentTrackingSetup();
            //    var oldSystem = JsonConvert.DeserializeObject<List<DocumentTemplate>>(sr.ReadToEnd(),settings);
            //    //var addList = new DocumentTrackingSetup();
            //    foreach (var doc in oldSystem)
            //    {
            //        if (!newsystem.dictDocTrackByName.ContainsKey(doc.Name))
            //        {

            //            newsystem.dictDocTrackByName.Add(doc.Name, doc);
            //        }
            //    }
            //    so.ConfigurationManager.SaveDocumentTrackingSetup(newsystem);
            //}
            //var list = so.ConfigurationManager.GetAllPublicTemplateSettingsFileEntries(TemplateSettingsType.StackingOrder, true);

            //Dictionary<FileSystemEntry, StackingOrderSetTemplate> data = new Dictionary<FileSystemEntry, StackingOrderSetTemplate>();
            //foreach (var f in list)
            //{
            //    var item = (StackingOrderSetTemplate)so.ConfigurationManager.GetTemplateSettings(TemplateSettingsType.StackingOrder, f);
            //    data.Add(f, item);
            //}
            //Dictionary<string, StackingOrderSetTemplate> prodData;
            //using (StreamReader sr = new StreamReader("stacking.json"))
            //{
            //    prodData = JsonConvert.DeserializeObject<Dictionary<string, StackingOrderSetTemplate>>(sr.ReadToEnd());
            //}

            //foreach (var item in data)
            //{
            //    var pItem = prodData.Single(x => x.Key == item.Key.Name);
            //    var addList = pItem.Value.DocNames.ToArray().Except(item.Value.DocNames.ToArray());
            //    foreach (var p in addList)
            //        item.Value.DocNames.Add(p);

            //    //IXmlSerializable serItem = item.Value;

            //    //myXmlSerializationInfo info = new myXmlSerializationInfo();
            //    //info.AddValue("root", serItem);

            //    //var ser = new XmlSerializer().Serialize(item.Value as IXmlSerializable);
            //    //var obj = new BinaryObject(ser, Encoding.Default);
            //    s.ConfigurationManager.SaveTemplateSettings(TemplateSettingsType.StackingOrder, item.Key, item.Value);

            //}

            //var ifsExplorer = new TemplateIFSExplorer(s, TemplateSettingsType.StackingOrder);
            //ifsExplorer.Init(FileSystemEntry.PublicRoot, true);

            //foreach (var pItem in prodData.Where(x=>!data.Keys.Select(y=>y.Name).ToList().Contains(x.Key)))
            //{
            //    var entry = ifsExplorer.AddEntry(true);
            //    entry = ifsExplorer.Rename(entry, entry.Name, pItem.Key);

            //    var newEntry = (StackingOrderSetTemplate)so.ConfigurationManager.GetTemplateSettings(TemplateSettingsType.StackingOrder, entry);
            //    newEntry.AutoSelectDocuments = pItem.Value.AutoSelectDocuments;
            //    newEntry.Description = pItem.Value.Description;
            //    newEntry.DocNames.AddRange(pItem.Value.DocNames);
            //    newEntry.FilterDocuments = pItem.Value.FilterDocuments;
            //    newEntry.NDEDocGroups.AddRange(pItem.Value.NDEDocGroups);
            //    newEntry.TemplateName = entry.Name;
            //    newEntry.IsDefault = false;

            //    so.ConfigurationManager.SaveTemplateSettings(TemplateSettingsType.StackingOrder, entry, (BinaryObject)(BinaryConvertibleObject)newEntry);
            //}

            //using (StreamReader sr = new StreamReader("fees.json"))
            //{
            //    List<FeeManagementRecord> fees = JsonConvert.DeserializeObject<List<FeeManagementRecord>>(sr.ReadToEnd());
            //    var origFeeManagement = so.ConfigurationManager.GetFeeManagement();
            //    //var currentFees = origFeeManagement.GetAllFees().ToList();


            //    FeeManagementSetting feeManagementSetting = new FeeManagementSetting();
            //    foreach (var newFee in fees)
            //    {
            //        feeManagementSetting.AddFee(newFee);

            //    }
            //    feeManagementSetting.CompanyOptIn = true;
            //    so.ConfigurationManager.UpdateFeeManagement(feeManagementSetting);

            //}

            //using (StreamReader sr = new StreamReader("piggy.json"))
            //{
            //    List<string> fields = JsonConvert.DeserializeObject<List<string>>(sr.ReadToEnd());
            //    PiggybackFields pf = (PiggybackFields)s.GetSystemSettings(typeof(PiggybackFields));
            //    var Remove = pf.GetSyncFields().Except(fields).ToList();
            //    foreach (var r in Remove)
            //        pf.RemoveField(r);
            //    pf.AddField("VOD");
            //    pf.AddField("VOE");
            //    pf.AddField("VOLVOM");
            //    pf.AddField("VOR");

            //    s.SaveSystemSettings(pf);
            //}



            //Contacts
            //FieldFilterList filter = new FieldFilterList();
            //List<EllieMae.EMLite.ClientServer.Query.QueryCriterion> qcList = new List<EllieMae.EMLite.ClientServer.Query.QueryCriterion>();
            //qcList.Add(filter.CreateEvaluator().ToQueryCriterion());
            //var curs = so.ContactManager.OpenBorrowerCursor(qcList.ToArray(),EllieMae.EMLite.ClientServer.Contacts.RelatedLoanMatchType.None,new List<SortField>().ToArray(), new List<string>().ToArray(), true);
            //var count = curs.GetItemCount();
            //var list = curs.GetItems(0, count);
            //curs.Dispose();
            //curs = null;

            //var newCurs = so.ContactManager.OpenBizPartnerCursor(qcList.ToArray(), EllieMae.EMLite.ClientServer.Contacts.RelatedLoanMatchType.None, null, null, true);
            //count = newCurs.GetItemCount();
            //list = newCurs.GetItems(0, count);
            //newCurs.Dispose();
            //newCurs = null;
            //using (StreamReader sr = new StreamReader("guidlist.txt"))
            //{
            //    while (!sr.EndOfStream)
            //    {
            //        var guid = sr.ReadLine();
            //        //var l = session.Loans.Open(guid);
            //        //l.ForceUnlock();
            //        session.Loans.Delete(guid);
            //    }
            //}



            //var fields = so.ConfigurationManager.GetLoanCustomFields();
            //var fieldData = fields.Cast<de.CustomFieldInfo>().ToList();

            //var jsonData = JsonConvert.SerializeObject(fieldData);
            //using (StreamWriter sw = new StreamWriter("fields.json"))
            //    sw.Write(jsonData);


            foreach (var p in so.PersonaManager.GetAllPersonas())
            {
                Global.PersonaMap.Add(p.ID, p.Name);
            }
            var typ = BizRuleType.FieldRules;
            var rules = so.BpmManager.GetRules().Cast<BizRuleInfo>().Where(x => !x.Inactive).ToList();
            File.WriteAllText($"rules.json", JsonConvert.SerializeObject(rules, settings));


            session.End();
        }
        private static IServerProgressFeedback2 feedback;

        public static KeyValuePair<string, int> getUserMap(EllieMae.EMLite.RemotingServices.UserInfo user)
        {
            var id = user.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "Id").GetValue(user) as int?;
            return new KeyValuePair<string, int>(user.Userid, id ?? 0);
        }


    public class UserGroupExport
    {
        public string Name { get; set; }
        public AclGroupLoanMembers AclGroupLoanMembers { get; set; }
        public OrgInGroup[] AclOrgGroupMembers { get; set; }
        public string[] AclUserGroupMembers { get; set; }
    }
}