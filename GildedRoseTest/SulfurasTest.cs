using GildedRose;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseTest
{
    class SulfurasTest : BaseTest
    {

        [Test]
        public void ShouldNeverChangeQuality_WhenItemIsSulfuras()
        {
            Item item = InitSulfuras();

            UpdateQualityItem(item);

            Assert.AreEqual(43, item.Quality);
        }

        [Test]
        public void ShouldNeverChangeSellIn_WhenItemIsSulfuras()
        {
            Item item = InitSulfuras();

            UpdateQualityItem(item);

            Assert.AreEqual(4, item.SellIn);
        }

        
        private static Item InitSulfuras()
        {
            return new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = 43,
                SellIn = 4
            };
        }
    }
}
