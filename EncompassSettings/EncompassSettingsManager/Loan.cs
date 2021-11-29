using System.Linq;
using System.Reflection;
using EllieMae.EMLite.DataEngine;
using EllieMae.Encompass.BusinessObjects.Loans;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class EncompassLoan
    {
        public static LoanDataMgr GetLoanDataManager(this Loan loan)
        {
            return (EllieMae.EMLite.DataEngine.LoanDataMgr)loan.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(pi => pi.Name == "dataMgr").GetValue(loan);
        }
    }
}