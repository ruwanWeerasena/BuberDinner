
using BuberDinner.Application.Dinners.Commands.CreateDinner;
using BuberDinner.Contracts.Dinners;

using MapsterMapper;

using MediatR;

using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("hosts/{hostId}/dinners")]
public class DinnersController : ApiController
{
    private readonly IMapper _mapper;
    public readonly ISender _mediator;

    public DinnersController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDinner(CreateDinnerRequest request, string hostId)
    {
        var command = _mapper.Map<CreateDinnerCommand>((request,hostId));
        var createDinnerResult = await _mediator.Send(command);
        if(createDinnerResult.IsSuccess)
        {
            return Ok(_mapper.Map<DinnerResponse>(createDinnerResult.Value));
        }
        return Problem();
    }
}