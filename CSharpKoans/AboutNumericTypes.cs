using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    public class AboutNumericTypes : KoanContainer
    {
        /// <summary>
        /// Numerical values are inferred to a certain type when they are assigned
        /// to a variable meant to be implicitly inferred.
        /// </summary>
        /// <intructions>
        /// Fill in the values with the expected behavior.
        /// </intructions>
        [Koan]
        public void UnderstandTheDefaultNumericType()
        {
            var i = 42;

            Assert.AreEqual(typeof(TYPE_FILL_ME_IN), i.GetType());
        }

        /// <summary>
        /// Lossy conversions, such as those that remove decimal or fractional values,
        /// must be explicitely stated.
        /// </summary>
        /// <instructions>
        /// Uncomment the commented line and change it so that it doesn't cause
        /// an error.
        /// </instructions>
        [Koan]
        public void LossyConversionsAreExplicit()
        {
            int initialValue = 5;
            double implicitlyConverted = initialValue;

            int finalValue = FILL_ME_IN;

            //finalValue = implicitlyConverted;

            Assert.AreEqual(initialValue, finalValue);
        }

        /// <summary>
        /// Integers cannot store fractions or decimal parts.
        /// Division using two integers is called integer division
        /// as the result never contains a fraction.
        /// </summary>
        /// <instructions>
        /// Fill in the values with the expected behavior.
        /// </instructions>
        [Koan]
        public void IntegerMathPerformsRounding()
        {
            int numerator = 27;
            int denominator = 5;

            int expected = FILL_ME_IN;
            int actual = numerator / denominator;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Non-integer numerical types such as the float or double do contain
        /// fractions or decimal values. This is useful for normal division.
        /// </summary>
        /// <instructions>
        /// Fill in the valueus with the expected behavior.
        /// </instructions>
        [Koan]
        public void FloatingPointMathIncludesDecimalFractions()
        {
            double numerator = 27;
            double denominator = 5;

            double expected = FILL_ME_IN;
            double actual = numerator / denominator;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Floating point addition may cause rounding errors over a large
        /// period of time or over many operations.
        /// </summary>
        /// <instructions>
        /// Rewrite the loop to minimize the rounding error.
        /// </instructions>
        [Koan]
        public void FloatingPointIntroducesRoundingErrors()
        {
            double[] values = new double[1000000];

            double total = 0.0;
            double increment = 0.001;

            for (int i = 0; i < 1000000; i++)
            {
                values[i] = total;
                total += increment;
            }

            Assert.AreEqual(1000.0, values[999999]);
        }

        /// <summary>
        /// Integers may be signed or unsigned. An unsigned integer may contain
        /// greater values than an unsigned. The cost of this, however, is that unsigned
        /// integers may never contain negative numbers.
        /// </summary>
        /// <instructions>
        /// Fill in the values with the expected behavior.
        /// Hint: You may need to use the debugger here.
        /// </instructions>
        [Koan]
        public void IntegralValuesCanBeSignedOrUnsigned()
        {
            int i = 25;
            uint j = 50;

            i -= 100;

            j -= 200;

            Assert.AreEqual(FILL_ME_IN, i);

            Assert.AreEqual(FILL_ME_IN, j);
        }

        /// <summary>
        /// The mixing of signed and unsigned integers in an operation causes
        /// a conversion of the result.
        /// </summary>
        /// <instructions>
        /// Fill in the values with the expected behavior.
        /// </instructions>
        [Koan]
        public void MixingSignedAndUnsignedMathCausesConversions()
        {
            int i = 5;
            uint j = 25;

            var k = i + j;

            Assert.AreEqual(typeof(TYPE_FILL_ME_IN), k.GetType());
        }

        private int FILL_ME_IN = -1;
        private struct TYPE_FILL_ME_IN { }
    }
}