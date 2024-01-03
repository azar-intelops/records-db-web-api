using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.AddressService;
using Application.Queries.AddressService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<AddressServiceController> _logger;
        public AddressServiceController(IMediator mediator, ILogger<AddressServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpPost(Name = "CreateAddress")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateAddress([FromBody] CreateAddressCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        

        

        

        

        
    }
}
