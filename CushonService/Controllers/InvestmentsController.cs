using InvestmentsCoreApi.Models;
using IvestmentsCoreApi.Handlers;
using IvestmentsCoreApi.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IvestmentsCoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvestmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public InvestmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetInvestmentsByCustomerID(int customerId)
        {
            try
            {
                // Send the query through the mediator to get investments for the customer
                var query = new GetInvestmentsQuery { CustomerID = customerId };
                var investments = await _mediator.Send(query);

                if (investments == null || investments.Count == 0)
                {
                    return NotFound("No investments found for this customer.");
                }

                return Ok(investments);
            }
            catch (System.Exception ex)
            {
                // Log the exception here if needed
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Invest(InvestCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);

        }

       
    }
}
