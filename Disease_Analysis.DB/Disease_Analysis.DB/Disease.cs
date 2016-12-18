using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Disease_Analysis.DB
{
    public class Disease
    {
        public int id { get; set; }
        public string disease { get; set; }
        public string description { get; set; }
        public string symptoms { get; set; }
    }
}
