using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.Common;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Personas
    {
        public static string GetAllPersonas(this EncompassSessionManager manager)
        {
            var personas = manager.EncompassSessionObjects.PersonaManager.GetAllPersonas().ToList();
            return JsonConvert.SerializeObject(personas);
        }

        public static List<Persona> GetAllPersonasList(this EncompassSessionManager manager)
        {
            return manager.EncompassSessionObjects.PersonaManager.GetAllPersonas().ToList();
        }
    }
}