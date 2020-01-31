using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class StandardProcess : ProcessBase
    {
        public override string Name { get { return ""; } }

        protected override void UpdateQuality(Item item)
        {
            DecreaseQualityUntil0(item);
            if (item.SellIn <= 0)
            {
                DecreaseQualityUntil0(item);
            }
        }
    }
}
