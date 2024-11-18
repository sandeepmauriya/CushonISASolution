using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IvestmentsCoreApi
{
    public class RegisterHandler : IRequestHandler<RegisterCommand, string>
    {
        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            // Simulate user registration logic
            return await Task.FromResult($"User {request.Email} registered successfully!");
        }
    }
}
