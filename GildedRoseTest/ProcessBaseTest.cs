using GildedRose;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseTest
{
    public class ProcessBaseTest
    {       

        [Test]
        public void ShouldDecreaseQuality_WhenItemIsNotSulfurasAndQualityIsAbove0()
        {
            Item item = new Item()
            {
                Name = "test",
                Quality = 2
            };

            ProcessBase.DecreaseQualityUntil0(item);

            Assert.AreEqual(1, item.Quality);
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

            ProcessBase.DecreaseQualityUntil0(item);

            Assert.AreEqual(0, item.Quality);
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

            ProcessBase.DecreaseQualityUntil0(item);

            Assert.AreEqual(-1, item.Quality);
        }

        
        [Test]
        public void ShouldIncreaseQuality_WhenQualityUnder50()
        {
            Item item = new Item() { Quality = 7 };

            ProcessBase.IncreaseQualityUntil50(item);

            Assert.AreEqual(8, item.Quality);
        }

        [Test]
        [TestCase(50)]
        [TestCase(500)]
        public void ShouldNotChangeQuality_WhenQualityIs50OrAbove(int quality)
        {
            Item item = new Item() { Quality = quality };

            ProcessBase.IncreaseQualityUntil50(item);

            Assert.AreEqual(quality, item.Quality);
        }
    }
}
