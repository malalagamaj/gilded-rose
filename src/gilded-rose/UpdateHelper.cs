using System;
using System.Collections.Generic;
using System.Text;

namespace gilded_rose
{
    public static class UpdateHelper
    {
        public static IUpdateCalculation UpdateQualityMethodFactory(this Item item)
        {
            IUpdateCalculation calculationStrategy = null;
            switch (item.Name) { 
                case "Aged Brie":
                    calculationStrategy = new UpdateCalculationAgedBrie();
                    break;
                case "Conjured":
                    calculationStrategy = new UpdateCalculationConjured();
                    break;
                case "Sulfuras, Hand of Ragnaros":
                    calculationStrategy = new UpdateCalculationSulfuras();
                    break;
                case "Backstage passes to a TAFKAL80ETC concert":
                    calculationStrategy = new UpdateCalculationBackStage();
                    break;
                default:
                    calculationStrategy = new UpdateCalculationDefualt();
                    break;
            }

            return calculationStrategy;
        }
    }
}
