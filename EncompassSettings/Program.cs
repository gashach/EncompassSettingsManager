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
            //fixPROD();
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





        static void fixPROD()
        {
            EncompassSessionManager eSession = new EncompassSessionManager("", "", "");


            //var orgs = so.OrganizationManager.GetAllOrganizations();

            //foreach (var org in orgs.Where(x=>x.OrgBranchLicensing.StatutoryElectionInMaryland == false))
            //{
            //    //org.OrgBranchLicensing.StatutoryElectionInKansas = true;
            //    org.OrgBranchLicensing.StatutoryElectionInMaryland = true;
            //    so.OrganizationManager.UpdateOrganization(org);
            //}
            //var users = so.OrganizationManager.GetAllUsers();
            //var results = users.Where(x=>session.Users.GetUser(x.Userid).Enabled).ToList();
            //using (StreamWriter sw = new StreamWriter("Enabledusers.json")) sw.Write(JsonConvert.SerializeObject(results));

            //var loan = session.Loans.Open("{80e723ed-edc9-40a8-8f8c-4ad7ce0d8236}");
            //loan.Lock(true);
            //loan.Fields["CX.ZERO.APPROVEDPROGRAM"].Value = "Y";
            //loan.Commit();
            //var so = session.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Single(pi => pi.Name == "SessionObjects").GetValue(session) as SessionObjects;


            //var fields = so.ConfigurationManager.GetLoanCustomFields();
            //var fieldData = fields.Cast<de.CustomFieldInfo>().ToList();

            //var jsonData = JsonConvert.SerializeObject(fieldData);
            //using (StreamWriter sw = new StreamWriter("fields.json"))
            //    sw.Write(jsonData);

            //var fields = so.ConfigurationManager.GetMilestoneTasks();
            ////var fieldData = fields.Cast<MilestoneTaskDefinition>().ToList();

            //var jsonData = JsonConvert.SerializeObject(fields);
            //using (StreamWriter sw = new StreamWriter("tasks.json"))
            //    sw.Write(jsonData);

            //var personaList = so.PersonaManager.GetAllPersonas().ToList();
            //var personaList = so.PersonaManager.GetAllPersonas().ToList().Where(x => x.Name == "Servicer").ToList();


            //PipelineViewAclManager mgr = (PipelineViewAclManager)s.ACL.GetAclManager(AclCategory.PersonaPipelineView);
            //foreach (var persona in personaList)
            //{
            //    var viewList = mgr.GetPersonaPipelineViews(persona.ID).ToList();
            //    using (StreamWriter sw = new StreamWriter(persona.Name.Replace("/", "-")))
            //    {
            //        sw.Write(JsonConvert.SerializeObject(viewList));
            //    }
            //}



            //HttpResponseMessage result = RestApiProxyFactory.CreateOsbHttpClientProxy(
            //    so.StartupInfo.ServerInstanceName + "_" + so.StartupInfo.SessionID)
            //    .GetAsync(GetExportURL(BizRuleType.Triggers,5434)).GetAwaiter().GetResult();
            //if (result.IsSuccessStatusCode)
            //{
            //    using (StreamWriter sw = new StreamWriter("test.xml"))
            //        sw.Write(XElement.Load((XmlReader)JsonReaderWriterFactory.CreateJsonReader(Encoding.UTF8.GetBytes(result.Content.ReadAsStringAsync().GetAwaiter().GetResult()), new XmlDictionaryReaderQuotas())).Value);
            //}

            //var xdblist = so.LoanManager.GetLoanXDBTableList(false).GetTableFields().ToList();
            //using (StreamWriter sw = new StreamWriter("test.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(xdblist));
            //}
            //Dictionary<SecondaryFieldTypes, ArrayList> secondary = new Dictionary<SecondaryFieldTypes, ArrayList>();
            //secondary[SecondaryFieldTypes.BaseRate] = so.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BaseRate);
            //secondary[SecondaryFieldTypes.BaseMargin] = so.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BaseMargin);
            //secondary[SecondaryFieldTypes.BasePrice] = so.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BasePrice);
            //secondary[SecondaryFieldTypes.ProfitabilityOption] = so.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.ProfitabilityOption);
            //secondary[SecondaryFieldTypes.LockTypeOption] = so.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.LockTypeOption);

            //using (StreamWriter sw = new StreamWriter("secondary.json"))
            //    sw.Write(JsonConvert.SerializeObject(secondary));
            //var list = so.ConfigurationManager.GetSecondaryFields(SecondaryFieldTypes.BaseRate);

            //using (StreamWriter sw = new StreamWriter("persona.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(so.PersonaManager.GetAllPersonas()));
            //}
            
            
            //var list = so.ConfigurationManager.GetAllPublicTemplateSettingsFileEntries(TemplateSettingsType.SRPTable, true);

            //Dictionary<string,BinaryObject> investorData = new Dictionary<string, BinaryObject>();
            //foreach (var f in list)
            //{
            //    var t = so.ConfigurationManager.GetTemplateSettings(TemplateSettingsType.SRPTable, f);
            //    if (t != null)
            //        investorData.Add(f.Name,t);
            //}

            //using (StreamWriter sw = new StreamWriter("srp.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(investorData));
            //}

            //var docsetup = so.ConfigurationManager.GetDocumentTrackingSetup();
            //using (StreamWriter sw = new StreamWriter("Docs.json"))
            //    sw.Write(JsonConvert.SerializeObject(docsetup));

            
            
            
            //var list = so.ConfigurationManager.GetAllPublicTemplateSettingsFileEntries(TemplateSettingsType.FormList, true);

            //Dictionary<string, StackingOrderSetTemplate> data = new Dictionary<string, StackingOrderSetTemplate>();
            //foreach (var f in list)
            //{
            //    var item = (StackingOrderSetTemplate)so.ConfigurationManager.GetTemplateSettings(TemplateSettingsType.StackingOrder, f);
            //    data.Add(f.Name, item);
            //}
            //using (StreamWriter sw = new StreamWriter("stacking.json"))
            //    sw.Write(JsonConvert.SerializeObject(data));


            //var origFeeManagement = so.ConfigurationManager.GetFeeManagement();
            //using (StreamWriter sw = new StreamWriter("fees.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(origFeeManagement.GetAllFees()));
            //}
            //List<string> filterFields = new List<string>();
            //List<string> outputFields = new List<string>();
            //var reportDirList = so.ReportManager.GetAllPublicReportDirEntries().ToList();
            //var reportList = reportDirList.Where(r => r.Path.Contains("REPORTS TO TRANSFER TO ODS") && r.Type == FileSystemEntry.Types.File).ToList();
            //foreach ( var report in reportList)
            //{
            //    var rpt = report;
            //    if (report.Path.Contains("%2A"))
            //    {
            //        rpt = new FileSystemEntry(report.ParentFolder.Path.Replace("%2A", "*"), report.Name, report.Type, report.Owner);
            //    }
            //    var settings = so.ReportManager.GetReportSettings(rpt);
            //    outputFields.AddRange(settings.Columns.Select(x => x.FieldID).Distinct().ToList());
            //    filterFields.AddRange(settings.Filters.Select(x => x.FieldID).Distinct().ToList());
            //}
            //using (StreamWriter sw = new StreamWriter("Reportfields.txt"))
            //{
            //    sw.WriteLine(string.Join(Environment.NewLine, outputFields.Where(x=>!x.StartsWith("ExcelField")).Distinct()));
            //    sw.WriteLine("--------------------------------------");
            //    sw.WriteLine(string.Join(Environment.NewLine, filterFields.Distinct()));
            //}


            //PiggybackFields pf = (PiggybackFields)s.GetSystemSettings(typeof(PiggybackFields));
            //using (StreamWriter sw = new StreamWriter("piggy.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(pf.GetSyncFields()));
            //}

            //var sync = so.ConfigurationManager.GetAllSyncTemplates();
            //using (StreamWriter sw = new StreamWriter("sync.json"))
            //{
            //    sw.Write(JsonConvert.SerializeObject(sync[0].GetSyncFields(true)));
            //}

            //var list = s.ReportManager.GetReportDirEntries(FileSystemEntry.PrivateRoot("aard"));
            //var rpt = so.ReportManager.GetReportSettings(list[0]);

            //so.ContactManager

            //TemplateIFSExplorer templateIfsExplorer = new TemplateIFSExplorer(s,TemplateSettingsType.FormList);
            //var files = templateIfsExplorer.GetFileSystemEntries(FileSystemEntry.PublicRoot);
            //var rules = new List<iFormTemplate>();
            //foreach (var file in files.Where(x=>x.Type == FileSystemEntry.Types.File))
            //{

            //    var t = (FormTemplate)s.ConfigurationManager.GetTemplateSettings(TemplateSettingsType.FormList, file);
            //    rules.Add(new iFormTemplate()
            //    { name = t.TemplateName,
            //    description = t.Description,
            //    FormsList = t.GetFormNames()});
            //}
            //using (StreamWriter sw = new StreamWriter("forms.json"))
            //    sw.Write(JsonConvert.SerializeObject(rules));

            //var orgs = s.OrganizationManager.GetAllOrganizations();
            //File.WriteAllText("orgs.json", JsonConvert.SerializeObject(orgs), Encoding.UTF8);


            FieldFilterList filter = new FieldFilterList();
            List<EllieMae.EMLite.ClientServer.Query.QueryCriterion> qcList = new List<EllieMae.EMLite.ClientServer.Query.QueryCriterion>();
            qcList.Add(filter.CreateEvaluator().ToQueryCriterion());
            //var curs = so.ContactManager.OpenBorrowerCursor(qcList.ToArray(), EllieMae.EMLite.ClientServer.Contacts.RelatedLoanMatchType.None, new List<EllieMae.EMLite.ClientServer.Query.SortField>().ToArray(), new List<string>().ToArray(), true);
            //var count = curs.GetItemCount();
            //var list = curs.GetItems(0, count);
            //curs.Dispose();
            //curs = null;

            var newCurs = so.ContactManager.OpenBizPartnerCursor(qcList.ToArray(), EllieMae.EMLite.ClientServer.Contacts.RelatedLoanMatchType.None, null, null, true);
            var count = newCurs.GetItemCount();
            var list = newCurs.GetItems(0, count).Cast<BizPartnerSummaryInfo>().ToList();

            //foreach (var i in list)
            //{
            var tlist = so.ContactManager.GetBizPartners(list.Select(x => x.ContactID).ToArray());
            //}

            File.WriteAllText("contacts.json", JsonConvert.SerializeObject(tlist));

            newCurs.Dispose();
            newCurs = null;

            session.End();
        }
        class iFormTemplate
        {
            public string name { get; set; }
            public string description { get; set; }
            public string[] FormsList { get; set; }
        }
        private static string GetExportURL(BizRuleType t, int Id, string format = "xml")
        {
            string prefix = null;
            format = string.Format("?format={0}", format);

            switch (t)
            {
                case BizRuleType.AutoLockExclusionRules:
                    prefix = "/autolockexclusionrules/";
                    break;
                case BizRuleType.AutomatedConditions:
                    prefix = "/automatedconditions/";
                    break;
                case BizRuleType.FieldAccess:
                    prefix = "/personaaccesstofields/";
                    break;
                case BizRuleType.FieldRules:
                    prefix = "/fieldrules/";
                    break;
                case BizRuleType.InputForms:
                    prefix = "/inputformlist/";
                    break;
                case BizRuleType.LoanAccess:
                    prefix = "/personaaccesstoloans/";
                    break;
                case BizRuleType.LoanActionAccess:
                    prefix = "/PersonaAccessToLoanActions/";
                    break;
                case BizRuleType.MilestoneRules:
                    prefix = "/milestonecompletions/";
                    break;
                case BizRuleType.PrintForms:
                    prefix = "/LoanFormPrinting/";
                    break;
                case BizRuleType.PrintSelection:
                    prefix = "/printautoselection/";
                    break;
                case BizRuleType.Triggers:
                    prefix = "/fieldtriggers/";
                    break;
            }

            return !string.IsNullOrWhiteSpace(prefix) ? prefix + Id + format : null;
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



            //Dictionary<string, string> personaMap = new Dictionary<string, string>();
            //personaMap.Add("Account Executive", "Addon - Account Executive");
            //personaMap.Add("Accounting", "Accounting");
            //personaMap.Add("Addon - 14 Day Close", "Area Production Manager");
            //personaMap.Add("Addon - Agency Number Access","");
            //personaMap.Add("Addon - Alerts Closing Docs", "Addon - Alerts General");

            //personaMap.Add("Addon - Alerts eDisclosures", "Addon - Alerts General");
            //personaMap.Add("Addon - Alerts General", "Addon - Alerts General");
            //personaMap.Add("Addon - Allow Fraud Service Prior to App", "");
            //personaMap.Add("Addon - Appraisal Ordering", "Addon - Appraisal Ordering");
            //personaMap.Add("Addon - Broker Desk", "Addon - Broker Desk");

            //personaMap.Add("Addon - Business Analyst", "");
            //personaMap.Add("Addon - CalHFA High Balance", "");
            //personaMap.Add("Addon - CD Overrides", "");
            //personaMap.Add("Addon - Credit Policy Manager", "Underwriting Manager");
            //personaMap.Add("Addon - Cure Approver", "");

            //personaMap.Add("Addon - Curtailed & Repurchased", "Addon - Curtailed & Repurchased");
            //personaMap.Add("Addon - Dry State AUS", "Addon - Dry State AUS");
            //personaMap.Add("Addon - Easy OTC Approved", "Addon - Easy OTC Approved");
            //personaMap.Add("Addon - Easy OTC Manager", "Addon - Easy OTC Reviewer");
            //personaMap.Add("Addon - Easy OTC Reviewer", "Addon - Easy OTC Reviewer");

            //personaMap.Add("Addon - Fee Manual Overrides", "Addon - Fee Manual Overrides");
            //personaMap.Add("Addon - Fee Programmatic Overrides", "Addon - Fee Programmatic Overrides");
            //personaMap.Add("Addon - Fee360 - All Manual Overrides - 1100", "Addon - Fee360 - All Manual Overrides");
            //personaMap.Add("Addon - Fee360 - All Manual Overrides - 1200", "Addon - Fee360 - All Manual Overrides");
            //personaMap.Add("Addon - Fee360 - All Manual Overrides - 1300", "Addon - Fee360 - All Manual Overrides");

            //personaMap.Add("Addon - Fee360 - Beta", "");
            //personaMap.Add("Addon - Fee360 - Manual Overrides - 1100", "Addon - Fee360 - Manual Overrides");
            //personaMap.Add("Addon - Fee360 - Manual Overrides - 1200", "Addon - Fee360 - Manual Overrides - 1200");
            //personaMap.Add("Addon - Fee360 - Manual Overrides - 1300", "Addon - Fee360 - Manual Overrides");
            //personaMap.Add("Addon - Fee360 - Manual Overrides - 800", "Addon - Fee360 - Manual Overrides - 800");

            //personaMap.Add("Addon - Fee360 - Programmatic Overrides - 1100", "Addon - Fee Programmatic Overrides");
            //personaMap.Add("Addon - Fee360 - Programmatic Overrides - 1200", "Addon - Fee Programmatic Overrides");
            //personaMap.Add("Addon - Fee360 - Programmatic Overrides - 1300", "Addon - Fee Programmatic Overrides");
            //personaMap.Add("Addon - Fee360 - Programmatic Overrides - 800", "Addon - Fee Programmatic Overrides");
            //personaMap.Add("Addon - Fee360 - Seller Toggle - 1100", "Addon - Fee360 - Manual Overrides");

            //personaMap.Add("Addon - Fee360 - Seller Toggle - 1200", "Addon - Fee360 - Manual Overrides - 1200");
            //personaMap.Add("Addon - Fee360 - Seller Toggle - 1300", "Addon - Fee360 - Manual Overrides");
            //personaMap.Add("Addon - Fee360 - Seller Toggle - 800", "Addon - Fee360 - Seller Toggle - 800");
            //personaMap.Add("Addon - Fees360 - Transfer Tax Access", "");
            //personaMap.Add("Addon - FHA Override", "Addon - Alerts General");

            //personaMap.Add("Addon - FHA/VA Seasoning", "Addon - FHA/VA Seasoning");
            //personaMap.Add("Addon - Flood Vendor Override", "");
            //personaMap.Add("Addon - GBC 2nd State Approved", "");
            //personaMap.Add("Addon - ILA Sales Manager", "Addon - Sales Manager - ILA");
            //personaMap.Add("Addon - Income Review LO Assigner", "Addon - LaunchLab");

            //personaMap.Add("Addon - Income Reviewer", "Addon - Income Reviewer");
            //personaMap.Add("Addon - Initial Disclosures", "Addon - Disclosure - Initial");
            //personaMap.Add("Addon - Jet Restriction", "");
            //personaMap.Add("Addon - LaunchLab", "Addon - LaunchLab");
            //personaMap.Add("Addon - Licensing", "Licensing");

            //personaMap.Add("Addon - LO Prequal ILA", "Addon - LO Prequal ILA");
            //personaMap.Add("Addon - Loan Boarding", "Servicer");
            //personaMap.Add("Addon - Mavent Findings Override", "");
            //personaMap.Add("Addon - Non-UCD Completed Edit", "Addon - Non-UCD Completed Edit");
            //personaMap.Add("Addon - Org/User Info", "");

            //personaMap.Add("Addon - PipelineView Testing", "Addon - PipelineView Testing");
            //personaMap.Add("Addon - Post Purchase Indicator", "Shipper");
            //personaMap.Add("Addon - QC Audit Critical", "");
            //personaMap.Add("Addon - Renovations", "Addon - Renovations");
            //personaMap.Add("Addon - Revised Disclosures", "Addon - Disclosure - Revised");

            //personaMap.Add("Addon - Rush", "Addon - Rush");
            //personaMap.Add("Addon - Rush Fee Override", "Addon - Fee360 - Manual Overrides - 800");
            //personaMap.Add("Addon - Save Team", "Addon - Save Team");
            //personaMap.Add("Addon - Session Restriction", "Addon - Session Restriction");
            //personaMap.Add("Addon - SM Edit After Processing", "");

            //personaMap.Add("Addon - VAFF Override", "");
            //personaMap.Add("Addon - Vendee", "");
            //personaMap.Add("Addon - Vendee - Deselect Docs", "");
            //personaMap.Add("Addon - Vendee Mavent Override", "");
            //personaMap.Add("Addon - VIP Processor Access", "");

            //personaMap.Add("Admin - TPO", "TPO Administrator");
            //personaMap.Add("Branch Manager", "Sales Manager");
            //personaMap.Add("Closer", "Funder");
            //personaMap.Add("Closing Manager", "Funding Manager");
            //personaMap.Add("Docs - Closing", "Addon - Docs - Closing");

            //personaMap.Add("Docs - PreClosing", "Addon - Docs - PreClosing");
            //personaMap.Add("EssentNoMI", "");
            //personaMap.Add("Executive Management", "");
            //personaMap.Add("Fees Manager", "");
            //personaMap.Add("Funding Overrides - Retail", "Funding Manager");

            //personaMap.Add("Insurer", "Servicer");
            //personaMap.Add("Internal Audit", "Quality Control");
            //personaMap.Add("Jr. Processor", "Production Assistant");
            //personaMap.Add("Loan Officer External", "Loan Officer - OLA");
            //personaMap.Add("Loan Officer Internal", "Loan Officer - ILA");

            //personaMap.Add("Lock Desk", "Secondary Marketing");
            //personaMap.Add("Manager", "");
            //personaMap.Add("Marketing", "");
            //personaMap.Add("Post-Funding Edit", "");
            //personaMap.Add("Post-Funding Services", "");

            //personaMap.Add("Sales Assistant", "");
            //personaMap.Add("TPO Portal Admin", "TPO Administrator");

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


        static void generateMERS()
        {
            using (StreamWriter sw = new StreamWriter("mers.txt"))
            {
                long l = 10037630300000000;
                for (int i = 0; i < 1000; i++)
                {
                    l--;
                    sw.WriteLine($"{l}{CalculateMERSCheckDigit(l.ToString())}");
                }
            }
        }

        private static int CalculateMERSCheckDigit(string baseNumber)
        {
            if (baseNumber.Length != 17)
            {
                throw new ArgumentException("Base number must be 17 characters (7-character organization ID and 10-character sequence number.)", "baseNumber");
            }
            int currentDigit, totalSum = 0;
            bool carryOne = false;
            for (int i = baseNumber.Length - 1; i >= 0; i--)
            {
                currentDigit = int.Parse(baseNumber.Substring(i, 1));
                if (i % 2 == 1) // odd numbers
                {
                    totalSum += currentDigit;
                }
                else // even numbers
                {
                    int multiplied = currentDigit * 2;

                    if (carryOne) // add the carried 1 from the previous multiplication operation
                    {
                        multiplied++;
                    }

                    carryOne = multiplied >= 10;
                    if (carryOne)
                    {
                        totalSum += multiplied - 10;
                        if (i == 0)
                        {
                            // add the two digits together
                            totalSum += 1;
                        }
                    }
                    else
                    {
                        totalSum += multiplied;
                    }
                }
            }

            int roundedSum = (10 - totalSum % 10) + totalSum;

            int checkDigit = roundedSum - totalSum;
            if (checkDigit % 10 == 0)
            {
                checkDigit = 0;
            }

            return checkDigit;
        }
    }


    public class EllieMaeIdpClient : IDisposable
    {
        // Until they let us have our own...use theirs!
        private const string client_id = "n35xg3ze";
        private const string redirect_uri = "https://encompass.elliemae.com/homepage/atest.asp";

        private readonly HttpClient client;

        public EllieMaeIdpClient()
        {
            client = new HttpClient(new HttpClientHandler
            {
                AllowAutoRedirect = false,
            })
            {
                BaseAddress = new Uri("https://idp.elliemae.com"),
            };
        }

        public async Task<string> GetAuthCode(string instanceId, string username, string password)
        {
            // First, get the login page to fill the EM cookie and provide us the postback URL (which contains state)
            var loginPage = await client.GetAsync(
                $"/authorize?client_id={client_id}&response_type=code&redirect_uri={redirect_uri}&scope=sc&instance_id={instanceId}")
                .ConfigureAwait(false);

            loginPage.EnsureSuccessStatusCode();

            var loginPageContent = await loginPage.Content.ReadAsStringAsync();

            // Remember, never try to parse HTML with Regex
            var parsedHtmlWithRegex = Regex.Match(loginPageContent, "<form name=\"loginForm\"[^>]*action=\"(?'post_uri'[^\"]*)\"[^>]*>");
            if (parsedHtmlWithRegex.Success == false)
                throw new InvalidOperationException("Could not find the post URL in the login page");
            var postUri = parsedHtmlWithRegex.Groups["post_uri"].Value;

            var loginFormData = new Dictionary<string, string>
            {
                ["pf.pass"] = password,
                ["login"] = string.Empty,
                ["pf.adapterId"] = "sc",
                ["pf.username"] = $"{username}@{instanceId}#sc",
                ["current_scope"] = "sc",
                ["redirect_uri"] = redirect_uri,
                ["response_type"] = "code",
            };

            // When we send the form, we expect a 302 with the auth code in the Location header
            var loginResponse = await client.PostAsync(postUri, new FormUrlEncodedContent(loginFormData))
                .ConfigureAwait(false);
            if (loginResponse.StatusCode != HttpStatusCode.Redirect)
                throw new HttpRequestException("Login attempt did not return the expected redirect. Could be incorrect password.");

            // Find the "code" parameter in the query string
            var locationQuery = loginResponse.Headers.Location.Query.Substring(1); // trim the '?'
            var hasCode = locationQuery.Split('&')
                .ToDictionary(x => x.Split('=')[0], x => x.Split('=')[1])
                .TryGetValue("code", out var code);

            if (!hasCode)
                throw new InvalidOperationException("Could not find auth code in login response");

            return code;
        }

        public void Dispose()
        {
            client?.Dispose();
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