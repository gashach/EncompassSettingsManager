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
        public static void RUN()
        {
            global::EncompassSettings.Converters.ConverterRegistry.Register();

            //settings.Converters.Add(new BusinessRuleConverter());

            //Task.Run(async () =>
            //    await restTestAsync()
            //).Wait();
            //fix();
            //fixe1Test();
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



        // static void fixe1Test()
        // {
        //     EllieMae.Encompass.Client.Session session = new EllieMae.Encompass.Client.Session();
        //     session.Start(@"server", "user", "pass");
        //     EllieMae.EMLite.RemotingServices.Session.Start(@"server", "user", "pass", "Encompass", false);
        //     var so = session.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
        //         .Single(pi => pi.Name == "SessionObjects").GetValue(session) as SessionObjects;
        //     var s = EllieMae.EMLite.RemotingServices.Session.DefaultInstance;
        //     //var identity = new EllieMae.EMLite.DataEngine.LoanIdentity("04f0f88c - 95e5 - 4274 - 83e4 - 59624e36b765");
        //
        //     //so.LoanManager.OpenLoan(identity);
        //     var loan = session.Loans.Open("{317794db-c317-4007-b2d5-90c9bd8b96ee}");
        //     //loan.ForceLock();
        //     //C:\SmartClientCache\Apps\UAC\Ellie Mae\A#DkGCbu#+nkEVpfk0ToMIgKcr8=\Encompass360
        //     var dataMgr = (EllieMae.EMLite.DataEngine.LoanDataMgr)
        //         loan.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
        //             .Single(pi => pi.Name == "dataMgr").GetValue(loan);
        //     var asm = Assembly.LoadFile(@"C:\Users\Jesse.Weinstock\Downloads\ePASS.Appraisal.PreferredAppraiser.dll");
        //     //var asm2 = Assembly.LoadFile(@"C:\SmartClientCache\Apps\UAC\Ellie Mae\hwV988goe69Au+JE3YZcq1THDOI=\Encompass360\EMePass.dll");
        //     var bamType = typeof(EllieMae.EMLite.ePass.Bam);
        //     var bam = Activator.CreateInstance(bamType, new object[] {null, dataMgr, dataMgr.LoanData});
        //     var OrderHistoryType = asm.GetTypes().First(x => x.Name == "OrderHistory");
        //     StringBuilder sb = new StringBuilder();
        //     foreach (var order in OrderHistoryType.GetProperty("GetHistory")
        //         .GetValue(Activator.CreateInstance(OrderHistoryType, new object[] {bam, true})) as IEnumerable)
        //     {
        //         foreach (var his in order.GetType().GetField("History").GetValue(order) as IEnumerable)
        //         {
        //             var value = his.GetType().GetField("Comments").GetValue(his);
        //         }
        //     }
        //
        //     session.End();
        // }

        static void fix()
        {



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
            var id = user.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(pi => pi.Name == "Id").GetValue(user) as int?;
            return new KeyValuePair<string, int>(user.Userid, id ?? 0);
        }



    }
}