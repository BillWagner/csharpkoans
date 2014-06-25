using CSharpKoans.Core;
using NUnit.Framework;
using System.Text;

namespace CSharpKoans
{
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

        [Koan]
        public void InterfacesProvideCommonContracts()
        {
            var Robin = new object();
            var Pinky = new object();

            // Write code so that you can call RepeatCatchPhrase for both Robin and Tonnto
            // create different classes for a super hero side kick,
            // and a villian's henchman.

            string RobinsPhrase = default(string);
            string PinkysPhrase = default(string);

            Assert.AreEqual("Holy Code Exercise, Batman! Holy Code Exercise, Batman! Holy Code Exercise, Batman! ", RobinsPhrase);
            Assert.AreEqual("Narf! Narf! Narf!", PinkysPhrase);
        }

        

    }
}