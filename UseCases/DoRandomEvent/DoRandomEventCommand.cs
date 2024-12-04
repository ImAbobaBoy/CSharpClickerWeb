using CSharpClickerWeb.UseCases.Common;
using CSharpClickerWeb.UseCases.GetCurrentUser;
using MediatR;

namespace CSharpClickerWeb.UseCases.DoRandomEvent
{
    public record DoRandomEventCommand(int BoostId) : IRequest<UserDto>;
}
