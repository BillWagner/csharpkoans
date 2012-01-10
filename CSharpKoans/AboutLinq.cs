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
        const string __ = "FILL ME IN";
        public class FILLMEIN
        {}

        public Library Library = new Library();

        public int count;
        private string incrementCount()
        {
            count++;
            return "incremented the count";
        }

        [Koan]
        public void LinqStatementsAreLazy()
        {
            count = 0;
            var aSelectStatement = from b in Library.Books
                               select incrementCount();

            Assert.IsInstanceOf<FILLMEIN>(aSelectStatement, "What is the type of aSelectStatement?");

            Assert.AreEqual(count, __, "How many times was incrementCount called?");
                
        }

        [Koan]
        public void LinqStatementExecutionIsDeferred()
        {
            count = 0;
            var aSelectStatement = from b in Library.Books
                                   select incrementCount();

            var aSelectStatementExecuted = aSelectStatement.ToList();
           // Assert.IsInstanceOf<IEnumerable<string>>(aSelectStatementExecuted, "What is the type of aSelectStatementExecuted?");
           
            Assert.AreEqual(count, __, "How many times was incrementCount called?");
        
        }

        [Koan]
        public void OrderbyClauseChangesOrder()
        {
            var defaultOrder = from b in Library.Books
                               select b.Title;

            Assert.AreEqual( "Lolita",defaultOrder.First());

            var byYear = from b in Library.Books
                        
                        orderby b.PublicationYear
                        select b.Title;
            Assert.AreEqual(__, byYear.First());


        }

    }
}
