using System.Linq;
using EllieMae.EMLite.Common;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Reports
    {
        public static string GetAllPublicReports(this EncompassSessionManager manager)
        {
            var reportMainList = manager.EncompassSessionObjects.ReportManager.GetAllPublicReportDirEntries().ToList();
            var reportList = reportMainList.Where(x => x.Type == FileSystemEntry.Types.File).ToList();
            foreach (var entry in  reportList)
            {
                var report = entry;
                if (report.Path.Contains(("%2A")))
                {
                    report = new FileSystemEntry(report.ParentFolder.Path.Replace("%2A", "*"), report.Name, report.Type,
                        report.Owner);
                }

                var settings = manager.EncompassSessionObjects.ReportManager.GetReportSettings(report);
                
            }
        }

        public static string GetAllPrivateReportsforUserName(this EncompassSessionManager manager, string username)
        {
            var reportMainList =
                manager.EncompassDefaultInstance.ReportManager.GetReportDirEntries(
                    FileSystemEntry.PrivateRoot(username));
        }
    }
}