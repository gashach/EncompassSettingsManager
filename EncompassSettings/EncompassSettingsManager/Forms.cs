using System.Collections.Generic;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.DataEngine;
using EllieMae.EMLite.Setup;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Forms
    {
        public static List<iFormTemplate> GetAllFormGroups(this EncompassSessionManager manager)
        {
            TemplateIFSExplorer explorer =
                new TemplateIFSExplorer(manager.EncompassDefaultInstance, TemplateSettingsType.FormList);
            var files = explorer.GetFileSystemEntries(FileSystemEntry.PublicRoot);
            var rules = new List<iFormTemplate>();
            foreach (var file in files)
            {
                var template =
                    (FormTemplate) manager.EncompassDefaultInstance.ConfigurationManager.GetTemplateSettings(
                        TemplateSettingsType.FormList, file);
                rules.Add(new iFormTemplate()
                {
                    name = template.TemplateName,
                    description = template.Description,
                    FormsList = template.GetFormNames()
                });
            }

            return rules;
        }
    }
    
    public class iFormTemplate
    {
        public string name { get; set; }
        public string description { get; set; }
        public string[] FormsList { get; set; }
    }
}