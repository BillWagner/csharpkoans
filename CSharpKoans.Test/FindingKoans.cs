using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CSharpKoans.Core;

namespace CSharpKoans.Test
{

    public class TestContainer : KoanContainer
    {
        [Koan]
        public void Koan1()
        { }

        [Koan]
        public void Koan2()
        { }
    }

    public class TestContainer2 : KoanContainer
    {

        [Koan]
        public void Z()
        { }

        [Koan]
        public void A()
        { }

        [Koan]
        public void a()
        { }

        [Koan]
        public void _0()
        { }

      
    }

    [TestFixture]
    public class FindingKoans
    {
        private IList<string> GetKoanNames(KoanContainer container)
        {
           var names = from x in KoanContainer.FindKoanMethods(container) select x.Name;
           return names.ToList();
          
        }


        [Test]
        public void GettingKoansFromAContainer()
        {
            var koanNames = GetKoanNames(new TestContainer());

            var expected = new[] { "Koan1", "Koan2" };
            Assert.AreEqual(expected, koanNames);
        }


        [Test]
        public void KoansAreReturnedInDefinedOrderRegardlessOfName()
        {
            var koanNames = GetKoanNames(new TestContainer2());

            var expected = new[] { "Z", "A", "a", "_0" };
            Assert.AreEqual(expected, koanNames);
                    
        }
 
    }
}
