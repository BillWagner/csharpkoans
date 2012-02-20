using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpKoans.Core;
using System.Collections;
using NUnit.Framework;

namespace CSharpKoans
{


    public class AboutGenerics : KoanContainer
    {

 
    
        [Koan]
        public void UsingArrayListMeansNoTypeSafety()
        {
            /* you can add all sorts of types of objects to an ArrayList */
            ArrayList mylist = new ArrayList();
            mylist.Add(7);
            mylist.Add(3);
            mylist.Add("srtsolutions");

            /* there's no type safety for elements in an ArrayList: since ArrayList is always of objects we have to cast on retrieval, this compiles */
            mylist.Insert(2, "a2");

            int t = 0;
            // This causes an InvalidCastException to be thrown.
            foreach (int x in mylist)
            {
                /* fix the error by adding a conditional here to check the type of x
                * hint:  "srt".GetType()== typeof(string)
                 */
                    t += x;
                
            }

           Assert.IsInstanceOf<int>(mylist[0]);

            /* fix this statement so that it runs and makes sense */
           Assert.IsInstanceOf<FILLMEIN>(mylist[2]);
        }
     

        [Koan]
        public void WithAGenericListTypeSafetyIsEnsured()
        {
            /* A Generic list is a List<T> ("list of T") where T is any C# type.  Generics are similar in concept to C++ templates
             *  They allow you to create a data structure without committing to a type, and reuse algorithms and code 
             */


            /* by specifying the generic type, you can create a collection that is type-safe at compile-time.*/
            List<int> myList = new List<int>();
            myList.Add(7);
            myList.Add(3);

           // myList.Add("srtsolutions"); //compile-time error

            int t = 0;
            foreach (var x in myList)
            {
               
                /* write a function to add up all of the values in myList */
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

        [Koan]
        public void YouCanUseReferenceTypesWithInheritanceInGenericLists()
        {
            /* Animal is the superclass of Dog, above */
            List<Animal> animals = new List<Animal>();

            /* you can add subclasses of animals to the collection ... */
            animals.Add(new Dog { Name = "Fido" });
            animals.Add(new Animal());
            animals.Add(new Cat());

            /* but what type are the elements? */
            Assert.IsInstanceOf<object>(animals.First());

            /* Each Animal has the appropriate behavior based on its child class, though! */
            Assert.AreEqual(___, animals.First().Talk());
            Assert.AreEqual(___, animals[2].Talk());
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
                if(page<0) return "This book is dedicated to Anders Hejlsberg.";
                if (page < 6 ) return pages[page];
                return "The End";
            }
        }
        public class Magazine : IReadable
        {
            public string TurnToPage(int page)
            {
                if (page % 2 == 0) return "advertisement";
                else return "content";
            }
        }
        public class Blog : IReadable
        {
            public string TurnToPage(int page) 
            {
                return "just my opinion";
            }
        }

        // use a list of an interface: allows you to add all implementations of the interface
        [Koan]
        public void AGenericDataStructureCanContainInterfaceImplementors()
        {

            List<IReadable> readingMaterial = new List<IReadable>();
            readingMaterial.Add(new Book());
            readingMaterial.Add(new Blog());
            readingMaterial.Add(new Magazine());

            Assert.AreEqual(___, readingMaterial.First().TurnToPage(1));
            Assert.AreEqual(___, readingMaterial[2].TurnToPage(1));
        }

   
        /* a bag is a multiset: each item can occur more than once, and we keep track of the duplicates */
        public class Bag<T> 
        {
            protected Dictionary<T, int> storage = new Dictionary<T, int>();

            public void Add(T item)
            {
                if (storage.ContainsKey(item))
                {
                    storage[item] += 1;
                }
                else
                {
                    storage[item] = 1;
                }

               
            }

            public void AddRange(IEnumerable<T> items)
            {
                foreach (T item in items)
                {
                    Add(item);
                }
            }

            public int Count()
            {
                return storage.Count;
            }

            /* you'll add the Includes method here... it behaves like Contains */


            /* you'll add the Remove method here... */
            public bool Contains(T obj)
            {
                return storage.Keys.Contains(obj);
            }

        }

        [Koan]
        public void UsingSpecificInstanceOfGenericCollectionGivesYouTypeSafety()
        {
            Bag<string> myStrings = new Bag<string>();
            myStrings.Add("c#");

            // myStrings.Add(new Book()); //won't compile

            // Assert.Fail("Comment me out, and un-comment the assert below and make it pass by writing a generic Contains method in the Bag class");
            Assert.True(myStrings.Contains("c#"));

            var cat = new Cat { Name = "vega" };
            Bag<Animal> animals = new Bag<Animal>();
            animals.Add(cat);

            /* uncomment this below once you have written a Contains method */
            //Assert.True(animals.Contains(cat));

            Assert.Fail("Add a Remove method to Animal");
            animals.Add(cat); // adding it again

            /* uncomment the line below once you've implemented the Remove method...*/
            //animals.Remove(cat); /*removing it once */

            Assert.IsTrue(animals.Contains(cat));
            //animals.Remove(cat);

            Assert.IsFalse(animals.Contains(cat));


            /* notice that the methods we've added to our Bag<T> have nothing to do with animals and are generic.  Now we can reuse them for any data type! */
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
            public int Compare(string x, string y)
            {
                throw new NotImplementedException();
            }
        }
        


        [Koan]
        public void ConstraintsOnGenericClassesPreventUnintendedUses()
        {
            /* this does not compile because Animal does not implement IComparable
             SortedBag<Animal> sortedAnimals = new SortedBag<Animal>();
             * */

            SortableBag<string> people = new SortableBag<string>();
            people.AddRange(new List<string>{ "Bob", "Will", "Angie", "Dianne" });
            var sortedPeople = people.Sort();

            /* make the following asserts pass by filling in the Sort function in SortableBag */
            Assert.AreEqual(sortedPeople.Count(), people.Count());
            Assert.AreEqual("Angie", sortedPeople.First());


            /* fill in the LengthComparer class to get this alternate sort working correctly */
            var sortedByLength = people.Sort(new LengthComparer());
            Assert.AreEqual("Bob", sortedByLength.First());
        }


        public class FILLMEIN
        { }
        const int ___ = int.MaxValue;
    }
}
