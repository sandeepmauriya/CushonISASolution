using InvestmentsCoreApi.Models;
using InvestmentsCoreApi.Service;
using IvestmentsCoreApi.Queries;
using IvestmentsCoreApi.Service;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IvestmentsCoreApi.Handlers
{
    public class GetInvestmentsHandler : IRequestHandler<GetInvestmentsQuery, List<Investments>>
    {
        private readonly InvestmentsService _investmentsService;

        public GetInvestmentsHandler(InvestmentsService investmentsService)
        {
            _investmentsService = investmentsService;
        }

        public async Task<List<Investments>> Handle(GetInvestmentsQuery request, CancellationToken cancellationToken)
        {
            // Use the InvestmentsService to get investments by CustomerID
            return await _investmentsService.GetInvestmentsByCustomerIdAsync(request.CustomerID);
        }
    }
}
