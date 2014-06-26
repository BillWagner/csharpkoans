using CSharpKoans.Core;
using NUnit.Framework;
using System;

namespace CSharpKoans
{
    public class AboutEnums : KoanContainer
    {
        private int FILL_ME_IN = -1;

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }

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

        [Koan]
        public void EnumsCanTakeUndefinedValues()
        {
            Direction toBeInvalid = Direction.Right;

            // reassign toBeInvalid.
            // A cast may be needed

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

        [Koan]
        public void BitFlagsCanBeCombined()
        {
            var composite = Styles.Rounded | Styles.Raised;

            Assert.AreEqual(FILL_ME_IN, (int)composite);
        }

        [Koan]
        public void DefaultEnumValuesIgnoreAssignedValues()
        {
            var day = default(DaysOfTheWeek);

            Assert.AreEqual(FILL_ME_IN, (int)day);
        }
    }
}