using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.Common;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Personas
    {
        public static List<Persona> GetAllPersonas(this EncompassSessionManager manager)
        {
            return manager.EncompassSessionObjects.PersonaManager.GetAllPersonas().ToList();
        }

        public static List<EllieMae.Encompass.BusinessObjects.Users.Persona> GetAllPersonasStandard(
            this EncompassSessionManager manager)
        {
            return manager.EncompassSession.Users.Personas.Cast<EllieMae.Encompass.BusinessObjects.Users.Persona>()
                .ToList();
        }
    }
}