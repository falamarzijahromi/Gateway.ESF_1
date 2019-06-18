using Gateway.ApiController.BoundedContext.Command;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Host
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