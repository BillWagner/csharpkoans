using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpKoans.Core;
using NUnit.Framework;
using System.Collections;

namespace CSharpKoans
{
    public class AboutLambdas : KoanContainer
    {
        const int ___ = int.MaxValue;
        KoanDelegate FILLMEIN = null;// n => n;
         BooleanKoanDelegate BOOLFILLMEIN =null; //= n => false;
      

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
            int result = timesTwo(5);

            Assert.AreEqual(___, result);

            /* replace FILLMEIN with code to create a delegate that adds 5 to its argument */
            KoanDelegate plusFive = FILLMEIN;
            int additionResult = plusFive(3);
            Assert.AreEqual(8, additionResult);
            
        }

        delegate bool BooleanKoanDelegate(string s);

        [Koan]
        public void DelegatesCanHaveVariousArgumentAndReturnTypes()
        {

            /* replace BOOLFILLMEIN with a lambda to create a delegate that returns true if the # of chars in the argument is > five, false otherwise */
            BooleanKoanDelegate isLongerThanFive = BOOLFILLMEIN;
            bool result = isLongerThanFive("srtsolutions");
            
            bool no = isLongerThanFive("a2");
            Assert.True(result);
            Assert.IsFalse(no);

        }

        [Koan]
        public void FuncTypesAreTypeSafeShorthandForBuildingDelegateTypes()
        {
            // This Func type does not require a previous delegate definition.
            Func<int, bool> myFunc = x => x > 5;
            bool result = myFunc(4);
            Assert.AreEqual(___, result);

            /* fill in an appropriate argument so that the return value is true */
            bool makeThisTrue = myFunc(___);
            Assert.True(makeThisTrue);
        }

        [Koan]
        public void LambdasCanBeUsedWithStandardQueryOperators()
        {
            int[] numbers = { 1,9,7,3,6,8,5};
            var smallNumbers = numbers.Where(n => n< 4);
            Assert.AreEqual(___, smallNumbers.Count());
          
            /* replace default expression with a lambda that returns true if a number is even */
            IEnumerable<int> evenNumbers = numbers.Where(default(Func<int, bool>));
            Assert.AreEqual(2, evenNumbers.Count());
        
        }

        [Koan]
        public void CountQueryOperatorCanTakeALambda()
        {
            int[] numbers = { 1, 9, 7, 3, 6, 8, 5 };
            Assert.AreEqual(___, numbers.Count());

            /* replace default expression with a lambda that returns true if a number is >7 */
            int largeNumbers = numbers.Count(default(Func<int, bool>));
            Assert.AreEqual(2, largeNumbers);
        }

        [Koan]
        public void GreaterThanOrEqualToSymbolDiffersFromGoesTo()
        {
            int[] numbers = { 1, 9, 7, 3, 6, 8, 5 };

            /* replace default expression with a lambda that returns true if a number is >= 7 */
            int largeNumbers = numbers.Count(default(Func<int, bool>));
            Assert.AreEqual(3, largeNumbers);
        }


        [Koan]
        public void LambdaExpressionsCanAcceptMultipleParameters()
        {
            string FirstName = "Bullwinkle";
            string LastName = "Moose";

            Func<string, string, string> joinStrings = null;

            /* Define a lambda for joinStrings that returns "LastName, FirstName" */
            var fullName = joinStrings(FirstName, LastName);

            Assert.AreEqual("Moose, Bullwinkle", fullName);
        }

        // TODO:  Lambdas can declare parameter types.
        // TODO: lambdas can contain multiple statements.


    /* see more lambdas in the next file: AboutLinq! */
    }



}
