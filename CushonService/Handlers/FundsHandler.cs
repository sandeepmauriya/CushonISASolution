using InvestmentsCoreApi.Models;
using IvestmentsCoreApi.Infra;
using IvestmentsCoreApi.Query;
using IvestmentsCoreApi.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IvestmentsCoreApi
{
    public class GetFundsHandler : IRequestHandler<GetFundsQuery, List<Funds>>
    {
        private readonly FundsService _fundsService;

        public GetFundsHandler(FundsService fundsService)
        {
            _fundsService = fundsService;
        }
        public async Task<List<Funds>> Handle(GetFundsQuery request, CancellationToken cancellationToken)
        {
            // Simulate fetching funds
            return await _fundsService.GetAllFundsAsync();
        }
    }
}
