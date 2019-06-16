using Gateway.Compositioning.Abstracts;
using System;
using System.Collections.Generic;

namespace Gateway.Compositioning.Implementations
{
    public class ProxyContainer : IProxyContainer
    {
        private readonly List<object> proxyObjects;

        public ProxyContainer()
        {
            proxyObjects = new List<object>();
        }

        public void Dispose()
        {
            DisposeProxies();
        }

        public void AddProxyObject(object proxyObject)
        {
            proxyObjects.Add(proxyObject);
        }

        public void DisposeProxies()
        {
            foreach (var proxyObject in proxyObjects)
            {
                ((IDisposable)proxyObject).Dispose();
            }

            proxyObjects.Clear();
        }
    }
}