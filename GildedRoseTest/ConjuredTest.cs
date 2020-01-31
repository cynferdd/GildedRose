using GildedRose;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseTest
{
    public class ConjuredTest : BaseTest
    {


        [Test]
        public void ShouldNotDecreaseQuality_WhenQualityAt0()
        {
            Item item = InitTestItem(0, 4);

            UpdateItem(item);

            Assert.AreEqual(0, item.Quality);
        }



        [Test]
        public void ShouldDecreaseQuality_WhenQualityAbove0()
        {
            Item item = InitTestItem(3, 4);

            UpdateItem(item);

            Assert.AreEqual(1, item.Quality);
        }



        [Test]
        public void ShouldDecreaseSellIn_WhenQualityUpdated()
        {
            Item item = InitTestItem(4, 0);


            UpdateItem(item);

            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        [TestCase(-1)]
        [TestCase(0)]
        public void ShouldDecreaseQuadrupleQuality_WhenSellinIsNegativeOr0(int sellin)
        {
            Item item = InitTestItem(6, sellin);

            UpdateItem(item);

            Assert.AreEqual(2, item.Quality);
        }


        private static Item InitTestItem(int quality, int sellin)
        {
            return new Item()
            {
                Name = "Conjured",
                Quality = quality,
                SellIn = sellin
            };
        }

    }
}
