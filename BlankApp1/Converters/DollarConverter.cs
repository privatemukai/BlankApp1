using BlankApp1.Interfaces;
using BlankApp1.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Converters
{
    public class DollarConverter : IConverterBase
    {        
        public string UnitName { get { return ConstValues.DOLLAR_JP; } }
        public IRateTrancition RateTrancition { get; private set; }
        public bool IsMyUnit(string name)
        {
            return name.ToUpper() == ConstValues.DOLLAR;
        }

        public void SetRateTrancition(IRateTrancition rateTrancition)
        {
            RateTrancition = rateTrancition;
        }
    }
}
