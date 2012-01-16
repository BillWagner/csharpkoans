using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    public class AboutLambdas : KoanContainer
    {
        const int ___ = int.MaxValue;
        const KoanDelegate FILLMEIN = n => n;

      

        /*  A lambda expression is an anonymous function that can contain expressions and statements
         *
         * (input parameters) => expression
         */

        delegate int KoanDelegate(int i);

        [Koan]
        public void ALambdaCanBeUsedToCreateADelegate()
        {
            /* note the definition of KoanDelegate above! */
            KoanDelegate timesTwo = n=> n*2;
            var result = timesTwo(5);

            Assert.AreEqual(___, result);

            /* replace FILLMEIN with code to create a delegate that adds 5 to its argument */
            KoanDelegate plusFive = FILLMEIN;
            var additionResult = plusFive(3);
            Assert.AreEqual(8, additionResult);
            
        }


        public void LambdasCanBeUsedWithStandardQueryOperators()
        { }

     
    }



}
