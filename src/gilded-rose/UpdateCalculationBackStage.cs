﻿using System;
using System.Collections.Generic;
using System.Text;

namespace gilded_rose
{
    public class UpdateCalculationBackStage : IUpdateCalculation
    {
        public void UpdateQuality(Item item)
        {
            if(item.Quality < 50 )
            {
                item.Quality = item.Quality + 1;
            }

            if (item.SellIn < 11)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            if (item.SellIn < 6)
            {
                if (item.Quality < 50)
                {
                    item.Quality = item.Quality + 1;
                }
            }

            item.SellIn = item.SellIn - 1;

            if (item.SellIn < 0)
            {
                item.Quality = item.Quality - item.Quality;
            }


        }
    }
}
