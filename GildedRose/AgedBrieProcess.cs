using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class AgedBrieProcess : ProcessBase
    {
        public override string Name { get { return "Aged Brie"; } }

        protected override void UpdateQuality(Item item)
        {
            IncreaseQualityUntil50(item);
            if (item.SellIn <= 0)
            {
                IncreaseQualityUntil50(item);
            }
        }
    }
}
