using BoundedContext.Contracts.Command.Service1;
using Coordination.ESF_1;
using Gateway.ApiContracts.BoundedContext.Dtos;
using Gateway.ApiCoordination.BoundedContext.Factories;

namespace Gateway.ApiCoordination.BoundedContext
{
    public class BoundedContexCoordinator
    {
        private readonly IService1 service1;

        public BoundedContexCoordinator(IService1 service1)
        {
            this.service1 = service1;
        }

        public void RegisterSomething(SomethingRegistrationDto registrationDto)
        {
            using (DirectScope.Begin())
                DirectRegisterSomething(registrationDto);

            using (IndirectScope.Begin())
                IndirectRegisterSomething(registrationDto);
        }

        private void DirectRegisterSomething(SomethingRegistrationDto registrationDto)
        {
            service1.RegisterSomething(SomethingRegistrationFactory.ConvertFromRegistrationDto(registrationDto));
        }

        private void IndirectRegisterSomething(SomethingRegistrationDto registrationDto)
        {
            service1.RegisterSomething(SomethingRegistrationFactory.ConvertFromRegistrationDto(registrationDto));
        }
    }
}
