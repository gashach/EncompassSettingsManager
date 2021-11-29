using System;
using System.Collections.Generic;
using System.Linq;
using Elli.Common.Extensions;
using EllieMae.EMLite.ClientServer.Contacts;
using EllieMae.EMLite.ClientServer.Query;
using EllieMae.EMLite.ClientServer.Reporting;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Contacts
    {
        public static List<BizPartnerInfo> GetAllBizContacts(this EncompassSessionManager manager)
        {
            FieldFilterList filter = new FieldFilterList();
            List<QueryCriterion> qcList = new List<QueryCriterion>();
            qcList.Add(filter.CreateEvaluator().ToQueryCriterion());

            var cursor = manager.EncompassSessionObjects.ContactManager.OpenBizPartnerCursor(qcList.ToArray(),
                RelatedLoanMatchType.None, null, null, true);
            var count = cursor.GetItemCount();
            var list = cursor.GetItems(0, count).Cast<BizPartnerSummaryInfo>().ToList();
            var dataList =
                manager.EncompassSessionObjects.ContactManager.GetBizPartners(list.Select(x => x.ContactID).ToArray());
            cursor.Dispose();
            cursor = null;
            return dataList.ToList();
        }

        public static void AddBizContacts(this EncompassSessionManager manager, List<BizPartnerInfo> contacts)
        {
            foreach (var contact in contacts)
            {
                try
                {
                    manager.EncompassSessionObjects.ContactManager.CreateBizPartner(contact);
                }
                catch {
                    //yes, we dont care about errors for now.
                    //TODO: add error handling
                }
            }
        }
    }
}