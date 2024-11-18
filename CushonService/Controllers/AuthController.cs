using IvestmentsCoreApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IvestmentsCoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{emaildid}")]
        public async Task<IActionResult> Login(string emaildid)
        {
            try
            {
                // Send the query through the mediator to get investments for the customer
                var query = new GetCustomerQuery { Email = emaildid };
                var customers = await _mediator.Send(query);

                if (customers == null || customers == 0)
                {
                    return NotFound("No records found for this customer.");
                }

                return Ok(customers);
            }
            catch (System.Exception ex)
            {
                // Log the exception here if needed
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }
    }
}
