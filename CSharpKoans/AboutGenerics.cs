using System;
using System.Collections.Generic;
using System.Linq;
using CSharpKoans.Core;
using System.Collections;
using NUnit.Framework;

namespace CSharpKoans
{
    /// <summary>
    /// Generics allow for blanket implementations.
    /// </summary>
    public class AboutGenerics : KoanContainer
    {
        /// <summary>
        /// Some objects may contain many others of varying types.
        /// You must be careful of what you put in your objects.
        /// You must enforce your own type-safety.
        /// </summary>
        /// <instructions>
        /// The code will throw exceptions during runtime.
        /// Place your safety nets to catch odd types and allow the code
        /// to run without error.
        /// </instructions>
        [Koan]
        public void UsingArrayListMeansNoTypeSafety()
        {
            ArrayList mylist = new ArrayList();
            mylist.Add(7);
            mylist.Add(3);
            mylist.Add("Grand Circus");

            int t = 0;
            foreach (int x in mylist)
            {
                    t += x;
            }

            Assert.IsInstanceOf<CLASS_FILL_ME_IN>(mylist[2]);

            Assert.AreEqual(10, t);
        }
     
        /// <summary>
        /// The type of objects that a list contains may be defined.
        /// This is possible through generics.
        /// </summary>
        /// <instructions>
        /// Provide the code to add up the contents of the list.
        /// As a bonus, attempt to add an object of type string to the list.
        /// </instructions>
        [Koan]
        public void WithAGenericListTypeSafetyIsEnsured()
        {
            List<int> myList = new List<int>();
            myList.Add(7);
            myList.Add(3);

            int t = 0;
            foreach (var x in myList)
            {
               //FILL_ME_IN
            }
           
            Assert.AreEqual(10, t);
        }

        public class Animal
        {
            public string Name { get; set; }
            public virtual string Talk()
            {
            return "hello";
            }
        }

        public class Cat : Animal
        {
            public override string Talk()
            {
                return "Meow";
            }
        }

        public class Dog : Animal
        {
            public override string Talk()
            {
                return "Woof";
            }
        }

        /// <summary>
        /// If you match the description of what's expected, you will find acceptance.
        /// </summary>
        /// <instructions>
        /// Fill in the expected values.
        /// Keep in mind which object is where and what type it is.
        /// </instructions>
        [Koan]
        public void YouCanUseReferenceTypesWithInheritanceInGenericLists()
        {
            List<Animal> animals = new List<Animal>();

            animals.Add(new Dog { Name = "Fido" });
            animals.Add(new Animal());
            animals.Add(new Cat());

            Assert.IsInstanceOf<CLASS_FILL_ME_IN>(animals.First());

            Assert.AreEqual(FILL_ME_IN, animals.First().Talk());

            Assert.AreEqual(FILL_ME_IN, animals[2].Talk());
        }

        public interface IReadable
        {
            string TurnToPage(int page);
        }

        public class Book : IReadable
        {
            private IList<string> pages = new List<string> { "properties", "generics", "lambdas", "linq","constructors", "indexers" };
            public string TurnToPage(int page)
            {
                if (page < 0)
                {
                    return "This book is dedicated to Anders Hejlsberg.";
                }

                if (page < 6)
                {
                    return pages[page];
                }

                return "The End";
            }
        }

        public class Magazine : IReadable
        {
            public string TurnToPage(int page)
            {
                if (page%2 == 0)
                {
                    return "advertisement";
                }
                
                return "content";
            }
        }

        public class Blog : IReadable
        {
            public string TurnToPage(int page) 
            {
                return "just my opinion";
            }
        }

        /// <summary>
        /// Interfaces define the descriptions required.
        /// All objects that follow the interface are acceptable.
        /// </summary>
        /// <instructions>
        /// Fill in the correct expected values.
        /// </instructions>
        [Koan]
        public void AGenericDataStructureCanContainInterfaceImplementors()
        {

            List<IReadable> readingMaterial = new List<IReadable>();
            readingMaterial.Add(new Book());
            readingMaterial.Add(new Blog());
            readingMaterial.Add(new Magazine());

            Assert.AreEqual(FILL_ME_IN, readingMaterial.First().TurnToPage(1));
            Assert.AreEqual(FILL_ME_IN, readingMaterial[2].TurnToPage(1));
        }

        public class Bag<T> 
        {
            protected Dictionary<T, int> Storage = new Dictionary<T, int>();

            public void Add(T item)
            {
                if (Storage.ContainsKey(item))
                {
                    Storage[item] += 1;
                }
                else
                {
                    Storage[item] = 1;
                }
            }

            public void AddRange(IEnumerable<T> items)
            {
                foreach (T item in items)
                {
                    Add(item);
                }
            }

            public int CountDistinct()
            {
                return Storage.Count;
            }
        }

        /// <summary>
        /// Generic types allow for their methods to affect any type that
        /// they are instantiated to target.
        /// </summary>
        /// <instructions>
        /// Uncomment each method call and add the appropriate method to the Bag class.
        /// </instructions>
        [Koan]
        public void UsingSpecificInstanceOfGenericCollectionGivesYouTypeSafety()
        {
            Bag<string> myStrings = new Bag<string>();
            myStrings.Add("c#");

            //Assert.True(myStrings.Contains("c#"));

            var cat = new Cat { Name = "vega" };
            Bag<Animal> animals = new Bag<Animal>();
            animals.Add(cat);

            //Assert.True(animals.Contains(cat));

            animals.Add(cat);

            //animals.Remove(cat);

            //Assert.IsTrue(animals.Contains(cat));

            //animals.Remove(cat);

            //Assert.IsFalse(animals.Contains(cat));
        }

        public class SortableBag<T> : Bag<T> where T : System.IComparable<T>
        {
            public IEnumerable<T> Sort() 
            {
                return null;
            }
            public IEnumerable<T> Sort(IComparer<T> comparer)
            {
                return null;
            }
        }

        public class LengthComparer : IComparer<string>
        {
            /// <hint>
            /// Should return -1 if x comes before y.
            /// Should return 0 if x and y are equal.
            /// Should return 1 if x comes after y.
            /// </hint>
            public int Compare(string x, string y)
            {
                throw new NotImplementedException();
            }
        }
        
        /// <summary>
        /// Sometimes it is necessary to exclude certain types.
        /// Constraints on type arguments allow you to enforce
        /// a rule on the type given.
        /// </summary>
        /// <instructions>
        /// Implement the SortableBag.Sort() method to sort into the expected order.
        /// 
        /// Implement the SortableBag.Sort(IComparer) overload to use the provided 
        /// IComparer to do the sorting decisions.
        /// 
        /// As a bonus, attempt to initalize SortableBag with a type argument
        /// that does not implement IComparable.
        /// </instructions>
        [Koan]
        public void ConstraintsOnGenericClassesPreventUnintendedUses()
        {
            SortableBag<string> people = new SortableBag<string>();
            people.AddRange(new List<string>{ "Bob", "Will", "Angie", "Dianne" });
            var sortedPeople = people.Sort();

            Assert.AreEqual("Angie", sortedPeople.First());
            Assert.AreEqual("Will", sortedPeople.Last());

            var sortedByLength = people.Sort(new LengthComparer());
            Assert.AreEqual("Bob", sortedByLength.First());
        }

        public class CLASS_FILL_ME_IN { }
        const int FILL_ME_IN = int.MaxValue;
    }
}
