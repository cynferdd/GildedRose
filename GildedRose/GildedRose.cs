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
                if (!IsAgedBrie(Items[i].Name) && !IsBackstagePass(Items[i].Name))
                {
                    Items[i].Quality = DecreaseQualityIfApplicable(Items[i]);
                }
                else
                {
                    if (Items[i].Quality < 50)
                    {
                        Items[i].Quality = Items[i].Quality + 1;

                        if (IsBackstagePass(Items[i].Name))
                        {
                            if (Items[i].SellIn < 11)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }

                            if (Items[i].SellIn < 6)
                            {
                                if (Items[i].Quality < 50)
                                {
                                    Items[i].Quality = Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if (!IsSulfuras(Items[i].Name))
                {
                    Items[i].SellIn = Items[i].SellIn - 1;
                }

                if (Items[i].SellIn < 0)
                {
                    if (!IsAgedBrie(Items[i].Name))
                    {
                        if (!IsBackstagePass(Items[i].Name))
                        {
                            Items[i].Quality = DecreaseQualityIfApplicable(Items[i]);
                        }
                        else
                        {
                            Items[i].Quality = Items[i].Quality - Items[i].Quality;
                        }
                    }
                    else
                    {
                        if (Items[i].Quality < 50)
                        {
                            Items[i].Quality = Items[i].Quality + 1;
                        }
                    }
                }
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
