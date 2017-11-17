using gilded_rose;
using Xunit;
using System.IO;
using System.Collections.Generic;

namespace gilded_rose_test
{
    public class GildedRoseTest
    {
        [Fact]
        public void Update_Quality_Reduce_Value_Each_Day()
        {
            GildedRose gildedRose;

            IList<Item> items = new List<Item>()
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 }
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 19, "Quality has not reduced.");
            Assert.True(items[0].SellIn == 9, "Sell in has not reduced.");
        }

        [Fact]
        public void Update_Quality_Quality_Never_Negitive()
        {
            GildedRose gildedRose;

            IList<Item> items = new List<Item>()
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 0 }
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 0, "Quality is negitive.");
        }

        [Fact]
        public void Update_Quality_Quality_Never_More_Than_Fifty()
        {
            GildedRose gildedRose;

            IList<Item> items = new List<Item>()
            {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 50 }
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 50, "Quality has not increased more than 50.");
        }

        [Fact]
        public void Update_Quality_Quality_Never_Change()
        {
            IList<Item> items = new List<Item>()
            {
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 }
            };

            GildedRose gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 80, "Quality has changed.");
        }

        [Fact]
        public void Update_Quality_Increase_Quality_SellIn_Approach()
        {
            GildedRose gildedRose;

            IList<Item> items = new List<Item>()
            {
                new Item { Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 45 }
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 47, "Quality is not Increase by 2 When sell in 10 or less.");

            items[0].SellIn = 5;
            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 50, "Quality is not Increase by 3 when sell in 5 or less.");

            items[0].SellIn = 0;
            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 0, "Quality is not become 0 after Concert."); 
        }

        [Fact]
        public void Update_Quality_Quality_Degrade_Twice()
        {
            GildedRose gildedRose;

            IList<Item> items = new List<Item>()
            {
                new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 }
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 18, "When sell in date passed Quality degrade twice.");  
        }

        [Fact]
        public void Update_Quality_Quality_Increase_When_Old()
        {
            GildedRose gildedRose;

            IList<Item> items = new List<Item>()
            {
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 }
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 1, "Quality has not increased when item get old.");
        }


        [Fact]
        public void Update_Quality_Degrade_Quality_twice_fast()
        {
            GildedRose gildedRose;

            IList<Item> items = new List<Item>()
            {
                new Item { Name = "Conjured", SellIn = 10, Quality = 20 }
            };

            gildedRose = new GildedRose(items);
            gildedRose.UpdateQuality();

            Assert.True(items[0].Quality == 18, "Quality has not decrease twice fast as normal.");
        }

    }
}
