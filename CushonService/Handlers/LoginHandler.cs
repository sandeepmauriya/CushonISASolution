using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IvestmentsCoreApi
{
    public class LoginHandler : IRequestHandler<LoginCommand, string>
    {
        public async Task<string> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Simulate login logic
            return await Task.FromResult($"User {request.Email} logged in successfully!");
        }
    }
}
