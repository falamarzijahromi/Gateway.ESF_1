using System;

namespace Gateway.Compositioning.Abstracts
{
    public interface IProxyContainer : IDisposable
    {
        void AddProxyObject(object proxyObject);
        void DisposeProxies();
    }
}