using System;
using DynamicWcfServiceHost.Proxy;

namespace Gateway.Compositioning.Factories
{
    public static class ProxyFactory
    {
        public static object CreateQueryProxy(Type type)
        {
            var channelFactory = new ChannelFactory(type);

            return channelFactory.CreateConnectedChannel(isTransactional: false);
        }

        public static object CreateConnectedCommandProxy(Type type)
        {
            var channelFactory = new ChannelFactory(type);

            return channelFactory.CreateConnectedChannel(isTransactional: true);
        }

        public static object CreateDisconnectedCommandProxy(Type type)
        {
            var channelFactory = new ChannelFactory(type);

            return channelFactory.CreateDisconnectedChannel();
        }
    }
}