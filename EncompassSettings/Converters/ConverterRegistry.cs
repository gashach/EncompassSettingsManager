﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;

namespace EncompassSettings.Converters
{
    public static class ConverterRegistry
    {
        private static bool _initStatus = false;
        public static Dictionary<string,JsonConverter> CustomConverters { get; private set; } = new Dictionary<string,JsonConverter>();

        public static JsonSerializerSettings JsonSettings { get; private set; } = new JsonSerializerSettings();

        public static void Register()
        {
            if (_initStatus) return;

            var q = Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                t.IsClass && t.Namespace == "EncompassSettings.Converters" &&
                t.IsSubclassOf(typeof(JsonConverter<>))).ToList();
                
            foreach (var type in q)
            {
                var newConverter = Activator.CreateInstance(type, null) as JsonConverter;
                CustomConverters.Add(type.Name,newConverter);
                JsonSettings.Converters.Add(newConverter);
            }
            _initStatus = true;
        }
    }
}