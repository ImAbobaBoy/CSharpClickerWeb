using CSharpClickerWeb.UseCases.Common;
using MediatR;

namespace CSharpClickerWeb.UseCases.AddPoints
{
    public record AddPointsCommand(int Clicks, int Seconds) : IRequest<ScoreDto>;
}
