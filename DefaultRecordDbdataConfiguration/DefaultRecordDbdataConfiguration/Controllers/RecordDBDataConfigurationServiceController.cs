using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.RecordDBDataConfigurationService;
using Application.Queries.RecordDBDataConfigurationService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecordDBDataConfigurationServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<RecordDBDataConfigurationServiceController> _logger;
        public RecordDBDataConfigurationServiceController(IMediator mediator, ILogger<RecordDBDataConfigurationServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        

        

        
        [HttpGet("{id}", Name = "GetRecordDBDataConfigurationById")]
        [ProducesResponseType(typeof(RecordDBDataConfigurationResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<RecordDBDataConfigurationResponse>> GetRecordDBDataConfigurationById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("RecordDBDataConfiguration GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetRecordDBDataConfigurationByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        

        
    }
}
