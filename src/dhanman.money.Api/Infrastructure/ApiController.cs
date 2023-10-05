using B2aTech.CrossCuttingConcern.Core.Primitives;
using dhanman.money.Api.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace dhanman.money.Api.Infrastructure;

public abstract class ApiController : ControllerBase
{
    protected ApiController(IMediator mediator)
    {
        Mediator = mediator;
    }

    protected IMediator Mediator { get; }

    protected IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new[] { error }));

    protected IActionResult NotFound(Error error)
    {
        // This method was created so that it is easier to match the extension methods on the Result class.
        return NotFound();
    }
}
