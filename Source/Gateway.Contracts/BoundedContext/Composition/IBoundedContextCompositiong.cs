using System.Collections.Generic;
using Gateway.ApiContracts.BoundedContext.Dtos;

namespace Gateway.ApiContracts.BoundedContext.Composition
{
    public interface IBoundedContextCompositiong
    {
        List<SomethingDto> GetSomethings();
    }
}
