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
    public class EncompassSessionManager :IDisposable
    {
        public EllieMae.Encompass.Client.Session EncompassSession { get; private set; }
        public EllieMae.EMLite.RemotingServices.Sessions.Session EncompassDefaultInstance { get; private set; }
        
        public SessionObjects EncompassSessionObjects { get; private set; }
        
        
        
        public EncompassSessionManager(string serverID, string userName, string password)
        {
            var server = $"https://{serverID}.ea.elliemae.net${serverID}";
            EncompassSession = new EllieMae.Encompass.Client.Session();
            EncompassSession.Start(server, userName, password);
            EllieMaeIdpClient emc = new EllieMaeIdpClient();
            var authCode = emc.GetAuthCode(serverID, userName, password).GetAwaiter().GetResult();
            EllieMae.EMLite.RemotingServices.Session.Start(server, userName, password, "AdminTools", false,null,authCode);
            EncompassDefaultInstance = EllieMae.EMLite.RemotingServices.Session.DefaultInstance;
            //var res  = EllieMae.EMLite.RemotingServices.SystemSettings.AllFolders;
            EncompassSessionObjects = EncompassSession.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance)
                .Single(pi => pi.Name == "SessionObjects")
                .GetValue(EncompassSession) as SessionObjects;
        }


        public void Dispose()
        {
            EncompassSession.End();
            ((IDisposable) EncompassSession)?.Dispose();
        }
    }
}