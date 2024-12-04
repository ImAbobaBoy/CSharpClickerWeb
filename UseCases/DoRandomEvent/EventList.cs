using CSharpClickerWeb.Domain;

namespace CSharpClickerWeb.UseCases.DoRandomEvent
{
    public class EventList
    {
        public readonly List<RandomEvent> randomEvents = new List<RandomEvent> {
            new RandomEvent("1", "descr", "Рудоком", StandartBoosts.StandartBoostProperties["Рудокоп"].Price, "=", true, 0, "=")
        };
    }
}
