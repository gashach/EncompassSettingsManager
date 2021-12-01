using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.DataEngine.eFolder;
using EllieMae.EMLite.RemotingServices;
using EllieMae.EMLite.Setup;
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

        public static List<StackingOrderTemplateItem> GetStackingOrderTemplates(this EncompassSessionManager manager)
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
                    File = entry,
                    Template = item
                });
            }

            return data;
        }

        public static void AddUpdateStackingOrderTemplates(this EncompassSessionManager manager,
            List<StackingOrderTemplateItem> templateItems)
        {
            var ifsExplorer =
                new TemplateIFSExplorer(manager.EncompassDefaultInstance, TemplateSettingsType.StackingOrder);
            ifsExplorer.Init(FileSystemEntry.PublicRoot, true);
            var currentTemplates = manager.GetStackingOrderTemplates();
            var ifsEntryFiles = ifsExplorer.GetFileSystemEntries(FileSystemEntry.PublicRoot);
            
            foreach (var templateItem in templateItems)
            {
                if (currentTemplates.Any(x => x.File.Name == templateItem.File.Name)) //update
                {
                            
                }
                else //Add
                {
                    var entry = ifsExplorer.AddEntry(false);
                    entry = ifsExplorer.Rename(entry, entry.Name, templateItem.File.Name);

                    var newEntry =
                        (StackingOrderSetTemplate) manager.EncompassSessionObjects.ConfigurationManager
                            .GetTemplateSettings(TemplateSettingsType.StackingOrder, entry);
                    newEntry.AutoSelectDocuments = templateItem.Template.AutoSelectDocuments;
                    newEntry.Description = templateItem.Template.Description;
                    newEntry.DocNames.AddRange( templateItem.Template.DocNames);
                    newEntry.FilterDocuments = templateItem.Template.FilterDocuments;
                    newEntry.NDEDocGroups.AddRange(templateItem.Template.NDEDocGroups);
                    newEntry.TemplateName = entry.Name;
                    newEntry.IsDefault = false;
                    
                    manager.EncompassSessionObjects.ConfigurationManager.SaveTemplateSettings(TemplateSettingsType.StackingOrder,
                        entry,(BinaryObject)(BinaryConvertibleObject)newEntry);
                    

                }
            }
        }
    }

    public class StackingOrderTemplateItem
    {
        public FileSystemEntry File { get; set; }
        public StackingOrderSetTemplate Template { get; set; }
    }
}