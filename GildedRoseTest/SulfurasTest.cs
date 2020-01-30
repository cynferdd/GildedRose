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

        [Test]
        public void ShouldBeTrue_WhenItemNameIsSulfuras()
        {
            Item item = InitSulfuras();

            bool result = GildedRose.GildedRose.IsSulfuras(item.Name);

            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldBeFalse_WhenItemNameIsAnythingButSulfuras()
        {
            Item item = new Item() { Name = "test" };

            bool result = GildedRose.GildedRose.IsSulfuras(item.Name);

            Assert.IsFalse(result);
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
