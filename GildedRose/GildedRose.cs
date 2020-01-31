using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                if (!IsAgedBrie(item.Name) && !IsBackstagePass(item.Name))
                {
                    item.Quality = DecreaseQualityIfApplicable(item);
                }
                else
                {
                    IncreaseQualityUntil50(item);
                    if (IsBackstagePass(item.Name))
                    {

                        if (item.SellIn < 11)
                        {
                            IncreaseQualityUntil50(item);
                        }

                        if (item.SellIn < 6)
                        {
                            IncreaseQualityUntil50(item);
                        }
                    }
                }

                if (!IsSulfuras(item.Name))
                {
                    item.SellIn = item.SellIn - 1;
                }

                if (item.SellIn < 0)
                {
                    if (!IsAgedBrie(item.Name))
                    {
                        if (!IsBackstagePass(item.Name))
                        {
                            item.Quality = DecreaseQualityIfApplicable(item);
                        }
                        else
                        {
                            item.Quality = 0;
                        }
                    }
                    else
                    {
                        IncreaseQualityUntil50(item);
                    }
                }
            }
        }

        public static void IncreaseQualityUntil50(Item item)
        {
            if (item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }
        }

        public static int DecreaseQualityIfApplicable(Item item)
        {
            if (ShouldDecreaseQuality(item))
            {
                return item.Quality - 1;
            }
            else
            {
                return item.Quality;
            }
        }

        public static bool ShouldDecreaseQuality(Item item)
        {
            return item.Quality > 0 && !IsSulfuras(item.Name);
        }

        public static bool IsAgedBrie(string name)
        {
            return name == "Aged Brie";
        }

        public static bool IsBackstagePass(string name)
        {
            return name == "Backstage passes to a TAFKAL80ETC concert";
        }

        public static bool IsSulfuras(string name)
        {
            return name == "Sulfuras, Hand of Ragnaros";
        }
    }
}
