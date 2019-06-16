using Gateway.ApiController.BoundedContext.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Host.Composition
{
    public static class MvcBuilderExtensions
    {
        public static IMvcBuilder AddGatewayApplicationParts(this IMvcBuilder builder)
        {
            builder.AddApplicationPart(typeof(BoundedContextController).Assembly);

            return builder;
        }
    }
}