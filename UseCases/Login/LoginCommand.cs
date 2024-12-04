using MediatR;

namespace CSharpClickerWeb.UseCases.Login
{
    public record LoginCommand(string UserName, string Password) : IRequest<Unit>;
}
