using Gateway.ApiContracts.BoundedContext.Coordination;
using Gateway.ApiContracts.BoundedContext.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.ApiController.BoundedContext.Command
{
    [Route("api/boundedContext")]
    [ApiController]
    public class BoundedContextController : ControllerBase
    {
        private readonly IBoundedContextCoordinator boundedContextCoordinator;

        public BoundedContextController(IBoundedContextCoordinator boundedContextCoordinator)
        {
            this.boundedContextCoordinator = boundedContextCoordinator;
        }

        [HttpPost]
        public void RegisterSomething(SomethingRegistrationDto registrationDto)
        {
            boundedContextCoordinator.RegisterSomething(registrationDto);
        }
    }
}

