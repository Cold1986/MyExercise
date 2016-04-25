using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 原型模式
{
    class WorkExperience : ICloneable
    {
        private string workDate;
        public string WorkDate
        {
            get { return workDate; }
            set { workDate = value; }
        }

        private string company;
        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public object Clone()
        {
            return (Object)this.MemberwiseClone();
        }
    }
}
