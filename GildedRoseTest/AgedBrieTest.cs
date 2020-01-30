﻿using GildedRose;
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


        [Test]
        public void ShouldBeTrue_WhenItemNameIsAgedBrie()
        {
            Item item = InitAgredBrie(0, 0);

            bool result = GildedRose.GildedRose.IsAgedBrie(item.Name);

            Assert.IsTrue(result);
        }

        [Test]
        public void ShouldBeFalse_WhenItemNameIsAnythingButAgedBrie()
        {
            Item item = new Item() { Name = "test" };

            bool result = GildedRose.GildedRose.IsAgedBrie(item.Name);

            Assert.IsFalse(result);
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
