namespace GildedRose.Console
{
    public class ConcertUpdateQualityStrategy : IUpdateQualityStrategy
    {
        public ConcertUpdateQualityStrategy(Item item)
        {
            this.Item = item;
        }

        private Item Item { get; set; }

        public void UpdateQuality()
        {
            if (this.Item.Quality < 50)
            {
                this.Item.Quality = this.Item.Quality + 1;
            }

            if (this.Item.SellIn < 11 && this.Item.Quality < 50)
            {
                this.Item.Quality = this.Item.Quality + 1;
            }

            if (this.Item.SellIn < 6 && this.Item.Quality < 50)
            {
                this.Item.Quality = this.Item.Quality + 1;
            }

            this.Item.SellIn = this.Item.SellIn - 1;

            if (this.Item.SellIn < 0)
            {
                this.Item.Quality = this.Item.Quality - this.Item.Quality;
            }
        }
    }
}