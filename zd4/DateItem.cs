using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd4
{
    public class DateItem
    {
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public override string ToString() => $"{Date.ToShortDateString()}: {Description}";
    }
}
