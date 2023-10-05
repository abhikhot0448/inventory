using B2aTech.CrossCuttingConcern.Core.Primitives;

namespace dhanman.money.Api.Contracts;

public class ApiErrorResponse
{
    public ApiErrorResponse(IEnumerable<Error> errors)
    {
        Errors = errors;
    }
    
    public IEnumerable<Error> Errors { get; }
}
