namespace CSharpClickerWeb.Domain
{
    public static class StandartBoosts
    {
        public static readonly Dictionary<string, Boost> StandartBoostProperties = new Dictionary<string, Boost>
        {
            {"Рудокоп", new Boost("Рудокоп", 100, 1, [], false)},
            {"Призрак", new Boost("Призрак", 500, 15, [], false)},
            {"Стражник", new Boost("Стражник", 2000, 60, [], false)},
            {"Маг огня", new Boost("Маг огня", 10000, 400, [], false)},
            {"Рудный барон", new Boost("Рудный барон", 100000, 5000, [], false)}
        };
    }
}
