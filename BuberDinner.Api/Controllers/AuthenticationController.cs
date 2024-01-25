using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using MapsterMapper;
using Microsoft.AspNetCore.Authorization;

namespace BuberDinner.Api.Controllers;

[Route("auth")]
[AllowAnonymous]
public class AuthenticationController : ApiController
{
  private readonly ISender _mediator;
  private readonly IMapper _mapper;

  public AuthenticationController(
    ISender mediator,
    IMapper mapper)
  {
    _mediator = mediator;
    _mapper = mapper;
  }

  [HttpPost("register")]
  public async Task<IActionResult> Register(RegisterRequest request)
  {
    var command = _mapper.Map<RegisterCommand>(request);

    var authResult = await _mediator.Send(command);

    return authResult.Match(
      authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
      errors => Problem(errors)
    );
  }

  [HttpPost("login")]
  public async Task<IActionResult> Login(LoginRequest request)
  {
    var query = _mapper.Map<LoginQuery>(request);

    var authResult = await _mediator.Send(query);

    if(authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
    {
      return Problem(statusCode: StatusCodes.Status401Unauthorized, title: authResult.FirstError.Description);
    }

    return authResult.Match(
      authResult => Ok(_mapper.Map<AuthenticationResult>(authResult)),
      errors => Problem(errors)
    );
  }  
}