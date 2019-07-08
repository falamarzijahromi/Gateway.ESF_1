using System;
using DynamicWcfServiceHost.Proxy;
using Gateway.Compositioning.Implementations;

namespace Gateway.Compositioning.Factories
{
    public static class ProxyFactory
    {
        public static object CreateQueryProxy(Type type)
        {
            var channelFactory = new ChannelFactory(type);

            return channelFactory.CreateConnectedChannel(new TypeCacher(), isTransactional: false);
        }

        public static object CreateConnectedCommandProxy(Type type)
        {
            var channelFactory = new ChannelFactory(type);

            return channelFactory.CreateConnectedChannel(new TypeCacher(), isTransactional: true);
        }

        public static object CreateDisconnectedCommandProxy(Type type)
        {
            var channelFactory = new ChannelFactory(type);

            return channelFactory.CreateDisconnectedChannel(new TypeCacher());
        }
    }
}