using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Gateway.Compositioning.Factories
{
    public static class ModuleBuilderProvider
    {
        private static readonly ModuleBuilder moduleBuilder;

        static ModuleBuilderProvider()
        {
            var asmName = new AssemblyName("AssemblyForContainers");

            var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);

            moduleBuilder = asm.DefineDynamicModule("AssemblyForContainers");
        }

        public static ModuleBuilder GetModuleBuilder()
        {
            return moduleBuilder;
        }
    }
}