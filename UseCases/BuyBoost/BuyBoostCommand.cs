using CSharpClickerWeb.UseCases.Common;
using MediatR;

namespace CSharpClickerWeb.UseCases.BuyBoost
{
    public record BuyBoostCommand(int BoostId) : IRequest<ScoreBoostDto>;
}
