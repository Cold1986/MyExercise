﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 单件模式_Singleton_Pattern_
{
    class Program
    {
        static void Main(string[] args)
        {
            CountMutilThread cmt = new CountMutilThread();

            cmt.StartMain();

            Console.ReadLine();
        }
    }
}
