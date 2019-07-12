using System.Reflection.Emit;
using DynamicServiceHost.Matcher;

namespace Gateway.Compositioning.Implementations
{
    public class OptimizationPackage : IOptimizationPackage
    {
        public OptimizationPackage(ModuleBuilder moduleBuilder, IGlobalTypeContainer typeContainer)
        {
            this.moduleBuilder = moduleBuilder;
            this.typeContainer = typeContainer;
        }

        public ModuleBuilder moduleBuilder { get; }
        public IGlobalTypeContainer typeContainer { get; }
    }
}