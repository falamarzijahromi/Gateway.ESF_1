using System;
using System.Linq;
using System.Text;
using Autofac;
using Autofac.Builder;
using Autofac.Extras.DynamicProxy;
using Autofac.Features.ResolveAnything;
using Composition.ESF_1;
using Gateway.Host.GenericInterceptors;

namespace Gateway.Host
{
    public class AutofacIocContainer : IIocContainer, IDisposable
    {
        private ContainerBuilder containerBuilder;

        public AutofacIocContainer(ContainerBuilder containerBuilder)
        {
            this.containerBuilder = containerBuilder;

            containerBuilder.RegisterSource(new AnyConcreteTypeNotAlreadyRegisteredSource());

            RegisterGenericInterceptor();
        }

        public void RegisterFactory(
            Type[] serviceTypes,
            Func<object> serviceFactory,
            Type[] interceptors = null)
        {
            var builder = containerBuilder
                .Register(c => serviceFactory())
                .InstancePerLifetimeScope();

            foreach (var serviceType in serviceTypes)
            {
                builder.As(serviceType);
            }

            RegisterInterceptors(interceptors, builder);
        }

        public void RegisterPerGraph(
            Type[] serviceTypes,
            Type implementationType,
            Type[] interceptorTypes = null)
        {
            var builder = containerBuilder
                .RegisterType(implementationType)
                .InstancePerLifetimeScope();

            foreach (var serviceType in serviceTypes)
            {
                builder.As(serviceType);
            }

            RegisterInterceptors(interceptorTypes, builder);
        }

        public void RegisterFactoryTransient(Type[] serviceTypes, Func<IResolver, object> serviceFactory, Type[] interceptors = null)
        {
            var builder = containerBuilder.Register(c => serviceFactory.Invoke(new AutofacResolver(c)));

            foreach (var serviceType in serviceTypes)
            {
                builder.As(serviceType);
            }

            RegisterInterceptors(interceptors, builder);
        }

        public IContainer CreateContainer()
        {
            return containerBuilder.Build();
        }

        public void Dispose()
        {
            containerBuilder = null;
        }

        private void RegisterInterceptors(
            Type[] interceptorTypes,
            IRegistrationBuilder<object, IConcreteActivatorData, SingleRegistrationStyle> builder)
        {
            if (interceptorTypes != null && interceptorTypes.Any())
            {
                if (!interceptorTypes.All(type => typeof(IServiceInterceptor).IsAssignableFrom(type)))
                {
                    var notSuitableTypes = interceptorTypes
                        .Where(type => !typeof(IServiceInterceptor).IsAssignableFrom(type))
                        .Aggregate(new StringBuilder(), (seed, type) => seed.Append(type + ", "));

                    throw new Exception($"Types: {notSuitableTypes} must be IServiceInterceptor to be registered as an interceptor");
                }

                builder.EnableInterfaceInterceptors();

                foreach (var interceptorType in interceptorTypes)
                {
                    containerBuilder.RegisterType(interceptorType)
                        .InstancePerLifetimeScope()
                        .AsSelf();

                    var interceptor = CreateInterceptor(interceptorType);

                    builder.InterceptedBy(interceptor);
                }
            }
        }

        private Type CreateInterceptor(Type interceptorType)
        {
            var genInterceptorType = typeof(IGenericInterceptor<>);

            var interceptor = genInterceptorType.MakeGenericType(new Type[] { interceptorType });

            return interceptor;
        }

        private void RegisterGenericInterceptor()
        {
            containerBuilder
                .RegisterGeneric(typeof(GenericInterceptor<>))
                .As(typeof(IGenericInterceptor<>))
                .InstancePerLifetimeScope();
        }
    }
}