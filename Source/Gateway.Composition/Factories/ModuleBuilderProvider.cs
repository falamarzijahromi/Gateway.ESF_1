using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Gateway.Compositioning.Factories
{
    public class ModuleBuilderProvider
    {
        private readonly ModuleBuilder moduleBuilder;

        public ModuleBuilderProvider()
        {
            var asmName = new AssemblyName("DyniamcProxyContainerAssembly");

            var asm = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.Run);

            moduleBuilder = asm.DefineDynamicModule("DynamicModuleForProxies");
        }

        public ModuleBuilder GetModuleBuilder()
        {
            return moduleBuilder;
        }
    }
}