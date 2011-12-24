using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CSharpKoans.Core;

namespace CSharpKoans.Test
{
    
    class FailureContainer  : KoanContainer
    {
        [Koan]
        public void FailureKoan()
        {
            Assert.Fail("expected failure");
        }
    }

   
    class SuccessContainer : KoanContainer
    {
         [Koan]
        public string SuccessKoan()
        {
            return "FTW!";
        }
    }

   
    class SomeSuccesses : KoanContainer
    {
         [Koan]
        public string One()
        {
            return "YAY!";
        }
         [Koan]
        public string Two()
        {
            return "WOOT!";
        }
    }

    
    class MixedBag : KoanContainer
    {
        [Koan]
        public string One()
        {
            Assert.Fail("Game over");
            return "game over";
        }
        [Koan]
        public string Two()
        {
            return "OH YEAH!";
        }
    }

    [TestFixture]
    public class RunningKoans
    {
        [Test]
        public void AFailingKoanReturnsItsException()
        {
            var container = new KoanContainer();
            var result = container.RunKoans(new FailureContainer()).First();

            Assert.AreEqual("FailureKoan has damaged your karma.", result.Message);
        }

      
        [Test]
        public void AFailingKoanReturnsAFailureMessage()
        {
            var result = new KoanContainer().RunKoans(new FailureContainer()).First();
            Assert.AreEqual("FailureKoan has damaged your karma.", result.Message);

            Assert.AreEqual("expected failure", (result as Failure).Exception.Message);
        }

        [Test]
        public void ASuccessfulKoanReturnsASuccessMessage()
        {
            var result = new KoanContainer().RunKoans(new SuccessContainer()).First();
            Assert.AreEqual("SuccessKoan has expanded your awareness.", result.Message);
        }

        [Test]
        public void TheOutcomeOfAllSuccessfulKoansIsReturned()
        {
           var result =  new KoanContainer().RunKoans(new SomeSuccesses()).Select(x => x.Message).Aggregate((x, y) => x + System.Environment.NewLine + y);

            var expected = "One has expanded your awareness." + System.Environment.NewLine + "Two has expanded your awareness.";

            Assert.AreEqual(expected, result);
        }

        [Test]
        ////might want to change this behavior
        public void FailedKoansDontStopTheEnumeration()
        {
            var result = new KoanContainer().RunKoans(new MixedBag()).Select(x => x.Message).Aggregate((x, y) => x + System.Environment.NewLine + y);

            var expected = "One has damaged your karma." + System.Environment.NewLine + "Two has expanded your awareness.";

            Assert.AreEqual(expected, result);
        }
 
    }


}
