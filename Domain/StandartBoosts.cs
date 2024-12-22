namespace CSharpClickerWeb.Domain
{
    public static class StandartBoosts
    {
        public static readonly Dictionary<string, Boost> StandartBoostProperties = new Dictionary<string, Boost>
        {
            {"Цири", new Boost("Цири", 100, 2, [], false)},
            {"Геральт", new Boost("Геральт", 100, 2, [], false)},
            {"Весемир", new Boost("Весемир", 100, 2, [], false)},
            {"Трисс", new Boost("Трисс", 100, 2, [], false)},
            {"Йеннифэр", new Boost("Йеннифэр", 100, 2, [], false)},
        };
    }
}
