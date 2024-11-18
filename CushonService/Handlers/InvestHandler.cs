using InvestmentsCoreApi.Models;
using InvestmentsCoreApi.Service;
using IvestmentsCoreApi;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IvestmentsCoreApi
{
    public class InvestHandler : IRequestHandler<InvestCommand, Investments>
    {
        private readonly InvestmentsService _investmentsService;

        public InvestHandler(InvestmentsService investmentsService)
        {
            _investmentsService = investmentsService;
        }

        public async Task<Investments> Handle(InvestCommand request, CancellationToken cancellationToken)
        {
            var investment = new Investments
            {
                CustomerID = request.CustomerID,
                FundID = request.FundID,
                InvestmentAmount = request.InvestmentAmount,
                InvestmentDate = System.DateTime.Now // Set current date
                
            };

            return await _investmentsService.AddInvestmentAsync(investment);

        }


    }
}
