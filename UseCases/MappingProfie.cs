using AutoMapper;
using CSharpClickerWeb.Domain;
using CSharpClickerWeb.UseCases.GetBoosts;
using CSharpClickerWeb.UseCases.GetCurrentUser;
using CSharpClickerWeb.UseCases.GetLeaderboard;

namespace CSharpClickerWeb.UseCases
{
    public class MappingProfie : Profile
    {
        public MappingProfie()
        {
            CreateMap<Boost, BoostDto>();
            CreateMap<UserBoost, UserBoostDto>();
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<ApplicationUser, LeaderboardUserDto>();
        }
    }
}
