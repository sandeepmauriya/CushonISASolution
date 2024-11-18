using InvestmentsCoreApi.Models;
using IvestmentsCoreApi.Infra;
using MediatR;
using System.Collections.Generic;

namespace IvestmentsCoreApi.Query
{
    public class GetFundsQuery : IRequest<List<Funds>>
    {
    }
}
