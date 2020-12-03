namespace GildedRose.Console
{
    public class ConjuredUpdateQualityStrategy : DefaultUpdateQualityStrategy
    {
        public ConjuredUpdateQualityStrategy(Item item) : base(item)
        {
        }

        public override void UpdateQuality()
        {
            base.UpdateQuality();
            base.Item.SellIn = base.Item.SellIn + 1;
            base.UpdateQuality();
        }
    }
}