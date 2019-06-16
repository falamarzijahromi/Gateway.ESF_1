using System;
using System.Collections.Generic;
using DynamicTypeGenerator;
using Gateway.Compositioning.Abstracts;
using Gateway.Compositioning.Implementations;

namespace Gateway.Compositioning.Factories
{
    public static class CommandServiceFactory
    {
        public static object CreateCommandService(Type serviceType, IProxyContainer proxyContainer)
        {
            var connectedProxy = ProxyFactory.CreateConnectedCommandProxy(serviceType);
            var disconnectedProxy = ProxyFactory.CreateDisconnectedCommandProxy(serviceType);

            proxyContainer.AddProxyObject(connectedProxy);
            proxyContainer.AddProxyObject(disconnectedProxy);

            var commandInvokationEvaluator = new CommandsInvokationEvaluator(connectedProxy, disconnectedProxy);

            return CreateCommandServiceObject(commandInvokationEvaluator, serviceType);
        }

        private static object CreateCommandServiceObject(
            CommandsInvokationEvaluator commandInvokationEvaluator,
            Type serviceType)
        {
            var serviceObjectTypeBuilder = DynamicTypeBuilderFactory.CreateClassBuilder(
                $"{serviceType}_Dispatcher",
                new Dictionary<string, Type>(),
                new[] { serviceType, typeof(IDisposable)});

            var serviceObjectType = serviceObjectTypeBuilder.Build();

            var serviceObject = Activator.CreateInstance(serviceObjectType, commandInvokationEvaluator);

            return serviceObject;
        }
    }
}