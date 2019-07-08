using System;
using System.Collections.Generic;
using Gateway.ApiContracts.BoundedContext.Dtos;

namespace Gateway.ApiContracts.BoundedContext.Composition
{
    public interface IBoundedContextCompositiong
    {
        List<SomethingDto> GetSomethings();
        List<SomethingDto> GetSomethingsBySomething(string something);

        List<Guid> GetVisitQueryIds(string name);
        List<Guid> GetVisitQueries(int count);
    }
}
