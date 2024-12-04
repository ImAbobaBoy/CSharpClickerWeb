using CSharpClickerWeb.UseCases.GetBoosts;
using CSharpClickerWeb.UseCases.GetCurrentUser;

namespace CSharpClickerWeb.ViewModels
{
    public class IndexViewModel
    {
        public UserDto User { get; init; }

        public IReadOnlyCollection<BoostDto> Boosts { get; init; }
    }
}
