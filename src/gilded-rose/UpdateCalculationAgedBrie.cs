using System;
using System.Collections.Generic;
using System.Text;

namespace gilded_rose
{
    public class UpdateCalculationAgedBrie : IUpdateCalculation
    {
        public void UpdateQuality(Item item)
        {
            if (item.Quality > -1 && item.Quality < 50)
            {
                item.Quality = item.Quality + 1;
            }

            item.SellIn = item.SellIn - 1; 
        }
    }
}
