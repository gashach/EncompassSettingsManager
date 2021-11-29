using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.DataEngine;
using EllieMae.Encompass.BusinessObjects.Loans;

namespace EncompassSettings
{
    public class EncompassSessionManager
    {
        public EllieMae.Encompass.Client.Session EncompassSession { get; private set; }
        public EllieMae.EMLite.RemotingServices.Sessions.Session EncompassDefaultInstance { get; private set; }
        
        public SessionObjects EncompassSessionObjects { get; private set; }
        
        
        
        public EncompassSessionManager(string server, string userName, string password)
        {
            EncompassSession = new EllieMae.Encompass.Client.Session();
            EncompassSession.Start(server, userName, password);
            EllieMae.EMLite.RemotingServices.Session.Start(server, userName, password, "AdminTools", false);
            EncompassDefaultInstance = EllieMae.EMLite.RemotingServices.Session.DefaultInstance;
            //var res  = EllieMae.EMLite.RemotingServices.SystemSettings.AllFolders;
            EncompassSessionObjects = EncompassSession.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(pi => pi.Name == "SessionObjects")
                .GetValue(EncompassSession) as SessionObjects;
        }
        
    }
}