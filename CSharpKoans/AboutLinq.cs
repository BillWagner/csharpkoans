using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpKoans.Core;
using NUnit.Framework;

namespace CSharpKoans
{
    public class AboutLinq : KoanContainer
    {
        public class FILLMEIN
        { }
        private bool ___()
        {
            return true;
        }

        const string __ = "FILL ME IN";

        public Library Library = new Library();

        /* linq stands for "language integrated query" */
        [Koan]
        public void LINQQueriesLookKindaLikeSQL()
        {
            /* linq query syntax */
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> evens = from n in numbers
                                     where n % 2 == 0
                                     select n;
            /* n is the range variable */

            Assert.AreEqual(__, evens.Count());

            /* now modify this query to get the odd numbers */
            IEnumerable<int> odds = numbers/* add a query here */;

            Assert.AreEqual(__, odds.Count());

        }

        [Koan]
        public void LinqIsJustAlternateSyntaxForMethodsOnEnumerable()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            /* instead of the function n=>true, put in the correct delegate of form n=> fn(n) */
            IEnumerable<int> evens = numbers.Where(n => true /*change this lambda  */).Select(n => n);
            Assert.AreEqual(2, evens.Count());


            /* you don't even need the Select() here */
            IEnumerable<int> noSelectEvens = numbers.Where(n => true);
            Assert.AreEqual(2, noSelectEvens.Count());
        }

        [Koan]
        public void UseTheEnumerableClasstoCreateSequences()
        {
            IEnumerable<int> integers = Enumerable.Range(0, 10);

            /* what does this put into anArray? */
            int[] anArray = integers.Select(i => i*i).ToArray();

            /* fill in true or false */
            Assert.AreEqual(__, anArray.Contains(1));
            Assert.AreEqual(__, anArray.Contains(3));
            Assert.AreEqual(__, anArray.Contains(100));


        }

      

        [Koan]
        public void LINQQueriesCanSelectAnything()
        {

            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            /* instead of the function true, put in the correct function of form n=> fn(n), with return type bool */
            var squaredEvens = numbers.Where(n =>true).Select(default(Func<int, bool>)); 
            Assert.AreEqual(4, squaredEvens.First());
        }

        /* Linq statements are lazy.  This means that an enumerable evaluates on-demand, rather than up front */

     
        [Koan]
        public void LinqStatementExecutionIsDeferred()
        {
            int count = 0;
            var aSelectStatement = from b in Library.Books
                                   where count++ > 0
                                   select CountMe(b); 
     

            Assert.AreEqual(count, "Fill me in", "How many times was CountMe called so far?");

            /* calling ToList executes the statement */
            var aSelectStatementExecuted = aSelectStatement.ToList();

            Assert.AreEqual(count, "Fill me in", "How many times was CountMe called now?");
        
        }

        /* using fluent linq syntax below ...*/

        [Koan]
        public void LinqLazinessCanBeUsefulForEfficiency()
        {
            int counter = 0;

            Random rand = new Random();

            /* note: we are using a multi-statement function in our select statement.
             * you normally should not have a side effect in your select lambda .
           *  If you didn't want to count, you would write this as just:
           *  Enumerable.Repeat(0, 100000).Select(i=> rand.Next())
           *  */
            var randomSequence = Enumerable.Repeat(0, 100000).Select<int, int>(i =>
            {
                counter++;
                return rand.Next();
            });


            /* how many times is the random number generator used? we are calling select on a 100000-item list... */
            Assert.AreEqual(__, counter);

            /* this time, we evaluate the first item in our random sequence... */
            var first = randomSequence.First();

            Assert.AreEqual(__, counter);

            /* Thanks to the lazy nature of LINQ, the sequence is not pre-computed and stored in an array, 
             * but instead random numbers are generated on-demand, as you iterate over randomSequence. */
            var second = randomSequence.Skip(1).First();
            Assert.AreEqual(__, counter);
        }


        [Koan]
        public void SomeQueriesForceImmediateExecution()
        {

            count = 0;
            var books = from b in Library.Books
                      select CountMe(b);

            /*   Functions like Count (also: Average(), Max() ) execute without an explicit foreach statement, but foreach is used to iterate through the results (and this executes the statement)  */
           var numBooks= books.Count();
           Assert.AreEqual("Fill me in", numBooks, "Just getting the number of books in our library.");
           Assert.AreEqual(count, "Fill me in", "How many times was CountMe called?");

        }

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

            Assert.AreEqual(__, counter);

            var countAgain = books.Count();
            Assert.AreEqual(__, counter);
        }

        [Koan]
        public void AnyStopsAfterConditionHasBeenReachedOnce()
        {
            /* note the order of the books in the library */
            int counter = 0;
            var earlyBooks = Library.Books.Any(b =>
            {
                counter++;
                return b.PublicationYear < 1900;
            });

            Assert.AreEqual(__, counter);

            counter = 0;
            var booksList = Library.Books.Any(b =>
            {
                counter++;
                return b.PublicationYear < 1970;
            });

            Assert.AreEqual(__, counter);
        }

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

            Assert.AreEqual(__, counter);

            var countAgain = booksList.Count();
            Assert.AreEqual(__, counter);
        }
      

      

        [Koan]
        public void OrderbyClauseSortsTheOutputSequence()
        {
            var defaultOrder = from b in Library.Books
                               select b.Title;

            Assert.AreEqual("Lolita", defaultOrder.First());

            var byYear = from b in Library.Books
                         orderby b.PublicationYear
                         select b.Title;
            Assert.AreEqual("Fill me in", byYear.First());

        }

        [Koan]
        public void AggregateCreatesACommaSeparatedStringFromAListOfStrings()
        {
            /* get just the titles of our books */
            var titles = Library.Books.Select(b => b.Title);

            Assert.AreEqual(__, titles.Last());

            /* replace the lambda inside our aggregate to create a comma-separated list of all of the titles */
            string commaSeparated =  titles.Aggregate( (t1,t2)=> __);
            Assert.AreEqual("Lolita, Slaughterhouse-Five, The White Tiger, Anna Karenina, ", commaSeparated);
        
        }

        /* this is a utility function for the query-syntax linq statements.  do not modify */
        int count = 0;
        public T CountMe<T>(T item )
        {
            count++;
            return item;
        }
  
    }
}
