namespace CSharpClickerWeb.Domain
{
    public static class StandartBoosts
    {
        public static readonly List<Boost> StandartBoostProperties = new List<Boost>
        {
            new Boost("Рудокоп", 100, 1, [], false),
            new Boost("Призрак", 500, 15, [], false),
            new Boost("Стражник", 2000, 60, [], false),
            new Boost("Маг огня", 10000, 400, [], false),
            new Boost("Рудный барон", 100000, 5000, [], false)
        };
    }
}
