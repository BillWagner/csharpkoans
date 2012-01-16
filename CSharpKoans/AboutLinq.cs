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
        public const string __ = "FILL ME IN";

        public class FILLMEIN
        { }
        private bool ___()
        {
            return true;
        }

        //private T FILLMEIN()
        //{
        //    return T
        //}

        public Library Library = new Library();

       

        [Koan]
        public void LINQQueriesLookKindaLikeSQL()
        {

            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            IEnumerable<int> evens = from n in numbers
                           where n % 2 ==0
                select n;

            Assert.AreEqual(__, evens.Count());

            /* now modify this query to get the odd numbers */
            IEnumerable<int> odds = null;

            Assert.AreEqual(3, odds.Count());

        }

        [Koan]
        public void LinqIsJustAlternateSyntaxForMethodsOnEnumerable()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            /* instead of the function __(), put in the correct delegate of form n=> fn(n) */
            IEnumerable<int> evens = numbers.Where(n=>___()).Select(n=>n);
            Assert.AreEqual(2, evens.Count());

   
            /* you don't even need the Select() here */
            IEnumerable<int> noSelect = numbers.Where(n=> ___());
            Assert.AreEqual(2, noSelect.Count());

        }

        [Koan]
        public void LINQQueriesCanSelectAnything()
        {

            var numbers = new List<int> { 1, 2, 3, 4, 5 };

            /* instead of the function __(), put in the correct function of form n=> fn(n), with return type bool */
            var squaredEvens = numbers.Where(n => ___()).Select(n=> "Fill me in"); // need a cute way to have a 'FILL ME IN' function here
            Assert.AreEqual(4, squaredEvens.First());
        }

        [Koan]
        public void LinqStatementsAreLazy()
        {
            count = 0;
            var aSelectStatement = from b in Library.Books
                               select incrementCount(b);

            Assert.IsInstanceOf<FILLMEIN>(aSelectStatement, "What is the type of aSelectStatement?");

            Assert.AreEqual(count, __, "How many times was incrementCount called?");
                
        }

        [Koan]
        public void LinqStatementExecutionIsDeferred()
        {
            count = 0;
            var aSelectStatement = from b in Library.Books
                                   select incrementCount(b);

            /* calling ToList executes the statement */
            var aSelectStatementExecuted = aSelectStatement.ToList();
      
           
            Assert.AreEqual(count, __, "How many times was incrementCount called?");
        
        }

        [Koan]
        public void SomeQueriesForceImmediateExecution()
        {

            count = 0;
            var books = from b in Library.Books
                      select incrementCount(b);

            /*   Functions like Count (also: Average(), Max() ) execute without an explicit foreach statement, but foreach is used to iterate through the results (and this executes the statement)  */
           var numBooks= books.Count();
           Assert.AreEqual(__, numBooks, "Just getting the number of books in our library.");
            Assert.AreEqual(count, __, "How many times was incrementCount called?");

        }

     

  

        [Koan]
        public void OrderbyClauseChangesOrder()
        {
            var defaultOrder = from b in Library.Books
                               select b.Title;

            Assert.AreEqual("Lolita", defaultOrder.First());

            var byYear = from b in Library.Books
                         orderby b.PublicationYear
                         select b.Title;
            Assert.AreEqual(__, byYear.First());



        }


        public int count;
        private Book incrementCount(Book b)
        {
            count++;
            return b;
        }
    }
}
