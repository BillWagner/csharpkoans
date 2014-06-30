using System;
using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    public class AboutNullAndTypes : KoanContainer
    {
        /// <summary>
        /// Null is the default value of reference types. Because null represents
        /// nothing, you cannot call member functions on a null object.
        /// This will throw a NullReferenceException.
        /// </summary>
        /// <instructions>
        /// Change the code to properly initialize the MyClass object.
        /// </instructions>
        [Koan]
        public void MethodsCannotBeCalledOnNull()
        { 
            MyClass myClass = null;
            myClass.AMethod();
        }

        /// <summary>
        /// The null value is the same throughout all uses.
        /// </summary>
        /// <instructions>
        /// Fill in the value to match the expected behavior.
        /// </instructions>
        [Koan]
        public void ComparingNulls()
        {
            Assert.AreEqual(FILL_ME_IN, null == null);
        }

        /// <summary>
        /// A null object is not always the same as an object without useful value.
        /// </summary>
        /// <instructions>
        /// Fill in the values to match the expected behavior.
        /// </instructions>
        [Koan]
        public void NullStringIsNotTheSameAsEmptyString()
        {
            string s = null;
            string t = String.Empty; 

            bool b = (t.Equals(s));
            Assert.AreEqual(FILL_ME_IN, b);
        }

        /// <summary>
        /// Variables that are based on value types directly contain values. Assigning one value type variable
        /// to another copies the contained value. This differs from the assignment of reference type variables,
        /// which copies a reference to the object but not the object itself.
        /// </summary>
        /// <instructions>
        /// Fill in the values with the expected behavior.
        /// As a bonus, try to assign null to an integer.
        /// </instructions>
        [Koan]
        public void ValueTypesBehaveDifferentlyFromReferenceTypes()
        {
            // Invoke default constructor for int type.
            int i = new int();
            int j = 0;

            Assert.AreEqual(FILL_ME_IN, i == j);
        }

        /// <summary>
        /// Nullable types allow you to assign null to value types.
        /// The sorthand for declaring a nullable type is to add a question mark
        /// to the type declaration of the variable declaration.
        /// </summary>
        /// <instructions>
        /// Fill in the values with the expected behavior.
        /// </instructions>
        [Koan]
        public void NullableTypes()
        {
            int? nullableInt = null;
            Assert.AreEqual(FILL_ME_IN, nullableInt.HasValue);

            nullableInt = 0;
            Assert.AreEqual(FILL_ME_IN, nullableInt.HasValue);

            Assert.AreEqual(FILL_ME_IN, nullableInt.Value);
        }

        private string FILL_ME_IN = "FILL ME IN";
    }
    public class MyClass
    {
        public void AMethod() { }
    }
}
