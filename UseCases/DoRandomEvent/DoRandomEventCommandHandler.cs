using AutoMapper;
using CSharpClickerWeb.Domain;
using CSharpClickerWeb.DomainServices;
using CSharpClickerWeb.Infrastructure.Abstractions;
using CSharpClickerWeb.UseCases.BuyBoost;
using CSharpClickerWeb.UseCases.Common;
using CSharpClickerWeb.UseCases.GetCurrentUser;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CSharpClickerWeb.UseCases.DoRandomEvent
{
    public class DoRandomEventCommandHandler : IRequestHandler<DoRandomEventCommand, UserDto>
    {
        private readonly ICurrentUserAccessor currentUserAccessor;
        private readonly IAppDbContext appDbContext;
        private readonly IMapper mapper;

        public DoRandomEventCommandHandler(ICurrentUserAccessor currentUserAccessor, IAppDbContext appDbContext, IMapper mapper)
        {
            this.currentUserAccessor = currentUserAccessor;
            this.appDbContext = appDbContext;
            this.mapper = mapper;
        }

        public async Task<UserDto> Handle(DoRandomEventCommand request, CancellationToken cancellationToken)
        {
            var userId = currentUserAccessor.GetCurrentUserId();
            var user = await appDbContext.ApplicationUsers
                .Include(user => user.UserBoosts)
                .ThenInclude(ub => ub.Boost)
                .FirstAsync(user => user.Id == userId, cancellationToken);
            var standartBoost = StandartBoosts.StandartBoostProperties["Рудокоп"];
            var ev = new EventList().randomEvents[0];
            foreach (var boost in user.UserBoosts.Where(c => c.Boost.Title == "Рудокоп"))
            {
                if (ev.BoostPriceChangeType == "+")
                    boost.CurrentPrice += ev.BoostPriceChange;
                if (ev.BoostPriceChangeType == "*")
                    boost.CurrentPrice *= ev.BoostPriceChange;
                if (ev.BoostPriceChangeType == "=")
                    boost.CurrentPrice = ev.BoostPriceChange;
                if (ev.BoostQuantityChangeType == "+")
                    boost.Quantity += ev.BoostQuantityChange;
                if (ev.BoostQuantityChangeType == "=")
                    boost.Quantity = ev.BoostQuantityChange;
                boost.Boost.IsAuto = ev.BoostIsAuto;
            }

            await appDbContext.SaveChangesAsync(cancellationToken);

            var userDto = mapper.Map<UserDto>(user);

            userDto.ProfitPerClick = user.UserBoosts.GetProfit();
            userDto.ProfitPerSecond = user.UserBoosts.GetProfit(shouldCalculateAutoBoosts: true);

            return userDto;
        }
    }
}
