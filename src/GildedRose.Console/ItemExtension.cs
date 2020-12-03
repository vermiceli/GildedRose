namespace GildedRose.Console
{
    public static class ItemExtension
    {
        public static void UpdateQuality(this Item item)
        {
            IUpdateQualityStrategy strategy = null;
            switch (item.Name)
            {
                case "Aged Brie":
                    strategy = new AgedBrieUpdateQualityStrategy(item);
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    strategy = new ConcertUpdateQualityStrategy(item);
                    break;
                case "Conjured Mana Cake":
                    strategy = new ConjuredUpdateQualityStrategy(item);
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    strategy = new LegendaryUpdateQualityStrategy();
                    break;
                default:
                    strategy = new DefaultUpdateQualityStrategy(item);
                    break;
            }

            strategy.UpdateQuality();
        }

        private static void UpdateQuality(IUpdateQualityStrategy strategy)
        {
            strategy.UpdateQuality();
        }
    }
}