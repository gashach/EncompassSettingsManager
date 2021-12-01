using System.Collections.Generic;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.RemotingServices;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Templates
    {
        public static Dictionary<FileSystemEntry,BinaryObject> GetTemplates(this EncompassSessionManager manager, TemplateSettingsType templateSettingsType)
        {
            var results = new Dictionary<FileSystemEntry, BinaryObject>();

            var fileList =
                manager.EncompassSessionObjects.ConfigurationManager.GetAllPublicTemplateSettingsFileEntries(
                    templateSettingsType, true);
            foreach (var fileSystemEntry in fileList)
            {
                var file = manager.EncompassSessionObjects.ConfigurationManager.GetTemplateSettings(templateSettingsType,
                    fileSystemEntry);
                results.Add(fileSystemEntry, file);
            }

            return results;
        }

        public static void AddUpdateTemplates(this EncompassSessionManager manager,
            TemplateSettingsType templateSettingsType, Dictionary<FileSystemEntry, BinaryObject> templates)
        {
            foreach (var templateKvp in templates)
            {
                manager.EncompassSessionObjects.ConfigurationManager.SaveTemplateSettings(templateSettingsType,
                    new FileSystemEntry(FileSystemEntry.PublicRoot.Path,templateKvp.Key.Name,FileSystemEntry.Types.File,null),
                    templateKvp.Value);
            }
        }
    }
}