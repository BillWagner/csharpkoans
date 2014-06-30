using System;
using System.Collections.Generic;
using System.Linq;
using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    /// <summary>
    /// Lambdas are functions without names. They may be used like objects and can be
    /// made to accomplish small, specific, tasks.
    /// 
    /// A delegate is used to represent a function. It is defined like a function
    /// and facilitates the use of functions as first class citizens.
    /// </summary>
    public class AboutLambdas : KoanContainer
    {
        /// <summary>
        /// Lambdas may be saved like a type, but they must match the delegate they
        /// are saved to. All parameters and return types must match.
        /// </summary>
        /// <instructions>
        /// Fill in the expected value.
        /// Then create a lambda to behave as expected and return
        /// the expected value.
        /// </instructions>
        [Koan]
        public void ALambdaCanBeUsedToCreateADelegate()
        {
            KoanDelegate timesTwo = (n) => n*2;
            int result = timesTwo(5);

            Assert.AreEqual(FILL_ME_IN, result);

            KoanDelegate plusFive = DELEGATE_FILL_ME_IN;
            int additionResult = plusFive(3);
            Assert.AreEqual(8, additionResult);
        }

        delegate bool BooleanKoanDelegate(string s);

        /// <summary>
        /// Lambdas may have any set of parameters or return types. However, if you wish
        /// to assign them to a name, they must match their delegate.
        /// </summary>
        /// <instruction>
        /// Implement the appropriate lambda to return the expected values.
        /// </instruction>
        [Koan]
        public void DelegatesCanHaveVariousArgumentAndReturnTypes()
        {
            BooleanKoanDelegate isLongerThanFive = BOOL_DELEGATE_FILL_ME_IN;

            Assert.IsTrue(isLongerThanFive("srtsolutions"));
            Assert.IsFalse(isLongerThanFive("a2"));
        }

        /// <summary>
        /// The Func type is a quick way to save a lambda to a variable without declaring
        /// a delegate type before-hand.
        /// </summary>
        /// <instructions>
        /// Fill in the values to produce the expected behavior.
        /// </instructions>
        [Koan]
        public void FuncTypesAreTypeSafeShorthandForBuildingDelegateTypes()
        {
            Func<int, bool> myFunc = x => x > 5;
            bool result = myFunc(4);
            Assert.AreEqual(FILL_ME_IN, result);

            bool makeThisTrue = myFunc(FILL_ME_IN);
            Assert.True(makeThisTrue);
        }

        /// <summary>
        /// Lambdas may act as decision makers. They may act on each value
        /// of a list and decide if it fits some criteria.
        /// </summary>
        /// <instructions>
        /// Create a lambda which fulfils the expected behavior.
        /// </instructions>
        [Koan]
        public void LambdasCanBeUsedWithStandardQueryOperators()
        {
            int[] numbers = { 1,9,7,3,6,8,5};
            var smallNumbers = numbers.Where(n => n< 4);
            Assert.AreEqual(FILL_ME_IN, smallNumbers.Count());
          
            IEnumerable<int> evenNumbers = numbers.Where(LAMBDA_FILL_ME_IN);
            Assert.AreEqual(2, evenNumbers.Count());
        }

        /// <summary>
        /// Lambdas may be used in several places. Any function which takes
        /// a Predicate takes a lambda of some sort.
        /// </summary>
        /// <instructions>
        /// Create a lambda which fulfills the expected behavior.
        /// </instructions>
        [Koan]
        public void CountQueryOperatorCanTakeALambda()
        {
            int[] numbers = { 1, 9, 7, 3, 6, 8, 5 };
            Assert.AreEqual(FILL_ME_IN, numbers.Count());

            int greaterThanSeven = numbers.Count(LAMBDA_FILL_ME_IN);
            Assert.AreEqual(2, greaterThanSeven);
        }

        /// <summary>
        /// Lambdas are just like functions. They can even accept
        /// multiple parameters.
        /// </summary>
        /// <instructions>
        /// Create a lambda which accepts two parameters and fulfills the requirements.
        /// </instructions>
        [Koan]
        public void LambdaExpressionsCanAcceptMultipleParameters()
        {
            string firstName = "Bullwinkle";
            string lastName = "Moose";

            Func<string, string, string> joinStrings = MULTIPLE_PARAMS_FILL_ME_IN;

            var fullName = joinStrings(firstName, lastName);

            Assert.AreEqual("Moose, Bullwinkle", fullName);
        }

        /// <summary>
        /// Lambdas may specify parameter types. If they do not, then the types
        /// will be inferred.
        /// </summary>
        /// <instructions>
        /// Implement a duplicate lambda to the one shown but instead use implicit
        /// parameter types.
        /// </instructions>
        [Koan]
        public void LambdasCanDeclareParameterTypes()
        {
            double[] doubles = {1.1, 2.2, 3.3};

            IEnumerable<double> plusOne = doubles.Select((double x) => x + 1);

            var implicitPlusOne = doubles;

            CollectionAssert.AreEquivalent(plusOne, implicitPlusOne);
        }

        /// <summary>
        /// Lambdas may be as complex as any other function.
        /// They may span many statements and many lines.
        /// If you do this then you must specify the return.
        /// </summary>
        /// <instructions>
        /// Edit the given lambda to return true if the given number
        /// is between 5 and 10. (Exclusive)
        /// </instructions>
        [Koan]
        public void LambdasCanContainMultipleStatements()
        {
            int[] numbers = { 1, 9, 7, 3, 27, 6, 0, 8, 5, 13, };

            var someNumbers = numbers.Where(
                    x =>
                    {
                        return true;
                    }
                ) ;

            CollectionAssert.AreEquivalent(new int[] { 9, 7, 8, 6}, someNumbers);
        }

        private const int FILL_ME_IN = -1;
        private KoanDelegate DELEGATE_FILL_ME_IN = null;
        private BooleanKoanDelegate BOOL_DELEGATE_FILL_ME_IN = null;
        private Func<int, bool> LAMBDA_FILL_ME_IN = null;
        private Func<string, string, string> MULTIPLE_PARAMS_FILL_ME_IN = null;
        private delegate int KoanDelegate(int i);
    }
}