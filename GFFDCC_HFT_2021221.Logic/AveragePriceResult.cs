using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Logic
{
    public class AveragePriceResult
    {
        public string Brand { get; set; }
        public double Avgprice { get; set; }
        public override bool Equals(object obj)
        {
            if (obj is AveragePriceResult)
            {
                AveragePriceResult other = obj as AveragePriceResult;

                return this.Brand == other.Brand &&
                    this.Avgprice == other.Avgprice;
            }
            return false;
        }
    }
}
