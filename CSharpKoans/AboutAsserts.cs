using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpKoans.Core;
using NUnit.Framework;



namespace CSharpKoans
{
  
    public class AboutAsserts : KoanContainer
    {
         const string __ = "FILL ME IN";

        // We shall contemplate truth by testing reality, via asserts.

        [Koan]
        public void AssertTruth()
        {  
            // This should be true
             Assert.IsTrue(false);
        }

        // Enlightenment may be more easily achieved with appropriate  messages. 
        [Koan]
        public void AssertWithMessage()
        { 

            Assert.IsTrue(false, "This should be true -- Please fix this");
            // To understand reality, we must compare our expectations against reality. 
        }
        [Koan]
        public void AssertEquality()
        {
            var expected_value = 1 + 1;
            var actual_value = __;
            //Helpers.__;

            Assert.AreEqual(expected_value, actual_value);
        }
        // Sometimes we will ask you to fill in the values
        [Koan]
        public void FillInValues()
        {
            Assert.AreEqual(1 + 1, __);
        }
    }
}
