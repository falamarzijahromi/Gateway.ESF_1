using Castle.DynamicProxy;
using Composition.ESF_1;

namespace Gateway.Host.GenericInterceptors
{
    public interface IGenericInterceptor<T> : IInterceptor where T : IServiceInterceptor
    {
    }
}