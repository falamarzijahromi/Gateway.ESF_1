using Gateway.ApiContracts.BoundedContext.Dtos;

namespace Gateway.ApiContracts.BoundedContext.Coordination
{
    public interface IBoundedContextCoordinator
    {
        void RegisterSomething(SomethingRegistrationDto registrationDto);
    }
}
