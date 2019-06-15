using Castle.DynamicProxy;
using Composition.ESF_1;

namespace Gateway.Host.Composition
{
    public interface IGenericInterceptor<T> : IInterceptor where T : IServiceInterceptor
    {
    }
}