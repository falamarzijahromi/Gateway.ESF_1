using System;
using Composition.ESF_1;

namespace Gateway.Compositioning
{
    public static class CompositionRoot
    {
        public static void RegisterDependecies(IIocContainer container)
        {
            RegisterCoordinators(container);

            RegisterCompositors(container);
        }

        private static void RegisterCompositors(IIocContainer container)
        {
        }

        private static void RegisterCoordinators(IIocContainer container)
        {
            throw new NotImplementedException();
        }
    }
}