using System.Collections.Generic;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.DataEngine.eFolder;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Documents
    {
        public static string GetDocumentTrackingSetup(this EncompassSessionManager manager)
        {
            var docTracking = manager.EncompassSessionObjects.ConfigurationManager.GetDocumentTrackingSetup();
            return JsonConvert.SerializeObject(docTracking);
        }

        public static string GetStackingOrderTemplates(this EncompassSessionManager manager)
        {
            var fileList =
                manager.EncompassSessionObjects.ConfigurationManager.GetAllPublicTemplateSettingsFileEntries(
                    TemplateSettingsType.FormList, true);
            var data = new List<StackingOrderTemplateItem>();
            foreach (var entry in fileList)
            {
                var item = (StackingOrderSetTemplate)manager.EncompassSessionObjects.ConfigurationManager.GetTemplateSettings(
                    TemplateSettingsType.StackingOrder, entry) ;
                data.Add( new StackingOrderTemplateItem()
                {
                    FileName = entry.Name,
                    Template = item
                });
            }

            return JsonConvert.SerializeObject(data);
        }
    }

    public class StackingOrderTemplateItem
    {
        public string FileName { get; set; }
        public StackingOrderSetTemplate Template { get; set; }
    }
}