namespace GildedRose.Console
{
    public class DefaultUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public DefaultUpdateQualityStrategy(Item item)
        {
            this.Item = item;
        }

        protected Item Item { get; set; }

        public virtual void UpdateQuality()
        {
            if (this.Item.Quality > 0)
            {
                this.Item.Quality = this.Item.Quality - 1;
            }

            this.Item.SellIn = this.Item.SellIn - 1;

            if (this.Item.SellIn < 0 && this.Item.Quality > 0)
            {
                this.Item.Quality = this.Item.Quality - 1;
            }
        }
    }
}