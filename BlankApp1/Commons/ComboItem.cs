using BlankApp1.Statics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Commons
{
    public class ComboItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string DispName
        {
            get
            {
                return !String.IsNullOrEmpty(ID) ? ID + "：" + Name :
                       !string.IsNullOrEmpty(Name) ? Name : "";
            }
        }

        public ComboItem(string id, string name)
        {
            this.ID = id;
            this.Name = name;
        }
    }

    public class CreateComboItem
    {
        public List<ComboItem> CurrencyItems()
        {
            return new List<ComboItem>()
            {
                new ComboItem("", ""),
                new ComboItem(ConstValues.YEN, ConstValues.YEN_JP),
                new ComboItem(ConstValues.DOLLAR, ConstValues.DOLLAR_JP),
                new ComboItem(ConstValues.EURO, ConstValues.EURO_JP),
                new ComboItem(ConstValues.GEN, ConstValues.GEN_JP)
            };
        }
    }
}
