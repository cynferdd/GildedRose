using System;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class SulfurasProcess : ProcessBase
    {
        public override string Name { get { return "Sulfuras, Hand of Ragnaros"; } }

        public override void UpdateQuality(Item item)
        {
            // nothing ever changes for Sulfuras as it's a legendary item
        }

        public override void UpdateSellin(Item item)
        {
            // nothing ever changes for sulfuras as it's a legendary item
        }
    }
}
