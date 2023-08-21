using BlankApp1.Interfaces;
using BlankApp1.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Models
{
    public class RateTrancition : IRateTrancition
    {
        // 通貨種別
        public String Currency { get; }
        // 対象日
        public DateTime Date { get; }
        // レート
        public double Rate { get; }

        public RateTrancition(string currency, DateTime date, double rate)
        {
            Currency = currency;
            Date = date;
            Rate = rate;
        }
    }

    /// <summary>
    /// レートデータベース（2023/08/01～2023/08/18土日祝除く）
    /// </summary>
    public class RateTrancitionList
    {
        public List<RateTrancition> RateTrancitions;
        public RateTrancitionList()
        {
            RateTrancitions = new List<RateTrancition>() {
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 1),  142.44),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 2),  143.20),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 3),  143.47),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 4),  142.88),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 7),  141.67),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 8),  143.07),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 9),  143.47),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 10), 143.97),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 14), 145.11),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 15), 145.60),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 16), 145.72),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 17), 146.50),
                new RateTrancition(ConstValues.DOLLAR, new DateTime(2023, 8, 18), 145.72),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 1),  156.51),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 2),  157.45),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 3),  156.93),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 4),  156.45),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 7),  155.96),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 8),  157.23),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 9),  157.26),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 10), 157.95),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 14), 158.72),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 15), 158.78),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 16), 158.85),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 17), 159.23),
                new RateTrancition(ConstValues.EURO,   new DateTime(2023, 8, 18), 158.63),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 1),  19.9),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 2),  19.94),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 3),  19.94),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 4),  19.93),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 7),  19.7),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 8),  19.85),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 9),  19.81),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 10), 19.94),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 14), 19.97),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 15), 20.01),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 16), 19.9),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 17), 19.96),
                new RateTrancition(ConstValues.GEN,    new DateTime(2023, 8, 18), 19.99)
            };
        }

        /// <summary>
        /// 通貨種別と日付からレート情報を取得します。
        /// 通貨種別が円の場合は強制的にレート1を返します。
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public RateTrancition GetRateTrancition(string currency, DateTime date)
        {
            return currency != ConstValues.YEN ? 
                RateTrancitions.FirstOrDefault(x => x.Currency == currency && x.Date == date) : 
                new RateTrancition(ConstValues.YEN, date, 1);
        }

        /// <summary>
        /// 通貨種別と日付に一致するレート情報の存在チェックを行います。
        /// 通貨種別が円の場合は強制的にtrueを返します。
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public bool RateTrancitionExists(string currency, DateTime date)
        {
            return currency != ConstValues.YEN ? 
                RateTrancitions.Any(x => x.Date == date) : true;
        }
    }
}
