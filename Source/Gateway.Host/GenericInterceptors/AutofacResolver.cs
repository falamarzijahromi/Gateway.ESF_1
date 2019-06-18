using System;
using Autofac;
using Composition.ESF_1;

namespace Gateway.Host.GenericInterceptors
{
    public class AutofacResolver : IResolver
    {
        private readonly IComponentContext componentContext;

        public AutofacResolver(IComponentContext componentContext)
        {
            this.componentContext = componentContext;
        }

        public object Resolver(Type type)
        {
            return componentContext.Resolve(type);
        }
    }
}