using Application.Pets.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("pets")]
public class PetController : ApiController
{
    private readonly ISender _mediator;

    public PetController(ISender mediator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return null;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePetCommand command)
    {
        var result = await _mediator.Send(command);

        return result.Match(
            pet => Ok(pet),
            errors => Problem(errors)
        );
    }
}
