using CSharpClickerWeb.UseCases.GetLeaderboard;
using MediatR;

namespace CSharpClickerWeb.UseCases.GetLeaderboard;

public record GetLeaderboardQuery(int Page = 1) : IRequest<LeaderboardDto>;