using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Interfaces
{
    public interface IConverterBase
    {        
        // 通貨の単位名（円、ドル、ユーロ、元）
        public string UnitName { get; }
        // レート情報（日付とレート）
        public IRateTrancition RateTrancition { get; }

        public void SetRateTrancition(IRateTrancition rateTrancition);
        public bool IsMyUnit(string name);        

        /// <summary>
        /// 円からの変換（今回は共通なので具体的な処理を書きました。）
        /// </summary>
        /// <param name="yen"></param>
        /// <returns></returns>
        public double FromYen(double yen)
        {
            return yen / RateTrancition.Rate;
        }

        /// <summary>
        /// 円への変換（今回は共通なので具体的な処理を書きました。）
        /// </summary>
        /// <param name="currency"></param>
        /// <returns></returns>
        public double ToYen(double currency)
        {
            return currency * RateTrancition.Rate;
        }
    }
}
