using CSharpClickerWeb.Domain;

namespace CSharpClickerWeb.UseCases.DoRandomEvent
{
    public class EventList
    {
        public readonly List<RandomEvent> randomEvents = new List<RandomEvent> {
            new() {
                EventTitle = "1",
                EventDescription = "desct",
                BoostTitle = "Цири",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Рудокоп"].Price,
                BoostPriceChangeType = "=",
                BoostIsAuto = true,
                BoostQuantityChange = 0,
                BoostQuantityChangeType = "="
            },
            new() {
                EventTitle = "Цири обиделась",
                EventDescription = "Цири не понравились рассказанные истории, теперь она будет молчать",
                BoostTitle = "Цири",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Цири"].Price,
                BoostPriceChangeType = "=",
                BoostIsAuto = false,
                BoostQuantityChange = 0,
                BoostQuantityChangeType = "="
            },
        };
    }
}
