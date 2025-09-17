using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Shooter.Utils
{
    public static class Extensions
    {
        public static IEnumerable<Type> GetInheritors(this Type baseType)
        {
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetTypes())
                .Where(type => baseType.IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract);
        }
        
        public static IEnumerable<Type> GetDerivedTypesOfGenericType(this Type genericBaseType)
        {
            if (!genericBaseType.IsGenericTypeDefinition)
            {
                throw new ArgumentException("The provided type must be a generic type definition.", nameof(genericBaseType));
            }

            // Get all types in the current AppDomain
            // You might want to narrow this down to specific assemblies for performance
            var allTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes());

            foreach (var type in allTypes)
            {
                // Skip interfaces and abstract classes themselves if you only want concrete implementations
                if (type.IsAbstract || type.IsInterface)
                {
                    continue;
                }

                // Check if the type inherits from the generic base type
                Type currentType = type;
                while (currentType != null && currentType != typeof(object))
                {
                    if (currentType.IsGenericType && currentType.GetGenericTypeDefinition() == genericBaseType)
                    {
                        yield return type; // Return the derived type
                        break; // Move to the next type in allTypes
                    }
                    currentType = currentType.BaseType;
                }
            }
        }
    }
}