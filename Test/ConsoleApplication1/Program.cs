using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static void Main(string[] args)
        {
            string dt = System.DateTime.Now.ToShortTimeString();
            Test t = new Test();
            t.test1 = 11;
            t.test2 = "aa";
            t.test3 = System.DateTime.Now;


            changeTest(t);
            int a = t.test1;

            Test3 t3 = new Test3();
            t3.test();
            Console.ReadLine();
        }

        public static void changeTest(Test t)
        {
            t.test1 = 22;
            newTest nt = new newTest();
            nt.newTest4 = t;
            nt.newTest4.test1 = 33;
        }
    }

    public class BookOrderException : Exception
    {
        public BookOrderException(string t)
            : base(t)
        {

        }
    }

    class Test
    {
        public int test1 { get; set; }
        public string test2 { get; set; }
        public DateTime test3 { get; set; }
        
    }

    class newTest
    {
        public int newTest1 { get; set; }
        public string newTest2 { get; set; }
        public DateTime newTest3 { get; set; }
        public Test newTest4 { get; set; }
    }

    class Test3 : Test4
    {
        public void test()
        {
            this.aaa();
            base.aaa();
        }

        public override void aaa()
        {
            Console.WriteLine("son");
        }

    }

    class Test4
    {
        public virtual void aaa()
        {
            Console.WriteLine("father");
        }
    }
}
