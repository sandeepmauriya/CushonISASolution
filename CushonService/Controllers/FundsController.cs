using IvestmentsCoreApi.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IvestmentsCoreApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FundsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FundsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetFunds()
        {
            var funds = await _mediator.Send(new GetFundsQuery());
            return Ok(funds);
        }
    }
}
