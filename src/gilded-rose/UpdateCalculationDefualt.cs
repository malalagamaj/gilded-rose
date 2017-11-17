using System;
using System.Collections.Generic;
using System.Text;

namespace gilded_rose
{
    public class UpdateCalculationDefualt : IUpdateCalculation
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > 0)
            {
                item.Quality = item.Quality - 1;
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                if (item.Quality > 0)
                {
                    item.Quality = item.Quality - 1;
                }
            }

        }
    }
}
