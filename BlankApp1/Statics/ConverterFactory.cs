using BlankApp1.Converters;
using BlankApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statics.BlankApp1
{
    static class ConverterFactory
    {
        // 各通貨コンバーターのインスタンスを予め配列にセットしておく
        private static IConverterBase[] _converters = new IConverterBase[]
        {
            new YenConverter(),
            new DollarConverter(),
            new EuroConverter(),
            new GenConverter(),
        };

        /// <summary>
        /// 変換元通貨名から対応する通貨コンバーターを返します。
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IConverterBase GetInstance(string name)
        {
            return _converters.FirstOrDefault(x => x.IsMyUnit(name));
        }
    }
}
