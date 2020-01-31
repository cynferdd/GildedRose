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
        private readonly ProcessBase sulfuras;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            agedBrie = new AgedBrieProcess();
            backstagePass = new BackstagePassProcess();
            standardItem = new StandardProcess();
            sulfuras = new SulfurasProcess();
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                if (item.Name != sulfuras.Name)
                {
                    if (item.Name == agedBrie.Name)
                    {
                        agedBrie.UpdateQuality(item);
                    }
                    else if (item.Name == backstagePass.Name)
                    {
                        backstagePass.UpdateQuality(item);
                    }
                    else
                    {
                        standardItem.UpdateQuality(item);
                    }

                    item.SellIn = item.SellIn - 1;
                }
            }
        }

        
    }
}
