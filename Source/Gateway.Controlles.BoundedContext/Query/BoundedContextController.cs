using System.Collections.Generic;
using Gateway.ApiContracts.BoundedContext.Composition;
using Gateway.ApiContracts.BoundedContext.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.ApiController2.BoundedContext.Query
{
    [Route("api/boundedContext")]
    [ApiController]
    public class BoundedContextController : ControllerBase
    {
        private readonly IBoundedContextCompositiong boundedContextCompos;

        public BoundedContextController(IBoundedContextCompositiong boundedContextCompos)
        {
            this.boundedContextCompos = boundedContextCompos;
        }

        [HttpGet]
        public List<SomethingDto> GetSomethings()
        {
            return boundedContextCompos.GetSomethings();
        }
    }
}

