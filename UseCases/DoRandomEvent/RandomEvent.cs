namespace CSharpClickerWeb.UseCases.DoRandomEvent
{
    public class RandomEvent
    {
        public string EventTitle { get; set; }
        public string EventDescription { get; set; }
        public string BoostTitle { get; set; }
        public long BoostPriceChange { get; set; }
        public string BoostPriceChangeType { get; set; }
        public bool BoostIsAuto { get; set; }
        public int BoostQuantityChange { get; set; }
        public string BoostQuantityChangeType { get; set; }

        public RandomEvent(string eventTitle, string eventDescription, string boostTitle, 
            long boostPriceChange, string boostPriceChangeType, bool boostIsAuto, int boostQuantityChange, string boostQuantityChangeType)
        {
            EventTitle = eventTitle;
            EventDescription = eventDescription;
            BoostTitle = boostTitle;
            BoostPriceChange = boostPriceChange;
            BoostPriceChangeType = boostPriceChangeType;
            BoostIsAuto = boostIsAuto;
            BoostQuantityChange = boostQuantityChange;
            BoostQuantityChangeType = boostQuantityChangeType;
        }
    }
}
