using MediatR;

namespace CSharpClickerWeb.UseCases.Logout
{
    public record LogoutCommand : IRequest<Unit>;
}
