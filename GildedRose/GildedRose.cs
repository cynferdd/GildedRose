using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        private readonly ProcessBase agedBrie;
        private readonly ProcessBase backstagePass;
        private readonly ProcessBase standardItem;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            agedBrie = new AgedBrieProcess();
            backstagePass = new BackstagePassProcess();
            standardItem = new StandardProcess();
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
                        agedBrie.Update(item);
                    }
                    else if (IsBackstagePass(item.Name))
                    {
                        backstagePass.Update(item);
                    }
                    else
                    {
                        standardItem.Update(item);
                    }

                    item.SellIn = item.SellIn - 1;
                }
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
