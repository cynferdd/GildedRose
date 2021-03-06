﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class BackstagePassProcess : ProcessBase
    {
        public override string Name { get { return "Backstage passes to a TAFKAL80ETC concert"; } }

        protected override void UpdateQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else
            {
                IncreaseQualityUntil50(item);
                if (item.SellIn <= 10)
                {
                    IncreaseQualityUntil50(item);
                }

                if (item.SellIn <= 5)
                {
                    IncreaseQualityUntil50(item);
                }
            }
        }
    }
}
