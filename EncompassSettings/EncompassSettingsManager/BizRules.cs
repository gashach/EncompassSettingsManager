using EllieMae.EMLite.ClientServer;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class BizRules
    {
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
        
    }
}