using System;
using System.Linq;
using System.Reflection;

namespace Gateway.Compositioning.Factories
{
    public class ContractServices
    {
        public static void LoadDependentAssemblies(Assembly assembly)
        {
            foreach (var assmName in assembly.GetReferencedAssemblies())
            {
                    Assembly.Load(assmName);
            }
        }

        public static Type[] GetAllServices(string assemblyType, string contractType)
        {
            var allContracts = AppDomain.CurrentDomain
                .GetAssemblies()
                .Where(asm => asm.FullName.Contains(assemblyType));

            var allSelected = allContracts
                .SelectMany(asm => asm.ExportedTypes)
                .Where(type => type.IsInterface && type.FullName.Contains(contractType));

            return allSelected.ToArray();
        }
    }
}