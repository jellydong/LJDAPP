using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Ly.Admin.Core.AutoMapper
{
    public class MapperRegister
    {
        public static Type[] MapType()
        {

            var allIem = Assembly
                .GetEntryAssembly()
                .GetReferencedAssemblies()
                .Select(Assembly.Load)
                .SelectMany(y => y.DefinedTypes)
                .Where(type =>
                    typeof(IProfile).GetTypeInfo().IsAssignableFrom(type.AsType()));
            List<Type> allList = new List<Type>();
            foreach (var typeinfo in allIem)
            {
                var type = typeinfo.AsType();
                allList.Add(type);
            }

            Type[] alltypes = allList.ToArray();
            return alltypes;

        }
    }
}
