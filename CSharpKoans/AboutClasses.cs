using System;
using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    /// <summary>
    /// By organizing the things in the world and what they do we find logic in the objects.
    /// </summary>
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

        /// <summary>
        /// Each time a rumour spreads about someone it is still about the same person.
        /// </summary>
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

        /// <summary>
        /// Some paths have not been paved. You must make the path yourself.
        /// </summary>
        /// <instructions>
        /// Uncomment the commented line, infer its purpose, and create the method for it.
        /// </instructions>
        [Koan]
        public void ClassMethodsCanDefineDifferentAccess()
        {
            var Joker = new Megalomaniac();

            // Joker.MakePlan("Destroy Batman");

            Assert.AreEqual("Destroy Batman", Joker.Mission);
        }

        /// <summary>
        /// Objects know themselves best. To know the next step, ask.
        /// </summary>
        /// <instructions>
        /// Uncomment the line. Implement the RetrieveNextStepOfPlan so that the object
        /// can tell you more.
        /// </instructions>
        [Koan]
        public void PublicMethodsCanChangeObjectState()
        {
            var Joker = new Megalomaniac();

            // Joker.MakePlan("Destroy Batman");

            Assert.AreEqual("Destroy Batman", Joker.Mission);
            Assert.AreEqual("Steal the batmobile", Joker.RetrieveNextStepOfPlan());
        }

        /// <summary>
        /// Objects remember things if you want them to.
        /// </summary>
        /// <instructions>
        /// Give the Megalomaniac object memory. Make it possible
        /// for it to remember how many steps there are in its plan
        /// and what they are.
        /// </instructions>
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