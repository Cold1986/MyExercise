using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 单件模式
{
    ///延迟初始化单例模式
    public sealed class CountSigleton
    {

        ///存储唯一的实例
        //static CountSigleton uniCounter = new CountSigleton();

        ///存储计数值 
        private int totNum = 0;

        public CountSigleton()
        {
            ///线程延迟2000毫秒 
            Thread.Sleep(2000);
        }

        public static CountSigleton Instance
        {
            get
            {
                return Nested.instance;
            }
        }

        public void Add()
        {
            totNum++;
        }

        public int GetCounter()
        {
            return totNum;
        }
    }

    class Nested
    {
        static Nested()
        {

        }

        internal static readonly CountSigleton instance = new CountSigleton();
    }
}
