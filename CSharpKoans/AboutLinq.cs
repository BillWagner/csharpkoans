using System;
using System.Collections.Generic;
using System.Linq;
using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    /// <summary>
    /// LINQ, or Language Integrated Query, is a powerful tool
    /// for querying data within your program as if it were a database.
    /// LINQ allows for things such as list comprehensions as well.
    /// LINQ also provides many extension methods to collections.
    /// These extensions, for example, implement Set operations in
    /// some of the collections. (Union, Intersection, etc)
    /// </summary>
    public class AboutLinq : KoanContainer
    {
        /// <summary>
        /// LINQ can be used to easily select members of a collection
        /// which match a certain criteria.
        /// </summary>
        /// <instructions>
        /// Provide a LINQ query which fulfils the expected behavior.
        /// </instructions>
        [Koan]
        public void LINQQueriesLookKindaLikeSQL()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> evens = from n in numbers
                                     where n % 2 == 0
                                     select n;

            Assert.AreEqual(FILL_ME_IN, evens.Count());

            IEnumerable<int> odds = LINQ_FILL_ME_IN;

            Assert.AreEqual(FILL_ME_IN, odds.Count());
        }

        /// <summary>
        /// LINQ has two forms. One form is that of extension methods for the collections.
        /// The other is the form of the LINQ syntax.
        /// </summary>
        /// <instructions>
        /// Provide a LINQ statement using LINQ syntax to duplicate the form provided.
        /// </instructions>
        [Koan]
        public void LinqIsJustAlternateSyntaxForMethodsOnEnumerable()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            IEnumerable<int> evens = numbers.Where(n => n % 2 == 0).Select(n => n);
            Assert.AreEqual(2, evens.Count());


            IEnumerable<int> linqSyntaxEvens = LINQ_FILL_ME_IN;
            Assert.AreEqual(2, linqSyntaxEvens.Count());
        }

        /// <summary>
        /// The Enumerable class may be used to create a range of values.
        /// </summary>
        /// <instructions>
        /// Fill in the values that properly predict the behavior of the given code.
        /// </instructions>
        [Koan]
        public void UseTheEnumerableClasstoCreateSequences()
        {
            IEnumerable<int> integers = Enumerable.Range(0, 10);

            int[] anArray = integers.Select(i => i).ToArray();

            Assert.AreEqual(FILL_ME_IN, anArray.Contains(1));
            Assert.AreEqual(FILL_ME_IN, anArray.Contains(3));
            Assert.AreEqual(FILL_ME_IN, anArray.Contains(100));
        }

        /// <summary>
        /// The form of LINQ that takes the form of methods is just as powerful
        /// as the LINQ syntax form.
        /// </summary>
        /// <instructions>
        /// Fill in the lambdas to match the expected value.
        /// </instructions>
        [Koan]
        public void LINQQueriesCanSelectAnything()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            var squaredEvens = numbers.Where(LAMBDA_FILL_ME_IN).Select(LAMBDA_FILL_ME_IN); 
            Assert.AreEqual(4, squaredEvens.First());
        }

        /// <summary>
        /// LINQ execution happens on-demand. The query is not executed until
        /// it has a reason to be. Things such as calling methods
        /// on the expected output can force this execution.
        /// </summary>
        /// <instructions>
        /// Fill in the values to match what would be expected.
        /// </instructions>
        [Koan]
        public void LinqStatementExecutionIsDeferred()
        {
            int count = 0;
            var aSelectStatement = from b in Library.Books
                                   where count++ > 0
                                   select Count(b); 
     

            Assert.AreEqual(count, FILL_ME_IN, "How many times was Count called so far?");

            var aSelectStatementIsNowExecuted = aSelectStatement.ToList();

            Assert.AreEqual(count, FILL_ME_IN, "How many times was Count called now?");
        }

        /// <summary>
        /// The on-demand execution of LINQ can be used to provide efficiency where
        /// it would otherwise execute many times.
        /// </summary>
        /// <instructions>
        /// Provide values to properly predict the behavior of LINQ's laziness.
        /// </instructions>
        [Koan]
        public void LinqLazinessCanBeUsefulForEfficiency()
        {
            int counter = 0;

            Random rand = new Random();

            var randomSequence = Enumerable.Repeat(0, 100000).Select<int, int>(i =>
            {
                counter++;
                return rand.Next();
            });

            Assert.AreEqual(FILL_ME_IN, counter);

            var first = randomSequence.First();

            Assert.AreEqual(FILL_ME_IN, counter);

            var second = randomSequence.Skip(1).First();
            Assert.AreEqual(FILL_ME_IN, counter);
        }

        /// <summary>
        /// Sometimes the full LINQ query is forced to execute.
        /// Some methods will force this.
        /// </summary>
        /// <instructions>
        /// Fill in the values to match the expected behavior.
        /// </instructions>
        [Koan]
        public void SomeQueriesForceImmediateExecution()
        {
            count = 0;
            var books = from b in Library.Books
                        select Count(b);

            var numBooks = books.Count();
            Assert.AreEqual(count, FILL_ME_IN, "How many times was Count called?");
        }

        /// <summary>
        /// Some methods cause LINQ queries to execute each time they are called.
        /// Even if they are called in different parts of the code.
        /// </summary>
        /// <instructions>
        /// Fill in the values to match the expected behavior.
        /// </instructions>
        [Koan]
        public void CountOnIEnumerableEnumeratesTwice()
        {
            int counter = 0;
            var books = Library.Books.Select(b =>
            {
                counter++;
                return b;
            });

            var countBooks = books.Count();

            Assert.AreEqual(FILL_ME_IN, counter);

            var countAgain = books.Count();

            Assert.AreEqual(FILL_ME_IN, counter);
        }

        /// <summary>
        /// Some LINQ methods stop evaluation as soon as their criteria is met.
        /// </summary>
        /// <instructions>
        /// Fill in the values to match the expected behavior.
        /// </instructions>
        [Koan]
        public void AnyStopsAfterConditionHasBeenReachedOnce()
        {
            int counter = 0;
            var earlyBooks = Library.Books.Any(b =>
            {
                counter++;
                return b.PublicationYear < 1900;
            });

            Assert.AreEqual(FILL_ME_IN, counter);

            counter = 0;
            var booksList = Library.Books.Any(b =>
            {
                counter++;
                return b.PublicationYear < 1970;
            });

            Assert.AreEqual(FILL_ME_IN, counter);
        }

        /// <summary>
        /// Lists store their length. Running a count on a list
        /// will only result in one enumeration.
        /// </summary>
        /// <instructions>
        /// Fill in the values to match the expected behavior.
        /// </instructions>
        [Koan]
        public void CountOnListEnumeratesOnce()
        {
            int counter = 0;
            var booksList = Library.Books.Select(b =>
            {
                counter++;
                return b;
            }).ToList();

            var countBooks = booksList.Count();

            Assert.AreEqual(FILL_ME_IN, counter);

            var countAgain = booksList.Count();

            Assert.AreEqual(FILL_ME_IN, counter);
        }
      
        /// <summary>
        /// The Orderby LINQ clause will sort the results by the 
        /// provided field.
        /// </summary>
        /// <instructions>
        /// Fill in the values to match the expeceted behavior.
        /// </instructions>
        [Koan]
        public void OrderbyClauseSortsTheOutputSequence()
        {
            var defaultOrder = from b in Library.Books
                               select b.Title;

            Assert.AreEqual("Lolita", defaultOrder.First());

            var byYear = from b in Library.Books
                         orderby b.PublicationYear
                         select b.Title;

            Assert.AreEqual(FILL_ME_IN, byYear.First());
        }

        /// <summary>
        /// If you provide multiple fields to order by then LINQ
        /// will sort by the first and then sort the resulting list
        /// by the second for each item in the first sort.
        /// </summary>
        /// <instructions>
        /// Fill in the values to match the expected behavior.
        /// </instructions>
        [Koan]
        public void OrderbySortsUsingMultipleFieldsInTheOutputSequence()
        {
            var defaultOrder = from b in Library.Books
                               select b.Title;

            Assert.AreEqual("Lolita", defaultOrder.First());

            var byYear = from b in Library.Books
                         orderby b.PublicationYear, b.Author
                         select b.Title;

            Assert.AreEqual(FILL_ME_IN, byYear.First());
        }

        /// <summary>
        /// LINQ can be used in many interesting ways. One such way is adding together
        /// all of the items in a sequence.
        /// </summary>
        /// <instructions>
        /// Using the Aggregate extension method, create a LINQ query that will create
        /// a comma separated list of the titles of the books in the library.
        /// </instructions>
        [Koan]
        public void LINQCanCombineSequenceElements()
        {
            var titles = String.Empty;
            Assert.AreEqual("Lolita, Slaughterhouse-Five, The White Tiger, Anna Karenina", titles);
        }

        int count = 0;
        public T Count<T>(T item )
        {
            count++;
            return item;
        }

        private const string FILL_ME_IN = "FILL ME IN";
        private IEnumerable<int> LINQ_FILL_ME_IN = null;
        private Func<int, bool> LAMBDA_FILL_ME_IN = null;
        private Library Library = new Library();
    }
}
