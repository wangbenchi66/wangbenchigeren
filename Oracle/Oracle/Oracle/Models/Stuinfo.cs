using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Oracle.Models
{
    public class Stuinfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Sex { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        [DisplayName("所在班级")]
        public int CId { get; set; }
        //public int constraint { get; set; }
        public DateTime AddTime { get; set; }
    }
}