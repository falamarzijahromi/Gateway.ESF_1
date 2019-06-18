using Autofac;
using Gateway.Compositioning;

namespace Gateway.Host
{
    public static class AutofacExtensions
    {
        public static ContainerBuilder RegisterDependecies(this ContainerBuilder containerBuilder)
        {
            var iocContainer = new AutofacIocContainer(containerBuilder);

            CompositionRoot.RegisterDependecies(iocContainer);

            return containerBuilder;
        }
    }
}
