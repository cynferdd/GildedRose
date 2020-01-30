using GildedRose;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseTest
{
    class ConcertPassTest : BaseTest
    {


        [Test]
        [TestCase(14, 44)]
        [TestCase(11, 44)]
        public void ShouldIncreaseQualityBy1_WhenItemIsConcertPassAndSellinIsAbove10(int sellin, int expectedResult)
        {
            Item item = InitBackstagePass(sellin);

            UpdateQualityItem(item);

            Assert.AreEqual(expectedResult, item.Quality);
        }

        [Test]
        [TestCase(10, 45)]
        [TestCase(9, 45)]
        [TestCase(6, 45)]
        public void ShouldIncreaseQualityBy2_WhenItemIsConcertPassAndSellinIs10OrLess(int sellin, int expectedResult)
        {
            Item item = InitBackstagePass(sellin);

            UpdateQualityItem(item);

            Assert.AreEqual(expectedResult, item.Quality);
        }



        [Test]
        [TestCase(5, 46)]
        [TestCase(3, 46)]
        [TestCase(1, 46)]
        public void ShouldIncreaseQualityBy3_WhenItemIsConcertPassAndSellinIs5OrLess(int sellin, int expectedResult)
        {
            Item item = InitBackstagePass(sellin);

            UpdateQualityItem(item);

            Assert.AreEqual(expectedResult, item.Quality);
        }

        [Test]
        [TestCase(0, 0)]
        [TestCase(-3, 0)]
        public void ShouldGetQualityAt0_WhenItemIsConcertPassAndSellinIs0OrLess(int sellin, int expectedResult)
        {
            Item item = InitBackstagePass(sellin);

            UpdateQualityItem(item);

            Assert.AreEqual(expectedResult, item.Quality);
        }


        [Test]
        public void ShouldBeTrue_WhenItemNameIsBackstagePass()
        {
            Item item = InitBackstagePass(0);

            bool result = GildedRose.GildedRose.IsBackstagePass(item.Name);

            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldBeFalse_WhenItemNameIsAnythingButBackstagePass()
        {
            Item item = new Item() { Name = "test" };

            bool result = GildedRose.GildedRose.IsBackstagePass(item.Name);

            Assert.IsFalse(result);
        }

        private static Item InitBackstagePass(int sellin)
        {

            return new Item()
            {
                Name = "Backstage passes to a TAFKAL80ETC concert",
                Quality = 43,
                SellIn = sellin
            };
        }
    }
}
