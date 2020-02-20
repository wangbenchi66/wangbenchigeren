using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL
{
    public class Student
    {
        private int _ID;

        public int id
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        private string _Sex;

        public string Sex
        {
            get { return _Sex; }
            set { _Sex = value; }
        }
    }
}
