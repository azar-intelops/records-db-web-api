using MediatR;
using Microsoft.AspNetCore.Mvc;
using Application.Commands.DBLicenseInfoService;
using Application.Queries.DBLicenseInfoService;
using Application.Responses;
using System.Net;


namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DBLicenseInfoServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<DBLicenseInfoServiceController> _logger;
        public DBLicenseInfoServiceController(IMediator mediator, ILogger<DBLicenseInfoServiceController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        

        

        
        [HttpGet("{id}", Name = "GetDBLicenseInfoById")]
        [ProducesResponseType(typeof(DBLicenseInfoResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<ActionResult<DBLicenseInfoResponse>> GetDBLicenseInfoById(int id, CancellationToken cancellationToken)
        {
            _logger.LogInformation("DBLicenseInfo GET request received for ID {id}", id);
            var response = await _mediator.Send(new GetDBLicenseInfoByIdQuery(id), cancellationToken);
            return Ok(response);
        }
        

        

        
    }
}
