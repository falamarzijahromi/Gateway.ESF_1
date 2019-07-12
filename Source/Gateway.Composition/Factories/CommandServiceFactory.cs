using DynamicTypeGenerator;
using Gateway.Compositioning.Abstracts;
using Gateway.Compositioning.Implementations;
using System;
using System.Collections.Generic;
using DynamicServiceHost.Matcher;

namespace Gateway.Compositioning.Factories
{
    public static class CommandServiceFactory
    {
        public static object CreateCommandService(
            Type serviceType, 
            IProxyContainer proxyContainer,
            IOptimizationPackage optPack)
        {
            var connectedProxy = ProxyFactory.CreateConnectedCommandProxy(serviceType, optPack);
            var disconnectedProxy = ProxyFactory.CreateDisconnectedCommandProxy(serviceType, optPack);

            proxyContainer.AddProxyObject(connectedProxy);
            proxyContainer.AddProxyObject(disconnectedProxy);

            var commandInvokationEvaluator = new CommandsInvokationEvaluator(connectedProxy, disconnectedProxy);

            return CreateCommandServiceObject(commandInvokationEvaluator, serviceType, optPack);
        }

        private static object CreateCommandServiceObject(
            CommandsInvokationEvaluator commandInvokationEvaluator,
            Type serviceType, 
            IOptimizationPackage optPack)
        {
            var serviceObjectType = default(Type);

            if (optPack.typeContainer.Contains($"{serviceType}_Dispatcher"))
            {
                serviceObjectType = optPack.typeContainer.Get($"{serviceType}_Dispatcher");
            }
            else
            {
                var moduleBuilder = ModuleBuilderProvider.GetModuleBuilder();

                var serviceObjectTypeBuilder = DynamicTypeBuilderFactory.CreateClassBuilder(
                    $"{serviceType}_Dispatcher",
                    new Dictionary<string, Type>(),
                    moduleBuilder,
                    serviceType, typeof(IDisposable));

                serviceObjectType = serviceObjectTypeBuilder.Build();

                optPack.typeContainer.Save(serviceObjectType);
            }

            var serviceObject = Activator.CreateInstance(serviceObjectType, commandInvokationEvaluator);

            return serviceObject;
        }
    }
}