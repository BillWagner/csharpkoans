using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CSharpKoans.Core;

namespace CSharpKoans.Test
{

    public class ContainerOne : KoanContainer
    {
        [Koan]
        public string One()
        { return "FTW!"; }


        [Koan]
        public string Two()
        { return "FTW!"; }

        [Koan]
        public string Three()
        { return "FTW!"; }




    }

    public class ContainerTwo : KoanContainer
    {

        [Koan]
        public string Four()
        {
            return "FTW";
        }

        [Koan]
        public void Five()
        {
            Assert.Fail("Expected");
        }
        [Koan]
        public string Six()
        {
            return "FTW!";
        }




    }

    [TestFixture]
    public class GettingTheWholeOutput
    {
        [Test]
        public void OutputContainsContainerNameFollowedByKoanResultsAndStopsOnFailure()
        {
            var runner = new KoanRunner(new List<KoanContainer> { new ContainerOne(), new ContainerTwo() });

            var result = runner.ExecuteKoans();

            var expected =
     @"

When contemplating ContainerOne:
    One has expanded your awareness.
    Two has expanded your awareness.
    Three has expanded your awareness.

When contemplating ContainerTwo:
    Four has expanded your awareness.
    Five has damaged your karma.";



            Assert.AreEqual(expected, result.Message);
        }



    }


}
