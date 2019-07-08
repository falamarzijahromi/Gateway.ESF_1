using Gateway.ApiContracts.BoundedContext.Dtos;

namespace Gateway.ApiComposition.BoundedContext.Factories
{
    internal class SomethingDtoFactory
    {
        public static SomethingDto ConvertToGatewayContract(
            global::BoundedContext.Contracts.Query.Query1.DTOs.SomethingDto something)
        {
            return new SomethingDto
            {
                Id = something.Id,
                Name = something.Name,
            };
        }
    }
}
