using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnitTest;

namespace NUnitTestTest
{
    [TestFixture]
    public class NUnitTestTest
    {
        //[Category(string name)]，利用这个分类属性，我们可以为每个方法定义类别。
        [Test, Category("Category B")]
        public void TestAdd()
        {
            Calculator cal = new Calculator();
            int expected = 5;
            int actual = cal.Add(2, 3);
            Assert.AreEqual(expected, actual);
            //Assert.AreEqual是断言，在测试框架中，断言是单元测试的核心，我们在测试中要对其程序断言。如果某个断言失败，方法的调用不会返回值，并且会报告一个错误。如果一个测试包含多个断言，那些紧跟失败断言的那些断言都不会执行，因此每个测试方法最好只有一个断言。 NUnit.Framework.Assert有23个重载方法，大部分的情况它都有考虑到，当然，不排除需要自己写一个复杂的断言方法。
        }
        [Test, Category("Category B")]
        public void TestMinus()
        {
            Calculator cal = new Calculator();
            int expected = 5;
            int actual = cal.Minus(10, 5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestMultiply()
        {
            Calculator cal = new Calculator();
            int expected = 5;
            int actual = cal.Multiply(1, 5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void TestDivide()
        {
            Calculator cal = new Calculator();
            int expected = 5;
            int actual = cal.Divide(25, 0);
            Assert.AreEqual(expected, actual);
        }

        //要想让一个测试方法不在NUnit中显示，也不运行，我们应该使用[Ignore]属性
        [Ignore]
        public void TestDivide2()
        {
            Calculator cal = new Calculator();
            int expected = 5;
            int actual = cal.Divide(25, 0);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        [Explicit]
        public void TestDivide3()
        {
            Calculator cal = new Calculator();
            int expected = 5;
            int actual = cal.Divide(25, 0);
            Assert.AreEqual(expected, actual);
        }

        //[SetUp]的意思就是指在运行每个测试方法前执行它。相应的，有开始必然有结束，[TearDown]是指在每个测试方法结束后运行。
        [SetUp]
        public void InitMethod()
        {
            Console.WriteLine("Initialization method");
        }

        [TearDown]
        public void FinalizeMethod()
        {
            Console.WriteLine("Finalize method");
        }

        //[TestFixtureSetUp]是指在这个测试类的整个生命周期中，它在所有的测试方法之前运行一次，而[TestFixtureTearDown]是在所有的测试方法都结束时运行。

        [TestFixtureSetUp]
        public void InitClass()
        {
            Console.WriteLine("执行TestFixtureSetUp");
        }

        [TestFixtureTearDown]
        public void FinalizeClass()
        {
            Console.WriteLine("执行TestFixtureTearDown");
        }
    }
}
