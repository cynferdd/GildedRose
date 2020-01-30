using GildedRose;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseTest
{
    public class GeneralRulesTest
    {
        [Test]
        public void ShouldBeTrue_WhenItemIsNotSulfurasAndQualityIsAbove0()
        {
            Item item = new Item()
            {
                Name = "test",
                Quality = 2
            };

            bool result = GildedRose.GildedRose.ShouldDecreaseQuality(item);

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("test")]
        [TestCase("Sulfuras, Hand of Ragnaros")]
        public void ShouldBeFalse_WhenItemQualityIs0RegardlessOfName(string name)
        {
            Item item = new Item()
            {
                Name = name,
                Quality = 0
            };

            bool result = GildedRose.GildedRose.ShouldDecreaseQuality(item);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase("test")]
        [TestCase("Sulfuras, Hand of Ragnaros")]
        public void ShouldBeFalse_WhenItemQualityIsUnder0RegardlessOfName(string name)
        {
            Item item = new Item()
            {
                Name = name,
                Quality = -1
            };

            bool result = GildedRose.GildedRose.ShouldDecreaseQuality(item);

            Assert.IsFalse(result);
        }

        [Test]
        [TestCase(2)]
        [TestCase(0)]
        public void ShouldBeFalse_WhenItemIsSulfurasRegardlessOfQuality(int quality)
        {
            Item item = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = quality
            };

            bool result = GildedRose.GildedRose.ShouldDecreaseQuality(item);

            Assert.IsFalse(result);
        }

        [Test]
        public void ShouldDecreaseQuality_WhenItemIsNotSulfurasAndQualityIsAbove0()
        {
            Item item = new Item()
            {
                Name = "test",
                Quality = 2
            };

            int result = GildedRose.GildedRose.DecreaseQualityIfApplicable(item);

            Assert.AreEqual(1, result);
        }


        [Test]
        [TestCase("test")]
        [TestCase("Sulfuras, Hand of Ragnaros")]
        public void ShouldNotChangeQuality_WhenItemQualityIs0RegardlessOfName(string name)
        {
            Item item = new Item()
            {
                Name = name,
                Quality = 0
            };

            int result = GildedRose.GildedRose.DecreaseQualityIfApplicable(item);

            Assert.AreEqual(0, result);
        }

        [Test]
        [TestCase("test")]
        [TestCase("Sulfuras, Hand of Ragnaros")]
        public void ShouldNotChangeQuality_WhenItemQualityIsUnder0RegardlessOfName(string name)
        {
            Item item = new Item()
            {
                Name = name,
                Quality = -1
            };

            int result = GildedRose.GildedRose.DecreaseQualityIfApplicable(item);

            Assert.AreEqual(-1, result);
        }

        [Test]
        [TestCase(2)]
        [TestCase(0)]
        public void ShouldNotChangeQuality_WhenItemIsSulfurasRegardlessOfQuality(int quality)
        {
            Item item = new Item()
            {
                Name = "Sulfuras, Hand of Ragnaros",
                Quality = quality
            };

            int result = GildedRose.GildedRose.DecreaseQualityIfApplicable(item);

            Assert.AreEqual(quality, result);
        }
    }
}
