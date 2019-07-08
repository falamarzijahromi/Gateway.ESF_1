using System;
using System.Collections.Generic;
using Gateway.ApiContracts.BoundedContext.Composition;
using Gateway.ApiContracts.BoundedContext.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.ApiController.BoundedContext.Query
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

        [HttpGet]
        [Route("bc")]
        public List<SomethingDto> GetSomethings2(string something)
        {
            return boundedContextCompos.GetSomethingsBySomething(something);
        }

        [HttpGet]
        [Route("name")]
        public List<Guid> GetVisitQueriesByName(string name)
        {
            return boundedContextCompos.GetVisitQueryIds(name);
        }

        [HttpGet]
        [Route("count")]
        public List<Guid> GetVisitQueries(int count)
        {
            return boundedContextCompos.GetVisitQueries(count);
        }
    }
}

