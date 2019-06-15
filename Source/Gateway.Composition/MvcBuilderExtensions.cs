using Gateway.ApiController2.BoundedContext.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Gateway.Compositioning
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