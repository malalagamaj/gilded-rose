using System.Collections.Generic;

namespace gilded_rose
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
                IUpdateCalculation updateCalculation = Items[i].UpdateQualityMethodFactory();
                updateCalculation.UpdateQuality(Items[i]);
            }
        }

    }
}