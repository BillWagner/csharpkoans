using CSharpKoans.Core;
using NUnit.Framework;
using System;

namespace CSharpKoans
{
    public class AboutEnums : KoanContainer
    {
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

            Assert.AreEqual(-1, dir);

            Assert.AreEqual(-1, Direction.Left);
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

            Assert.AreEqual(-1, tue);
            Assert.AreEqual(-1, thur);
            Assert.AreEqual(-1, sat);

        }

        [Koan]
        public void EnumsCanTakeUndefinedValues()
        {
            var toBeInvalid = Direction.Right;

            // reassign toBeInvalid.
            // A cast may be needed

            Assert.AreEqual(42, toBeInvalid);
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

            Assert.AreEqual(-1, composite);
        }

        [Koan]
        public void DefaultEnumValuesIgnoreAssignedValues()
        {
            var day = default(DaysOfTheWeek);

            Assert.AreEqual(-1, day);
        }
    }
}