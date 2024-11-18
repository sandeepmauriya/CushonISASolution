using System.Threading.Tasks;
using IvestmentsCoreApi.Infra;
using Microsoft.EntityFrameworkCore;

namespace IvestmentsCoreApi.Service
{
    public class CustomerService 
    {
        private readonly InvestmentsDbContext _context;

        public CustomerService(InvestmentsDbContext context)
        {
            _context = context;
        }

        public async Task<int?> GetCustomerIdByEmailAsync(string email)
        {
            // Check if the customer exists by email and return the CustomerID if found.
            var customer = await _context.Customers
                .FirstOrDefaultAsync(c => c.Email == email);

            return customer?.CustomerID;
        }
    }
}
