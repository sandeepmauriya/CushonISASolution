using System.Threading.Tasks;
using InvestmentsCoreApi.Models;
using IvestmentsCoreApi.Infra;
using Microsoft.EntityFrameworkCore;

namespace InvestmentsCoreApi.Service
{
    public class InvestmentsService
    {
        private readonly InvestmentsDbContext _context;

        public InvestmentsService(InvestmentsDbContext context)
        {
            _context = context;
        }

        public async Task<Investments> AddInvestmentAsync(Investments investment)
        {
            _context.Investments.Add(investment);
            await _context.SaveChangesAsync();
            return investment;
        }

        public async Task<List<Investments>> GetInvestmentsByCustomerIdAsync(int customerId)
        {
            return await _context.Investments
                .Include(i => i.Funds) // Include the Fund navigation property (optional)
                .Where(i => i.CustomerID == customerId) // Filter by CustomerID
                .ToListAsync();
        }

    }
}
