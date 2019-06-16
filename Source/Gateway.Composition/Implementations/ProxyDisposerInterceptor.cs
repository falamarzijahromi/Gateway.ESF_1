using System;
using Composition.ESF_1;
using Gateway.Compositioning.Abstracts;

namespace Gateway.Compositioning.Implementations
{
    public class ProxyDisposerInterceptor : IServiceInterceptor, IDisposable
    {
        private readonly IProxyContainer proxyContainer;

        public ProxyDisposerInterceptor(IProxyContainer proxyContainer)
        {
            this.proxyContainer = proxyContainer;
        }

        public void Intercept(IInterceptionContext interceptionContext)
        {
            interceptionContext.Proceed();

            proxyContainer.DisposeProxies();
        }

        public void Dispose()
        {
            proxyContainer.Dispose();
        }
    }
}