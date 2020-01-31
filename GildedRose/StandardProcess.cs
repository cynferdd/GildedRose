﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class StandardProcess : ProcessBase
    {
        public override string Name { get { return ""; } }

        public override void Update(Item item)
        {
            DecreaseQualityUntil0(item);
            if (item.SellIn <= 0)
            {
                DecreaseQualityUntil0(item);
            }
        }
    }
}
