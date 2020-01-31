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
                if (!IsSulfuras(item.Name))
                {

                    if (IsAgedBrie(item.Name))
                    {
                        IncreaseQualityUntil50(item);
                        if (item.SellIn <= 0)
                        {
                            IncreaseQualityUntil50(item);
                        }
                    }
                    else if (IsBackstagePass(item.Name))
                    {
                        if (item.SellIn <= 0)
                        {
                            item.Quality = 0;
                        }
                        else
                        {
                            IncreaseQualityUntil50(item);
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
                    else
                    {
                        DecreaseQualityIfApplicable(item);
                        if (item.SellIn <= 0)
                        {
                            DecreaseQualityIfApplicable(item);
                        }
                    }
                
                    item.SellIn = item.SellIn - 1;
                    
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

        public static void DecreaseQualityIfApplicable(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }
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
