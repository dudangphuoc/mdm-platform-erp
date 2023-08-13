using System.Reflection;

namespace MDM.Common.EntityFactory
{
    public static class RegisterDbSet
    {
        public static IEnumerable<Type> ShouldHasAttribute(params Assembly[] assemblies)
        {
            var types = assemblies.SelectMany(a => a.GetExportedTypes()).Where(c => c.IsClass && c.IsPublic);
            foreach (var type in types)
            {
                if (type.GetTypeInfo().IsDefined(typeof(InjectContextAttribute), true))
                {
                    yield return type;
                }
            }
        }
    }
}
