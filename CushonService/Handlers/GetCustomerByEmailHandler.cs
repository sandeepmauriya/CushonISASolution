using IvestmentsCoreApi.Queries;
using IvestmentsCoreApi.Service;
using MediatR;

namespace IvestmentsCoreApi.Handlers
{
    public class GetCustomerByEmailHandler : IRequestHandler<GetCustomerQuery, int?>
    {
        private readonly CustomerService _customerService;

        public GetCustomerByEmailHandler(CustomerService customerService)
        {
            _customerService = customerService;
        }

        public async Task<int?> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            return await _customerService.GetCustomerIdByEmailAsync(request.Email);
        }
    }
}
