using System;
using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    public class AboutClasses : KoanContainer
    {
        public class Megalomaniac
        {
            public string Name {  get; set;}
            public string Henchman { get; set; }
            public string Mission { get; set; }

            internal int RetrieveNextStepOfPlan()
            {
                throw new NotImplementedException();
            }
        }

        const string FILL_ME_IN = "";

        [Koan]
        public void ClassTypesAreCopiedByReference()
        {
            var TheBrain = new Megalomaniac
            {
                Name = "The Brain",
                Henchman = "Pinky",
                Mission = "Try to take over the world."
            };
           
            var AnotherBrain = TheBrain;
            AnotherBrain.Mission = "The same thing we do every night";

            Assert.AreEqual(FILL_ME_IN, AnotherBrain.Mission);
        }

        [Koan]
        public void ClassMethodsCanDefineDifferentAccess()
        {
            var Joker = new Megalomaniac();

            // Uncomment the next line and write the method to make the assert pass:
            // Joker.MakePlan("Destroy Batman");

            Assert.AreEqual("Destroy Batman", Joker.Mission);
        }

        [Koan]
        public void PublicMethodsCanChangeObjectState()
        {
            var Joker = new Megalomaniac();

            // Uncomment the next line and write the method to make the asserts pass:
            // Joker.MakePlan("Destroy Batman");

            Assert.AreEqual("Destroy Batman", Joker.Mission);
            Assert.AreEqual("Steal the batmobile", Joker.RetrieveNextStepOfPlan());
        }

        [Koan]
        public void ClassesCanMaintainInternalState()
        {
            var Joker = new Megalomaniac();

            // Uncomment the next line and write the method to make the asserts pass:
            // Joker.MakePlan("Destroy Batman");

            Assert.AreEqual("Destroy Batman", Joker.Mission);
            Assert.AreEqual("Steal the batmobile", Joker.RetrieveNextStepOfPlan());
            Assert.AreEqual("Drive batmobile to Central Park", Joker.RetrieveNextStepOfPlan());
            Assert.AreEqual("Cause accident involving catwoman", Joker.RetrieveNextStepOfPlan());
            Assert.AreEqual("Escape from Central Park", Joker.RetrieveNextStepOfPlan());
            Assert.AreEqual("Convince Batman he harmed Catwoman", Joker.RetrieveNextStepOfPlan());
            Assert.AreEqual("Get Batman to reveal his secret identity", Joker.RetrieveNextStepOfPlan());
            Assert.AreEqual("Put Bruce Wayne in Jail", Joker.RetrieveNextStepOfPlan());
        }
    }
}