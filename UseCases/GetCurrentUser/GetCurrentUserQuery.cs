using MediatR;

namespace CSharpClickerWeb.UseCases.GetCurrentUser
{
    public record GetCurrentUserQuery : IRequest<UserDto>;
}
