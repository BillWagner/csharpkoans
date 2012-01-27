using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpKoans.Core;
using System.Xml.Linq;
using System.IO;
using NUnit.Framework;

namespace CSharpKoans
{
    
    public class AboutLinqToXml :KoanContainer
    {
        XDocument document = XDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "senators_cfm.xml"));


        const int ___ = int.MaxValue;
        const string[] FILLMEIN = new string[] { };

        public class Senator
        {
            public string LastName { get; set; }
            public string Party { get; set; }
            public string Website { get; set; }
        }

        [Koan]
        public void YouCanUseLinqToRetrieveDataFromXmlDocuments()
        {
            var contactInfo = document.Root;
            var senators = FILLMEIN;
            /* write a query to find the list of senators (do the simplest thing that works, and leave them as XElements) */
               

            Assert.AreEqual(100, senators.Count());

            /* write a line of code that gets the last_name of the third XElement in the "senators" list */
            var thirdSenatorsName = "null";
            Assert.AreEqual("Ayotte", thirdSenatorsName);



     
        }

        [Koan]
        public void LinqToXmlCreatesObjectsFromXmlElements()
        {
            var contactInfo = document.Root;

            /* write a LINQ query to put the senator xElements into Senator objects 
             hint: select new Senator() */
            var senatorObjects = new List<Senator>();

            Assert.AreEqual("", senatorObjects.Last().LastName);

            /* query the senators (in their object form) to select only the democrats (party = D) */
            var democrats = from s in senatorObjects
                            // add a where clause here
                            select s;

            Assert.AreEqual(50, democrats.Count());


            /* write a query to return the names of the republicans in alphabetical order */
            var orderedRepubs = from s in senatorObjects
                                // write the correct query here
                                select s;

        
        }
    }
}
