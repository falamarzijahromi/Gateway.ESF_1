using System;
using Composition.ESF_1;
using Gateway.ApiComposition;
using Gateway.ApiCoordination;
using Gateway.Compositioning.Factories;
using Interceptors.ESF_1;

namespace Gateway.Compositioning
{
    public static class CompositionRoot
    {
        public static void RegisterDependecies(IIocContainer container)
        {
            RegisterCoordinators(container);

            RegisterCompositors(container);

            RegisterContractServices(container);
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
        }

        private static void RegisterQueries(IIocContainer container)
        {
            ContractServices.LoadDependentAssemblies(typeof(ApiCompositionMarkType).Assembly);

            var queryContracts = ContractServices.GetAllServices(".Contracts", "Query");

            container.RegisterAllServicesFactoryTransient(ProxyFactory.CreateQueryProxy, queryContracts);
        }

        private static void RegisterCompositors(IIocContainer container)
        {
            container.RegisterAllServicesPerGraph(typeof(ApiCompositionMarkType).Assembly);
        }

        private static void RegisterCoordinators(IIocContainer container)
        {
            container.RegisterAllServicesPerGraph(
                typeof(ApiCoordinationTypeMark).Assembly,
                new[] { typeof(TransactionInterceptor) });
        }
    }
}