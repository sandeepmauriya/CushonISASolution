using InvestmentsCoreApi.Models;
using MediatR;

namespace IvestmentsCoreApi
{
    public class InvestCommand : IRequest<Investments>
    {
        public int CustomerID { get; set; }
        public int FundID { get; set; }
        public decimal InvestmentAmount { get; set; }
    }
}
