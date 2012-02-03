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


       /* Do you wonder how to pronounce the => token? 
       * If the lambda expression is a predicate, expressing some condition:
       * c => c.State == "MI" then the => can be spoken as "such that".  */


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

        [Koan]
        public void LambdasCanDeclareParameterTypes()
        {
            double[] doubles = {1.1, 2.2, 3.3};

            /* you can declare the argument type directly in your lambda for clarity */
            IEnumerable<double> plusOne = doubles.Select((double x) => x + 1);

            /* but if you don't, the compiler will infer the types */
            var implicitPlusOne = doubles; // add an implicitly typed lambda (with no types on arguments)

            CollectionAssert.AreEquivalent(plusOne, implicitPlusOne);
        }



         /*You can write a more complicated lambda expression using statements, enclosing the statements in braces. 
          * If you use this syntax, you must use the return statement, unless the lambda returns void.*/

        [Koan]
        public void LambdasCanContainMultipleStatements()
        {

            int[] numbers = { 1, 9, 7, 3, 27,6,0, 8, 5, 13, };


            /* write a single lambda that allows us to filter all numbers less than or equal to three or greater than 8 */
            var someNumbers = numbers.Where(
                    x =>
                    {
                        return true;
                        // write the lambda here

                    }
                ) ;

            CollectionAssert.AreEquivalent(new int[] { 1, 9, 3, 27, 9, 13 }, someNumbers);
        }


        /* see more lambdas in use in the next file: AboutLinq! */
    }



}
