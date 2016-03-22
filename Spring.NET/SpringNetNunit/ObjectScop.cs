using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Spring.Context;
using Spring.Context.Support;
using Spring.Objects.Factory;

namespace SpringNetNunit
{
    [TestFixture]
    public class ObjectScop
    {
        //[Test]
        public void CreateWithSingleton()
        {
            string[] xmlFiles = new string[] 
            {
                "assembly://SpringNetNunit/SpringNetNunit/Objects.xml"
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            object obj1 = factory.GetObject("personDao");
            object obj2 = factory.GetObject("personDao");
            Assert.AreEqual(obj1, obj2);
        }

        //[Test]
        public void CreateWithOutSingleton()
        {
            string[] xmlFiles = new string[] 
            {
                "assembly://SpringNetNunit/SpringNetNunit/Objects.xml"
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;
            object obj1 = factory.GetObject("person");
            object obj2 = factory.GetObject("person");
            Assert.AreNotEqual(obj1, obj2);
        }

        [Test]
        public void CreateWithLazy()
        {
            string[] xmlFiles = new string[] 
            {
                "assembly://SpringNetNunit/SpringNetNunit/Objects.xml"
            };
            IApplicationContext context = new XmlApplicationContext(xmlFiles);

            IObjectFactory factory = (IObjectFactory)context;

            object dao = factory.GetObject("personDao");
            Console.WriteLine(dao.ToString());

            object server = factory.GetObject("personServer");
            Console.WriteLine(server.ToString());
        }
    }
}
