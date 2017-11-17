using System;
using System.Collections.Generic;
using System.Text;

namespace gilded_rose
{
    public class UpdateCalculationConjured : IUpdateCalculation
    {
        public void UpdateQuality(Item item)
        {
            item.Quality = item.Quality - 2; 
        }
    }
}
