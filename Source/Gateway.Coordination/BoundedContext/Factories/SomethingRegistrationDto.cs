using Gateway.ApiContracts.BoundedContext.Dtos;

namespace Gateway.ApiCoordination.BoundedContext.Factories
{
    internal static class SomethingRegistrationFactory
    {
        public static global::BoundedContext.Contracts.Command.Service1.DTOs.SomethingRegistrationDto
            ConvertFromRegistrationDto(
                SomethingRegistrationDto somethingRegistration)
        {
            return new global::BoundedContext.Contracts.Command.Service1.DTOs.SomethingRegistrationDto
            {
                Name = somethingRegistration.Name,
            };
        }
    }
}
