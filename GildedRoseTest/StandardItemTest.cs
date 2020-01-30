using GildedRose;
using NUnit.Framework;
using System.Collections.Generic;

namespace GildedRoseTest
{
    public class StandardItemTest : BaseTest
    {
        

        [Test]
        public void ShouldNotDecreaseQuality_WhenQualityAt0()
        {
            Item item = InitTestItem(0, 4);

            UpdateQualityItem(item);

            Assert.AreEqual(0, item.Quality);
        }

        

        [Test]
        public void ShouldDecreaseQuality_WhenQualityAbove0()
        {
            Item item = InitTestItem(1, 4);

            UpdateQualityItem(item);

            Assert.AreEqual(0, item.Quality);
        }

        

        [Test]
        public void ShouldDecreaseSellIn_WhenQualityUpdated()
        {
            Item item = InitTestItem(2, 0);
            

            UpdateQualityItem(item);

            Assert.AreEqual(-1, item.SellIn);
        }

        [Test]
        [TestCase(-1, 0)]
        [TestCase(0, 0)]
        public void ShouldDecreaseDoubleQuality_WhenSellinIsNegativeOr0(int sellin, int expectedResult)
        {
            Item item = InitTestItem(2, sellin);
            
            UpdateQualityItem(item);

            Assert.AreEqual(expectedResult, item.Quality);
        }

        

        

        private static Item InitTestItem(int quality, int sellin)
        {
            return new Item()
            {
                Name = "test",
                Quality = quality,
                SellIn = sellin
            };
        }

        

        

        

        
    }
}