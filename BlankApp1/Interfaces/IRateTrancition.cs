using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankApp1.Interfaces
{
    public interface IRateTrancition
    {
        public String Currency { get; }
        public DateTime Date { get; }
        public double Rate { get; }
    }
}
