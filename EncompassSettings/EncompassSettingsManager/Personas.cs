﻿using System.Collections.Generic;
using System.Linq;
using EllieMae.EMLite.Common;
using Newtonsoft.Json;

namespace EncompassSettings.EncompassSettingsManager
{
    public static class Personas
    {
        public static string GetAllPersonasAsJson(this EncompassSessionManager manager)
        {
            return JsonConvert.SerializeObject(manager.GetAllPersonas());
        }

        public static List<Persona> GetAllPersonas(this EncompassSessionManager manager)
        {
            return manager.EncompassSessionObjects.PersonaManager.GetAllPersonas().ToList();
        }
    }
}