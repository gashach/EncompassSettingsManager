using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.ClientServer.Reporting;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.Common.UI;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Reports
    {
        public static List<EncompassReportSettings> GetAllPublicReports(this EncompassSessionManager manager)
        {
            var reportMainList = manager.EncompassSessionObjects.ReportManager.GetAllPublicReportDirEntries().ToList();
            return manager.GetReportsFromFileEntries(reportMainList);
        }

        public static List<EncompassReportSettings> GetAllPrivateReportsforUserName(this EncompassSessionManager manager, string username)
        {
            var reportMainList =
                manager.EncompassDefaultInstance.ReportManager.GetReportDirEntries(
                    FileSystemEntry.PrivateRoot(username)).ToList();
            return manager.GetReportsFromFileEntries(reportMainList);
        }

        private static List<EncompassReportSettings> GetReportsFromFileEntries(this EncompassSessionManager manager,
            List<FileSystemEntry> fileSystemEntries)
        {
            var reportList = fileSystemEntries.Where(x => x.Type == FileSystemEntry.Types.File).ToList();
            List<EncompassReportSettings> reults = new List<EncompassReportSettings>();
            foreach (var entry in  reportList)
            {
                var report = entry;
                if (report.Path.Contains(("%2A")))
                {
                    report = new FileSystemEntry(report.ParentFolder.Path.Replace("%2A", "*"), report.Name, report.Type,
                        report.Owner);
                }

                var settings = manager.EncompassSessionObjects.ReportManager.GetReportSettings(report);
                reults.Add(new EncompassReportSettings()
                {
                    Name = settings.ReportTitle,
                    FileSystemEntry = report,
                    Settings = settings
                });
                
            }

            return reults;
        }

        
    }

    public class EncompassReportSettings
    {
        public string Name { get; set; }
        public FileSystemEntry FileSystemEntry { get; set; }
        public ReportSettings Settings { get; set; }
    }
}