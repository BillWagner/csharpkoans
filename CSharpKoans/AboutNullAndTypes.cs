using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    public class AboutNullAndTypes : KoanContainer
    {
        string ___ = "FILL ME IN";

        /* The null keyword is a literal that represents a null reference, one that does not refer to any object. 
         * null is the default value of reference-type variables. Ordinary value types cannot be null. */

        [Koan]
        public void MethodsCannotBeCalledOnNull()
        { 
            MyClass myClass = null;
            myClass.AMethod();

            // once we initialize a reference type we can call methods on it
           // change code above to initialize MyClass

         
        }

        [Koan]
        public void ComparingNulls()
        {
            Assert.AreEqual(___, null==null);
        }


        [Koan]
        public void NullStringIsNotTheSameAsEmptyString()
        {
            string s = null;
            string t = String.Empty; // Logically the same as ""

            // Equals applied to any null object...
            bool b = (t.Equals(s));
            Assert.AreEqual(___, b);
        }

        [Koan]
        public void EqualityOperatorWhenOneOperandIsNull()
        {
            string s = null;
            string t = String.Empty;

            bool b = (s == t);
            Assert.AreEqual(___, b);

        }

        [Koan]
        public void ValueTypesBehaveDifferentlyFromReferenceTypes()
        {
  

             /*Variables that are based on value types directly contain values. Assigning one value type variable 
              * to another copies the contained value. This differs from the assignment of reference type variables,
              * which copies a reference to the object but not the object itself.*/

            // A value type cannot be null
            // int i = null; // Compiler error!

            // Invoke default constructor for int type.
            int i = new int();
            int j = 0;

            Assert.AreEqual(___, i==j);
        }

        [Koan]
        public void NullableTypes()
        {
         
            /* to make a value type null, declare it as nullable */
            int? nullableInt = null;
            Assert.AreEqual(___, nullableInt.HasValue);

            nullableInt = 0;
            Assert.AreEqual(___, nullableInt.HasValue);


            Assert.AreEqual(___, nullableInt.Value);

        }
       
    }
    public class MyClass
    {
        public void AMethod()
        { }
    }
}
