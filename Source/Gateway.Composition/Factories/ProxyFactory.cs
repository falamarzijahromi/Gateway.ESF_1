using DynamicServiceHost.Matcher;
using DynamicWcfServiceHost.Proxy;
using Gateway.Compositioning.Implementations;
using System;

namespace Gateway.Compositioning.Factories
{
    public static class ProxyFactory
    {
        public static object CreateQueryProxy(Type type, IOptimizationPackage optPack)
        {
            var channelFactory = new ChannelFactory(type, optPack);

            return channelFactory.CreateConnectedChannel(TypeCacher.Instance, isTransactional: false);
        }

        public static object CreateConnectedCommandProxy(Type type, IOptimizationPackage optPack)
        {
            var channelFactory = new ChannelFactory(type, optPack);

            return channelFactory.CreateConnectedChannel(TypeCacher.Instance, isTransactional: true);
        }

        public static object CreateDisconnectedCommandProxy(Type type, IOptimizationPackage optPack)
        {
            var channelFactory = new ChannelFactory(type, optPack);

            return channelFactory.CreateDisconnectedChannel(TypeCacher.Instance);
        }
    }
}