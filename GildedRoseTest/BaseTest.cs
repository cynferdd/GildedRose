using GildedRose;
using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRoseTest
{
    public abstract class BaseTest
    {
        protected static void UpdateItem(Item item)
        {
            GildedRose.GildedRose rose = new GildedRose.GildedRose(new List<Item>() { item });

            rose.UpdateQuality();
        }
    }
}
