using MediatR;

namespace CSharpClickerWeb.UseCases.GetBoosts
{
    public record GetBoostsQuery : IRequest<IReadOnlyCollection<BoostDto>>;
}
