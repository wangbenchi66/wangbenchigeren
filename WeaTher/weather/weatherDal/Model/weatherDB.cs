using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherDal.Model
{
    public class weatherDB
    {
        public cityInfo cityInfo { get; set; }
        public cityweather data { get; set; }
        public forecast forecast { get; set; }
    }
}
