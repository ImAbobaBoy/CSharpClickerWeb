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
    public class DoRandomEventCommandHandler : IRequestHandler<DoRandomEventCommand, EventDto>
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

        public async Task<EventDto> Handle(DoRandomEventCommand request, CancellationToken cancellationToken)
        {
            var userId = currentUserAccessor.GetCurrentUserId();
            var user = await appDbContext.ApplicationUsers
                .Include(user => user.UserBoosts)
                .ThenInclude(ub => ub.Boost)
                .FirstAsync(user => user.Id == userId, cancellationToken);
            
            var random = new Random();
            int randomIndex = random.Next(10); 
            var randomEvent = new EventList().randomEvents[randomIndex];
            var standartBoost = StandartBoosts.StandartBoostProperties[randomEvent.BoostTitle];

            foreach (var boost in user.UserBoosts.Where(c => c.Boost.Title == randomEvent.BoostTitle))
            {
                switch (randomEvent.BoostPriceChangeType)
                {
                    case "+":
                        boost.CurrentPrice += randomEvent.BoostPriceChange;
                        break;
                    case "-":
                        boost.CurrentPrice -= randomEvent.BoostPriceChange;
                        break;
                    case "*":
                        boost.CurrentPrice *= randomEvent.BoostPriceChange;
                        break;
                    case "/":
                        boost.CurrentPrice /= randomEvent.BoostPriceChange;
                        break;
                    case "=":
                        boost.CurrentPrice = randomEvent.BoostPriceChange;
                        break;
                    default:
                        break;
                }
                
                switch (randomEvent.BoostQuantityChangeType)
                {
                    case "+":
                        boost.Quantity += randomEvent.BoostQuantityChange;
                        break;
                    case "-":
                        boost.Quantity -= randomEvent.BoostQuantityChange;
                        break;
                    case "*":
                        boost.Quantity *= randomEvent.BoostQuantityChange;
                        break;
                    case "/":
                        boost.Quantity /= randomEvent.BoostQuantityChange;
                        break;
                    case "=":
                        boost.Quantity = randomEvent.BoostQuantityChange;
                        break;
                    default:
                        break;
                }

                boost.Boost.IsAuto = randomEvent.BoostIsAuto;
            }

            await appDbContext.SaveChangesAsync(cancellationToken);

            var userDto = mapper.Map<UserDto>(user);

            userDto.ProfitPerClick = user.UserBoosts.GetProfit();
            userDto.ProfitPerSecond = user.UserBoosts.GetProfit(shouldCalculateAutoBoosts: true);

            var eventDto = mapper.Map<EventDto>(randomEvent);

            return eventDto;
        }
    }
}
