using InvestmentsCoreApi.Models;
using MediatR;

namespace IvestmentsCoreApi.Queries
{

    public class GetInvestmentsQuery : IRequest<List<Investments>>
    {
        public int CustomerID { get; set; }
    }
}
