using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFFDCC_HFT_2021221.Logic
{
    public class BrandPopularity
    {
        public string brandName;
        public int brandCount;
        public override bool Equals(object obj)
        {
            if (obj is BrandPopularity)
            {
                BrandPopularity other = obj as BrandPopularity;

                return this.brandName == other.brandName &&
                    this.brandCount == other.brandCount;
            }
            return false;
        }
    }
}
