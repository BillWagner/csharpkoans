using CSharpKoans.Core;
using NUnit.Framework;



namespace CSharpKoans
{
    /// <summary>
    /// We shall contemplate truth by testing reality, via asserts.
    /// </summary>
    public class AboutAsserts : KoanContainer
    {
        /// <summary>
        /// Assert your reality over other's.
        /// </summary>
        /// <instructions>
        /// Force truth where there is misdirection.
        /// </instructions>
        [Koan]
        public void AssertTruth()
        {  
             Assert.IsTrue(false);
        }

        /// <summary>
        /// To understand reality, we must compare our expectations against reality. 
        /// </summary>
        /// <instructions>
        /// Make reality fit your expectations.
        /// </instructions>
        [Koan]
        public void AssertWithMessage()
        { 
            Assert.IsTrue(false, "This should be true -- Please fix this");
        }

        /// <summary>
        /// Sometimes you must fill in the blanks.
        /// </summary>
        /// <instructions>
        /// Complete the puzzle by placing the missing piece.
        /// </instructions>
        [Koan]
        public void AssertEquality()
        {
            var expected_value = 1 + 1;
            var actual_value = FILL_ME_IN;
         

            Assert.AreEqual(expected_value, actual_value);
        }

        const string FILL_ME_IN = "FILL ME IN";
    }
}
