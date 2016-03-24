using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 单件模式
{
    /// <summary>
    /// 功能：创建一个多线程计数的类
    /// </summary>
    public class CountMutilThread
    {
        public CountMutilThread()
        {

        }

        /// <summary>
        /// 线程工作
        /// </summary>
        public static void DoSomeWork()
        {
            ///构造显示字符串
            string results = "";
            CountSigleton aa = new CountSigleton();
            CountSigleton MyCounter = CountSigleton.Instance;

            for (int i = 1; i < 5; i++)
            {
                ///开始计数
                MyCounter.Add();

                results += "线程";
                results += Thread.CurrentThread.Name.ToString() + "——〉";
                results += "当前的计数：";
                results += MyCounter.GetCounter().ToString();
                results += "\n";

                Console.WriteLine(results);

                ///清空显示字符串
                results = "";
            }
        }

        public void StartMain()
        {
            Thread.CurrentThread.Name = "Thread 0";
            Thread thread1 = new Thread(new ThreadStart(DoSomeWork));
            thread1.Name = "Thread 1";
            thread1.Start();

            ///线程延迟2000毫秒 
            Thread.Sleep(2000);
            Thread thread2 = new Thread(new ThreadStart(DoSomeWork));
            thread2.Name = "Thread 2";
            thread2.Start();

            DoSomeWork(); 
        }
    }
}
