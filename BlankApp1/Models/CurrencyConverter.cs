using BlankApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Models
{
    public class CurrencyConverter
    {
        // 変換元継承クラスを格納する
        public IConverterBase From { get; private set; }
        // 変換後継承クラスを格納する
        public IConverterBase To { get; private set; }
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public CurrencyConverter(IConverterBase from, IConverterBase to)
        {
            this.From = from;
            this.To = to;
        }

        /// <summary>
        /// 単位変換処理を行います。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public double Convert(double value)
        {
            // 円に変換した後、目的の通貨に変換する。
            var yen = From.ToYen(value);
            return To.FromYen(yen);
        }
    }
}
