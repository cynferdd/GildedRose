using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;
        IList<ProcessBase> processList;

        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
            this.processList = new List<ProcessBase>
            {
                new AgedBrieProcess(),
                new BackstagePassProcess(),
                new StandardProcess(),
                new SulfurasProcess()
            };
        }

        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                var defaultProcess = processList.FirstOrDefault(proc => string.IsNullOrWhiteSpace(proc.Name));
                var process = processList.FirstOrDefault(proc => string.Equals(proc.Name, item.Name)) ?? defaultProcess;
                if (process != null)
                {
                    process.Update(item);
                }
            }
        }

        
    }
}
