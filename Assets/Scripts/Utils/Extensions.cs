using System;
using System.Collections.Generic;
using System.Linq;

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
    }
}