using MediatR;

namespace CSharpClickerWeb.UseCases.GetLeaderboard
{
    public class GetLeaderboardQuery : IRequest<LeaderboardDto>;
}
