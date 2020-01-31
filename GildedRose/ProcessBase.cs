using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public abstract class ProcessBase
    {

        public abstract string Name { get; }

        public static void IncreaseQualityUntil50(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        public static void DecreaseQualityUntil0(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
        }

        public void Update(Item item)
        {
            UpdateQuality(item);

            UpdateSellin(item);
        }
        protected abstract void UpdateQuality(Item item);
               

        protected virtual void UpdateSellin(Item item)
        {
            item.SellIn = item.SellIn - 1;
        }
    }
}
