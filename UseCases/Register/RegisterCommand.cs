using MediatR;

namespace CSharpClickerWeb.UseCases.Register
{
    public record RegisterCommand(string UserName, string Password) : IRequest<Unit>;
}
