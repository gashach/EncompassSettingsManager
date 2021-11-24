using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.ClientServer;
using EllieMae.EMLite.Common;
using EllieMae.EMLite.RemotingServices;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class PipelineViews
    {
        public static string GetPersonalPipelineViews(this EncompassSessionManager manager, List<Persona> personaList)
        {
            PipelineViewAclManager mgr =
                manager.EncompassDefaultInstance.ACL.GetAclManager(AclCategory.PersonaPipelineView) as PipelineViewAclManager;
            List<PersonaPipelineViewList> data = new List<PersonaPipelineViewList>();
            foreach (var persona in  personaList)
            {
                var viewList = mgr.GetPersonaPipelineViews(persona.ID).ToList();
                data.Add(new PersonaPipelineViewList()
                {
                    PersonaName = persona.Name.Replace("/","-"),
                    PipelineViews = viewList
                });
                
            }

            return JsonConvert.SerializeObject(data);
        }
    }

    public class PersonaPipelineViewList
    {
        public string PersonaName { get; set; }
        public List<PersonaPipelineView> PipelineViews { get; set; }
    }
}