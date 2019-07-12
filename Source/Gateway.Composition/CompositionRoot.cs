using Composition.ESF_1;
using DynamicServiceHost.Matcher;
using Gateway.ApiComposition;
using Gateway.ApiCoordination;
using Gateway.Compositioning.Abstracts;
using Gateway.Compositioning.Factories;
using Gateway.Compositioning.Implementations;
using Interceptors.ESF_1;

namespace Gateway.Compositioning
{
    public static class CompositionRoot
    {
        public static void RegisterDependecies(IIocContainer container)
        {
            RegisterOptimizations(container);

            RegisterContractServices(container);

            RegisterCoordinators(container);

            RegisterCompositors(container);
        }

        private static void RegisterOptimizations(IIocContainer container)
        {
            var moduleBuilder = ModuleBuilderProvider.GetModuleBuilder();
            var typeContainer = new TypeGlobalContainer();

            var optimizationPackage = new OptimizationPackage(moduleBuilder, typeContainer);

            container.RegisterSingleton(typeof(IOptimizationPackage), optimizationPackage);
        }

        private static void RegisterContractServices(IIocContainer container)
        {
            RegisterQueries(container);

            RegisterCommands(container);
        }

        private static void RegisterCommands(IIocContainer container)
        {
            ContractServices.LoadDependentAssemblies(typeof(ApiCoordinationTypeMark).Assembly);

            var commandContracts = ContractServices.GetAllServices(".Contracts", "Command");

            container.RegisterPerGraph(
                new[] {typeof(IProxyContainer)}, 
                typeof(ProxyContainer));

            container.RegisterAllServicesFactoryTransient((r, type) =>
            {
                var optPack = r.Resolver(typeof(IOptimizationPackage)) as IOptimizationPackage;
                var proxyContainer = r.Resolver(typeof(IProxyContainer)) as IProxyContainer;
                return CommandServiceFactory.CreateCommandService(type, proxyContainer, optPack);
            }, commandContracts);
        }

        private static void RegisterQueries(IIocContainer container)
        {
            ContractServices.LoadDependentAssemblies(typeof(ApiCompositionMarkType).Assembly);

            var queryContracts = ContractServices.GetAllServices(".Contracts", "Query");

            container.RegisterAllServicesFactoryTransient((r, type) =>
            {
                var optPack = (IOptimizationPackage) r.Resolver(typeof(IOptimizationPackage));
                return ProxyFactory.CreateQueryProxy(type, optPack);
            }, queryContracts);
        }

        private static void RegisterCompositors(IIocContainer container)
        {
            container.RegisterAllServicesPerGraph(typeof(ApiCompositionMarkType).Assembly);
        }

        private static void RegisterCoordinators(IIocContainer container)
        {
            container.RegisterAllServicesPerGraph(
                typeof(ApiCoordinationTypeMark).Assembly,
                new[] { typeof(TransactionInterceptor), typeof(ProxyDisposerInterceptor) });
        }
    }
}