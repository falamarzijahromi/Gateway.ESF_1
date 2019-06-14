using System.Collections.Generic;
using System.Linq;
using BoundedContext.Contracts.Query.Query1;
using Gateway.ApiComposition.BoundedContext.Factories;
using Gateway.ApiContracts.BoundedContext.Composition;
using Gateway.ApiContracts.BoundedContext.Dtos;

namespace Gateway.ApiComposition.BoundedContext
{
    public class BoundedContextComposition : IBoundedContextCompositiong
    {
        private readonly IQuery1 query1;

        public BoundedContextComposition(IQuery1 query1)
        {
            this.query1 = query1;
        }

        public List<SomethingDto> GetSomethings()
        {
            return query1.GetSomethings()
                .Select(smt => SomethingDtoFactory.ConvertToGatewayContract(smt))
                .ToList();
        }
    }
}
