using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUnitTest
{
    public class Calculator
    {
        static void Main(string[] args)
        {
            Calculator cal = new Calculator();
            int result = cal.Add(2, 3);
            Console.WriteLine(result);
            Console.ReadKey(true); 
        }
        
        /// <summary>
        /// 加法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Add(int a, int b)
        {
            return a + b;
        }

        /// <summary>
        /// 减法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Minus(int a, int b)
        {
            return a - b;
        }

        /// <summary>
        /// 乘法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Multiply(int a, int b)
        {
            return a * b; 
        }

        /// <summary>
        /// 除法
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public int Divide(int a, int b)
        {
            return a / b; 
        }
　　　　　　　 

　

　　　　　　

    }
}
