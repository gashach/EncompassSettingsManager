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
        public static List<PersonaPipelineViewList> GetPersonalPipelineViews(this EncompassSessionManager manager, List<Persona> personaList)
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

            return data;
        }

        public static void AddUpdatePersonaPipelineViews(this EncompassSessionManager manager,
            List<PersonaPipelineViewList> pipelineViewList)
        {
            PipelineViewAclManager mgr =
                (PipelineViewAclManager) manager.EncompassDefaultInstance.ACL.GetAclManager(AclCategory
                    .PersonaPipelineView);
            foreach (var personaPipelineViewList in pipelineViewList)
            {
                foreach (var pipelineView in personaPipelineViewList.PipelineViews)
                {
                    if (!mgr.GetPersonaPipelineViews(pipelineView.PersonaID).Any(x => x.Name == pipelineView.Name))
                        mgr.CreatePipelineView(pipelineView);
                    else
                    {
                        var updateView = mgr.GetPersonaPipelineView(pipelineView.PersonaID, pipelineView.Name);
                        updateView.Columns.Clear();
                        updateView.Columns.AddRange(pipelineView.Columns.ToArray());
                        updateView.Filter = pipelineView.Filter;
                        mgr.UpdatePipelineView(updateView);
                    }
                }
            }
        }
    }

    public class PersonaPipelineViewList
    {
        public string PersonaName { get; set; }
        public List<PersonaPipelineView> PipelineViews { get; set; }
    }
}