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
        public class FILLMEIN
        { }
        const int ___ = int.MaxValue;

    
        [Koan]
        public void UsingArrayListMeansNoTypeSafety()
        {
            /* you can add all sorts of types of objects to an ArrayList */
            ArrayList mylist = new ArrayList();
            mylist.Add(7);
            mylist.Add("srtsolutions");

            /* there's no type safety for elements in an ArrayList: since we have to cast on retrieval, this compiles, but throws an exception at runtime */
            mylist.Insert(3, "a2");

            int t = 0;
            // This causes an InvalidCastException to be thrown.
            foreach (int x in mylist)
            {
                /* fix the error by adding a conditional here to check the type of x
                * hint:  "srt".GetType()== typeof(string)
                 */
                t += x;
            }

           Assert.IsInstanceOf<int>((int)mylist[3]);

            /* fix this statement so that it runs and makes sense */
           Assert.IsInstanceOf<FILLMEIN>(mylist[3]);
        }
     
        // use a list of a specific type, allows you to add objects of child ype

        [Koan]
        public void WithAGenericListTypeSafetyIsEnsured()
        {
            /* by specifying the generic type, you can create a collection that is type-safe at compile-time.*/
            List<int> myList = new List<int>();
            myList.Add(7);
            myList.Add(3);

            //myList.Add("srtsolutions"); compile-time error

            int t = 0;
            /* a TestDelegate is just a delegate.  See "AboutLambdas.cs" */
            TestDelegate addUpValuesInMyList = () =>
                {
                    /* write the function that will add up the values.  function is called below */
                };
            
            /* add up all of the values in myList */
            Assert.DoesNotThrow(addUpValuesInMyList);
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
            public string Talk()
            {
                return "Meow";
            }

        }

        public class Dog : Animal
        {
            public string Talk()
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
            Assert.IsInstanceOf<FILLMEIN>(animals.First());

            /* Each Animal has the appropriate behavior based on its child class, though! */
            Assert.AreEqual("what do I say?", animals.First().Talk());
            Assert.AreEqual("third animal says...", animals[2].Talk());
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
                if(page<0) return "This book is dedicated to my true love: Anders Hejlsberg.";
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

            IList<IReadable> readingMaterial = new List<IReadable>();
            readingMaterial.Add(new Book());
            readingMaterial.Add(new Blog());
            readingMaterial.Add(new Magazine());

            Assert.AreEqual(___, readingMaterial.First().TurnToPage(1));
            Assert.AreEqual(___, readingMaterial[2].TurnToPage(1));
        }



        public class Bag<T> : IEnumerable<T>
        {
            protected List<T> storage = new List<T>();

            public void Add(T item)
            {
                storage.Add(item);
            }

            public T this[int index]
            {
                get
                {
                    return storage[index];
                }
                set
                {
                    storage[index] = value;
                }
            }

            /* from the IEnumerable interface */
            public IEnumerator<T> GetEnumerator()
            {
                return storage.GetEnumerator();

            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
        // finally: use a generic Collection<T>
        [Koan]
        public void UsingSpecificInstanceOfGenericCollectionGivesYouTypeSafety()
        {
           Bag<string> myStrings = new Bag<string>();
           myStrings.Add("c#");

          // myStrings.Add(6); won't compile

           Assert.Fail("Comment out the assert below and make it pass by writing a generic Contains method in the Bag class");
           //Assert.True(myStrings.Contains("c#"));

           var cat = new Cat { Name = "behemoth" };
           Bag<Animal> animals = new Bag<Animal>();
           animals.Add(cat);

           Assert.Fail("Make Contains work for Animals, too. Uncomment the assertion below. Hint: the contains method on a collection uses the Equals method on the object.");
            //Assert.True(animals.Contains(cat));

        }

        public class SortableBag<T> : Bag<T> where T : System.IComparable<T>
        {
            public IEnumerable<T> Sort() 
            {
                
                return null;
            }
        }

        [Koan]
        public void ConstraintsOnGenericClassesPreventUnintendedUses()
        {
            /* this does not compile because Animal does not implement IComparable
             SortedBag<Animal> sortedAnimals = new SortedBag<Animal>();
             * */

            SortableBag<int> numbers = new SortableBag<int>() { 5, 7, 8, 3, 27 };
            var sortedNumbers = numbers.Sort();

            /* make the following asserts pass by filling in the Sort function in SortableBag */
            Assert.AreEqual(sortedNumbers.Count(), numbers.Count());

        }
    }
}
