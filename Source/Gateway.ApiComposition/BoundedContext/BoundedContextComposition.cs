using System;
using System.Collections.Generic;
using System.Linq;
using BoundedContext.Contracts.Query.Query1;
using BoundedContext.Contracts.Query.Query1.DTOs;
using Gateway.ApiComposition.BoundedContext.Factories;
using Gateway.ApiContracts.BoundedContext.Composition;
using SomethingDto = Gateway.ApiContracts.BoundedContext.Dtos.SomethingDto;

namespace Gateway.ApiComposition.BoundedContext
{
    public class BoundedContextCompositor : IBoundedContextCompositiong
    {
        private readonly IQuery1 query1;
        private readonly IVisitQueryService visitQueryService;

        public BoundedContextCompositor(IQuery1 query1, IVisitQueryService visitQueryService)
        {
            this.query1 = query1;
            this.visitQueryService = visitQueryService;
        }

        public List<SomethingDto> GetSomethings()
        {
            return query1.GetSomethings()
                .Select(SomethingDtoFactory.ConvertToGatewayContract)
                .ToList();
        }

        public List<SomethingDto> GetSomethingsBySomething(string something)
        {
            return query1.GetSomethingBySomething(something)
                .Select(SomethingDtoFactory.ConvertToGatewayContract)
                .ToList();
        }

        public List<Guid> GetVisitQueryIds(string name)
        {
            return visitQueryService.GetQueryDtosByName(name).Select(vqs => vqs.Id).ToList();
        }

        public List<Guid> GetVisitQueries(int count)
        {
            return visitQueryService.GetQueryDtos(count).Select(vqs => vqs.Id).ToList();
        }
    }
}
