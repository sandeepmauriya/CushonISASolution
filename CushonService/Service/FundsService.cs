using InvestmentsCoreApi.Models;
using IvestmentsCoreApi.Infra;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IvestmentsCoreApi.Service
{
    public class FundsService
    {
        private readonly InvestmentsDbContext _context;

        public FundsService(InvestmentsDbContext context)
        {
            _context = context;
        }

        public async Task<List<Funds>> GetAllFundsAsync()
        {
            return await _context.Funds.ToListAsync();
        }
    }
}
