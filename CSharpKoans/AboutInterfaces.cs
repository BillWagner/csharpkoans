using CSharpKoans.Core;
using NUnit.Framework;
using System.Text;

namespace CSharpKoans
{
    /// <summary>
    /// Interfaces enforce contracts. This is useful if you're using types
    /// of varying specificity.
    /// </summary>
    public  class AboutInterfaces : KoanContainer
    {
        public interface ICharacter
        {
            string SayCatchPhrase();
        }

        private string RepeatCatchPhrase(ICharacter sidekick)
        {
            StringBuilder rVal = new StringBuilder();
            for (int i = 0; i < 3; i++)
                rVal.Append(sidekick.SayCatchPhrase());

            return rVal.ToString();
        }

        /// <summary>
        /// Interfaces make promises that you must fulfil
        /// in your implementations.
        /// </summary>
        /// <instructions>
        /// Implement the two sidekicks with their given catchphrases
        /// and instantiate their respective variables.
        /// </instructions>
        [Koan]
        public void InterfacesProvideCommonContracts()
        {
            var Robin = new object() as ICharacter;
            var Pinky = new object() as ICharacter;

            Assert.AreEqual("Holy Code Exercise, Batman! Holy Code Exercise, Batman! Holy Code Exercise, Batman! ", RepeatCatchPhrase(Robin));
            Assert.AreEqual("Narf! Narf! Narf! ", RepeatCatchPhrase(Pinky));
        }
    }
}