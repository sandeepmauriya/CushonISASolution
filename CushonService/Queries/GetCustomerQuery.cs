using InvestmentsCoreApi.Models;
using MediatR;

namespace IvestmentsCoreApi.Queries
{
    public class GetCustomerQuery : IRequest<int?>
    {
        public string Email { get; set; }
    }
}
