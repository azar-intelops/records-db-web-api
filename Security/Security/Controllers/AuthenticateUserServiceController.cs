using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.AuthenticateUserService;
using Application.Queries.AuthenticateUserService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateUserServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AuthenticateUserServiceController> _logger;
        public AuthenticateUserServiceController(IMediator mediator, ILogger<AuthenticateUserServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateAuthenticateUser")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAuthenticateUser([FromBody] CreateAuthenticateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        

        

        

        
    }
}
