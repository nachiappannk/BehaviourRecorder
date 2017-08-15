using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace NashSoft.BehaviourRecorder
{
    public static class BehaviourRecorderPluginFactory<T> where T:class
    {
        public static T CreatePlugin()
        {
            var validTypes = GetAllConstructableTypesFromAllLoadedAssemblies();
            var enabledTypes = validTypes.Where(t =>  t.GetCustomAttribute<BehaviourRecorderPluginAttribute>().Enabled).ToList();
            int maxWeight = enabledTypes.Max(t => t.GetCustomAttribute<BehaviourRecorderPluginAttribute>().Weight);
            var selectedType = enabledTypes
                .FirstOrDefault(t => t.GetCustomAttribute<BehaviourRecorderPluginAttribute>().Weight == maxWeight);
            if(selectedType == null) throw new SystemException();
            return (T)Activator.CreateInstance(selectedType);

        }

        private static List<Type> GetAllConstructableTypesFromAllLoadedAssemblies()
        {
            List<Type> typesNeeded = new List<Type>();
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                typesNeeded.AddRange(GetAllConstructableTypes(assembly));
            }
            return typesNeeded;
        }

        private static List<Type> GetAllConstructableTypes(Assembly assembly)
        {
            List<Type> retValue = new List<Type>();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (IsTypeConstructablePlugin(type))
                    retValue.Add(type);
            }
            return retValue;
        }

        private static bool IsTypeConstructablePlugin(Type type)
        {
            if (!typeof(T).IsAssignableFrom(type)) return false;
            if (type.GetCustomAttributes<BehaviourRecorderPluginAttribute>() == null) return false;
            if (!type.IsClass) return false;
            if (type.IsAbstract) return false;
            if (null == type.GetConstructor(new Type[0])) return false;
            return true;
        }
    }
}