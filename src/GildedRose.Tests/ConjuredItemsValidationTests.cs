using System.Collections.Generic;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class ConjuredItemsValidationTests
    {
        [Fact]
        public void ConjuredManaCakeQuality0OnSellIn()
        {
            var app = new Program() { Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }, } };

            // day 1 results
            Assert.Equal(6, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(3, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 2 results
            Assert.Equal(4, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(2, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 3 results
            Assert.Equal(2, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(1, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 4 results
            Assert.Equal(0, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(0, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // quality now 0 test
            Assert.Equal(0, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(-1, app.Items[0].SellIn); // Conjured Mana Cake
        }

        [Fact]
        public void ConjuredManaCakeQuality0BeforeSellIn()
        {
            var app = new Program() { Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 10, Quality = 6 }, } };

            // day 1 results
            Assert.Equal(6, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(10, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 2 results
            Assert.Equal(4, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(9, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 3 results
            Assert.Equal(2, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(8, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 4 results
            Assert.Equal(0, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(7, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // quality now 0 test
            Assert.Equal(0, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(6, app.Items[0].SellIn); // Conjured Mana Cake
        }

        [Fact]
        public void ConjuredManaCakeQuality0AfterSellIn()
        {
            var app = new Program() { Items = new List<Item> { new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 15 }, } };

            // day 1 results
            Assert.Equal(15, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(3, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 2 results
            Assert.Equal(13, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(2, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 3 results
            Assert.Equal(11, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(1, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 4 results
            Assert.Equal(9, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(0, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 5 results
            Assert.Equal(5, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(-1, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 6 results
            Assert.Equal(1, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(-2, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 7 results
            Assert.Equal(0, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(-3, app.Items[0].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // quality now 0 test
            Assert.Equal(0, app.Items[0].Quality); // Conjured Mana Cake
            Assert.Equal(-4, app.Items[0].SellIn); // Conjured Mana Cake
        }

        [Fact]
        public void FullInventoryExistingValidity()
        {
            var app = new Program()
            {
                Items = new List<Item>
                                          {
                                              new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20},
                                              new Item {Name = "Aged Brie", SellIn = 2, Quality = 0},
                                              new Item {Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7},
                                              new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                                              new Item
                                                  {
                                                      Name = "Backstage passes to a TAFKAL80ETC concert",
                                                      SellIn = 15,
                                                      Quality = 20
                                                  },
                                              new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
                                          }
            };

            // day 1 results
            Assert.Equal(20, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(10, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(0, app.Items[1].Quality); // Aged Brie
            Assert.Equal(2, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(7, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(5, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(20, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(15, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(6, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(3, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 2 results
            Assert.Equal(19, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(9, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(1, app.Items[1].Quality); // Aged Brie
            Assert.Equal(1, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(6, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(4, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(21, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(14, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(4, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(2, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 3 results
            Assert.Equal(18, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(8, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(2, app.Items[1].Quality); // Aged Brie
            Assert.Equal(0, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(5, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(3, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(22, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(13, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(2, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(1, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 4 results
            Assert.Equal(17, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(7, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(4, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-1, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(4, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(2, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(23, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(12, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(0, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 5 results
            Assert.Equal(16, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(6, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(6, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-2, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(3, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(1, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(24, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(11, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-1, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 6 results
            Assert.Equal(15, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(5, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(8, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-3, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(2, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(0, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(25, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(10, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-2, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 7 results
            Assert.Equal(14, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(4, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(10, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-4, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-1, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(27, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(9, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-3, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 8 results
            Assert.Equal(13, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(3, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(12, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-5, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-2, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(29, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(8, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-4, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 9 results
            Assert.Equal(12, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(2, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(14, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-6, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-3, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(31, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(7, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-5, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 10 results
            Assert.Equal(11, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(1, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(16, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-7, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-4, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(33, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(6, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-6, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 11 results
            Assert.Equal(10, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(0, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(18, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-8, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-5, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(35, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(5, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-7, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 12 results
            Assert.Equal(8, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-1, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(20, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-9, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-6, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(38, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(4, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-8, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 13 results
            Assert.Equal(6, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-2, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(22, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-10, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-7, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(41, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(3, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-9, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 14 results
            Assert.Equal(4, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-3, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(24, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-11, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-8, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(44, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(2, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-10, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 15 results
            Assert.Equal(2, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-4, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(26, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-12, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-9, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(47, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(1, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-11, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 16 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-5, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(28, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-13, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-10, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(50, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-12, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 17 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-6, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(30, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-14, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-11, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-1, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-13, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 18 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-7, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(32, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-15, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-12, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-2, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-14, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 19 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-8, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(34, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-16, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-13, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-3, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-15, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 20 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-9, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(36, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-17, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-14, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-4, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-16, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 21 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-10, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(38, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-18, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-15, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-5, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-17, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 22 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-11, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(40, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-19, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-16, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-6, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-18, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 23 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-12, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(42, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-20, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-17, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-7, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-19, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 24 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-13, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(44, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-21, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-18, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-8, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-20, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 25 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-14, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(46, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-22, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-19, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-9, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-21, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 26 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-15, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(48, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-23, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-20, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-10, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-22, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // day 27 results
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-16, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(50, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-24, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-21, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-11, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-23, app.Items[5].SellIn); // Conjured Mana Cake
            app.UpdateQuality();

            // quality now 0 test
            Assert.Equal(0, app.Items[0].Quality); // +5 Dexterity Vest
            Assert.Equal(-17, app.Items[0].SellIn); // +5 Dexterity Vest
            Assert.Equal(50, app.Items[1].Quality); // Aged Brie
            Assert.Equal(-25, app.Items[1].SellIn); // Aged Brie
            Assert.Equal(0, app.Items[2].Quality); // Elixir of the Mongoose
            Assert.Equal(-22, app.Items[2].SellIn); // Elixir of the Mongoose
            Assert.Equal(80, app.Items[3].Quality); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[3].SellIn); // Sulfuras, Hand of Ragnaros
            Assert.Equal(0, app.Items[4].Quality); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(-12, app.Items[4].SellIn); // Backstage passes to a TAFKAL80ETC concert
            Assert.Equal(0, app.Items[5].Quality); // Conjured Mana Cake
            Assert.Equal(-24, app.Items[5].SellIn); // Conjured Mana Cake
        }
    }
}