using CSharpKoans.Core;
using NUnit.Framework;
using System;

namespace CSharpKoans
{
    /// <summary>
    /// Understanding the properties and behaviors of your choices.
    /// </summary>
    public class AboutEnums : KoanContainer
    {
        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

        /// <summary>
        /// All objects have a resting state.
        /// </summary>
        /// <instructions>
        /// Infer the default state for the Direction enum.
        /// </instructions>
        [Koan]
        public void UnderstandTheDefaultValueOfEnumConstants()
        {
            var dir = new Direction();

            Assert.AreEqual(FILL_ME_IN, (int)dir);

            Assert.AreEqual(FILL_ME_IN, (int)Direction.Left);
        }

        public enum DaysOfTheWeek
        {
            Sunday = 1,
            Monday,
            Tuesday,
            Wednesday = 10,
            Thursday,
            Friday = 15,
            Saturday
        }

        /// <summary>
        /// Sometimes an object's default state depends on that object which came before it.
        /// </summary>
        /// <instructions>
        /// Fill in the correct default values for the given enum values.
        /// </instructions>
        [Koan]
        public void UnderstandHowEnumVariablesAreAssigned()
        {
            var tue = DaysOfTheWeek.Tuesday;
            var thur = DaysOfTheWeek.Thursday;
            var sat = DaysOfTheWeek.Saturday;

            Assert.AreEqual(FILL_ME_IN, (int)tue);
            Assert.AreEqual(FILL_ME_IN, (int)thur);
            Assert.AreEqual(FILL_ME_IN, (int)sat);
        }

        /// <summary>
        /// Objects that may look alike may not necessarily be so.
        /// </summary>
        /// <instructions>
        /// Correctly assign the expected value to toBeInvalid.
        /// </instructions>
        [Koan]
        public void EnumsCanTakeUndefinedValues()
        {
            Direction toBeInvalid = ENUM_FILL_ME_IN;

            Assert.AreEqual(42, (int)toBeInvalid);
        }
        
        [Flags]
        public enum Styles
        {
            Plain = 0,
            Rounded = 1,
            Squared = 2,
            Raised = 4,
            Sunken = 8
        }

        /// <summary>
        /// Sometimes mulitple choices must be joined to create one unique options.
        /// </summary>
        /// <instructions>
        /// Infer the unique choice that is being made.
        /// </instructions>
        [Koan]
        public void BitFlagsCanBeCombined()
        {
            var composite = Styles.Rounded | Styles.Raised;

            Assert.AreEqual(FILL_ME_IN, (int)composite);
        }

        /// <summary>
        /// An object's default state does not change, even if you try.
        /// </summary>
        /// <instructions>
        /// Find equality.
        /// </instructions>
        [Koan]
        public void DefaultEnumValuesIgnoreAssignedValues()
        {
            var day = default(DaysOfTheWeek);

            Assert.AreEqual(FILL_ME_IN, (int)day);
        }

        private const int FILL_ME_IN = -1;
        private const Direction ENUM_FILL_ME_IN = Direction.Up;
    }
}