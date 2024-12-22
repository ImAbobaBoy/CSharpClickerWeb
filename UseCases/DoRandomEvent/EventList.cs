using CSharpClickerWeb.Domain;

namespace CSharpClickerWeb.UseCases.DoRandomEvent
{
    public class EventList
    {
        public readonly List<RandomEvent> randomEvents = new List<RandomEvent> {
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
            new() {
                EventTitle = "Цири понравилась ваша история!",
                EventDescription = "Цири так вдохновилась рассказанными историями, что решила поделиться прочкой своих",
                BoostTitle = "Цири",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Цири"].Price,
                BoostPriceChangeType = "dontChange",
                BoostIsAuto = true,
                BoostQuantityChange = 1,
                BoostQuantityChangeType = "+"
            },
            new() {
                EventTitle = "Геральт не в духе",
                EventDescription = "Видимо Геральт вспомнил плоихе времена. Теперь ему хочется просто помолчать",
                BoostTitle = "Геральт",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Геральт"].Price,
                BoostPriceChangeType = "=",
                BoostIsAuto = false,
                BoostQuantityChange = 0,
                BoostQuantityChangeType = "="
            },
            new() {
                EventTitle = "Вы порадовали Геральта",
                EventDescription = "Своей историей вы напомнили Геральту о Туссенте! Он хочет поделиться с вами парочкой историей о вампирах",
                BoostTitle = "Геральт",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Геральт"].Price,
                BoostPriceChangeType = "dontChange",
                BoostIsAuto = true,
                BoostQuantityChange = 3,
                BoostQuantityChangeType = "+"
            },
            new() {
                EventTitle = "Весемир нахмурился",
                EventDescription = "У него за плечами не мало плохого, возможно, что-то из этого он вспомнил именно сейчас...",
                BoostTitle = "Весемир",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Весемир"].Price,
                BoostPriceChangeType = "=",
                BoostIsAuto = false,
                BoostQuantityChange = 0,
                BoostQuantityChangeType = "="
            },
            new() {
                EventTitle = "Посмотрим только на Весемира!",
                EventDescription = "Помимо плохого он повидал и не мало хорошего! Истории так и льются из его уст!",
                BoostTitle = "Весемир",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Весемир"].Price,
                BoostPriceChangeType = "dontChange",
                BoostIsAuto = true,
                BoostQuantityChange = 5,
                BoostQuantityChangeType = "+"
            },
            new() {
                EventTitle = "Трисс не в духе",
                EventDescription = "Она явно вспомнила что-то нехорошее, вам стоит подбодрить ее хорошей историей",
                BoostTitle = "Трисс",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Трисс"].Price,
                BoostPriceChangeType = "=",
                BoostIsAuto = false,
                BoostQuantityChange = 0,
                BoostQuantityChangeType = "="
            },
            new() {
                EventTitle = "Самая веселая чародейка",
                EventDescription = "Вы смогли поднять Трисс настроение!",
                BoostTitle = "Трисс",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Трисс"].Price,
                BoostPriceChangeType = "dontChange",
                BoostIsAuto = true,
                BoostQuantityChange = 2,
                BoostQuantityChangeType = "+"
            },
            new() {
                EventTitle = "Никто не знает, о чем она задумалась в этот раз",
                EventDescription = "Йеннифэр резко замолчала, выглядит она очень напряженной и задумчивой, возможно ее не стоит трогать...",
                BoostTitle = "Йеннифэр",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Йеннифэр"].Price,
                BoostPriceChangeType = "=",
                BoostIsAuto = false,
                BoostQuantityChange = 0,
                BoostQuantityChangeType = "="
            },
            new() {
                EventTitle = "Даже ее можно развеселить!",
                EventDescription = "Йэн тоже человек, хоть и не самый обычный, у нее тоже есть воспоминания, которыми она дорожит. Она решила поделиться парочкой",
                BoostTitle = "Йеннифэр",
                BoostPriceChange = StandartBoosts.StandartBoostProperties["Йеннифэр"].Price,
                BoostPriceChangeType = "dontChange",
                BoostIsAuto = true,
                BoostQuantityChange = 4,
                BoostQuantityChangeType = "+"
            },
        };
    }
}
