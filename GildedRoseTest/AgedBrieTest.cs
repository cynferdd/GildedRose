using GildedRose;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseTest
{
    class AgedBrieTest : BaseTest
    {
        [Test]
        public void ShouldIncreaseQualityBy1_WhenItemIsAgedBrieAndSellinIsNotPassed()
        {
            Item item = InitAgredBrie(2, 3);

            UpdateQualityItem(item);

            Assert.AreEqual(3, item.Quality);
        }


        [Test]
        public void ShouldIncreaseQualityBy2_WhenItemIsAgedBrieAndSellinIsPassed()
        {
            Item item = InitAgredBrie(2, 0);

            UpdateQualityItem(item);

            Assert.AreEqual(4, item.Quality);
        }



        [Test]
        public void ShouldNeverGetQualityHigherThan50_WhenItemIsUpdated()
        {
            Item item = InitAgredBrie(50, 3);

            UpdateQualityItem(item);

            Assert.AreEqual(50, item.Quality);
        }

        private static Item InitAgredBrie(int quality, int sellin)
        {
            return new Item()
            {
                Name = "Aged Brie",
                Quality = quality,
                SellIn = sellin
            };
        }
    }
}
