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
        XDocument senatorsDoc = XDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "senators_cfm.xml"));
        XDocument nutritionDoc = XDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "nutrition.xml"));

        /* DO NOT CHANGE THESE VALUES. MAKE THE KOANS WORK BY REPLACING FILL_ME_IN OR ARRAY_FILL_ME_IN WITH THE APPROPRIATE CODE */
        const int FILL_ME_IN = int.MaxValue;
        string[] ARRAY_FILL_ME_IN = new string[] { } ;

        public class Senator
        {
            public string LastName { get; set; }
            public string Party { get; set; }
            public string Website { get; set; }
        }


     //   [Koan]
        public void LinqToXmlBuildsAnObjectTreeFromTheXmlDocument()
        {

            var contactInfo = senatorsDoc.Root;


            /* contactInfo is the root node */

            Assert.AreEqual(FILL_ME_IN, contactInfo.Name.LocalName);
            Assert.AreEqual(FILL_ME_IN, contactInfo.Parent);
            Assert.AreEqual(FILL_ME_IN, contactInfo.HasElements);

            /* Elements() are the direct child nodes of a parent node */
            Assert.AreEqual(FILL_ME_IN, contactInfo.Elements().Count());

            /* Descendants are all the children at any level. */
            Assert.AreEqual(FILL_ME_IN, contactInfo.Descendants().Count());
        
        }

       // [Koan]
        public void EachNodeInTheTreeIsAlsoATree()
        {
            var contactInfo = senatorsDoc.Root;

            var senators = from s in contactInfo.Elements()
                           select s;

          //  Assert.AreEqual(FILL_ME_IN, senators.Count());
          

            var firstSenator = senators.First();


            Assert.AreEqual(FILL_ME_IN, firstSenator.Name.LocalName);
            Assert.AreEqual(FILL_ME_IN, firstSenator.Parent.Name.LocalName);
            Assert.AreEqual(FILL_ME_IN, firstSenator.HasElements);

            /* ancestors are the opposite of descendants */
           Assert.AreEqual(FILL_ME_IN, firstSenator.Ancestors().Count());

            /* Elements() are the direct child nodes of a parent node */
            Assert.AreEqual(FILL_ME_IN, firstSenator.Elements().Count());

            /* Descendants are all the children at any level. */
            Assert.AreEqual(FILL_ME_IN, firstSenator.Descendants().Count());

            /* searching for an child node with a specific name returns all matching child nodes */
            var lastNameNodes = firstSenator.Elements("last_name");

            Assert.AreEqual(FILL_ME_IN, lastNameNodes.Count());

            var lastName = lastNameNodes.First();

            /* Name vs. Value for a node */
            Assert.AreEqual(FILL_ME_IN, lastName.Name.LocalName);
            Assert.AreEqual(FILL_ME_IN, lastName.Value);

      
          
     
        }

        [Koan]
        public void YouCanUseLinqToQueryElements()
        {

            var contactInfo = senatorsDoc.Root;
            var senators = contactInfo.Elements();
            /* OR: from var s contactInfo.Elements select s; */
            var firstSenator = senators.First();

            /* you could also query the elements using LINQ */
            var state = from e in firstSenator.Elements()
                        where e.Name == "state"
                        select e.Value;


            Assert.AreEqual(FILL_ME_IN, state.Count());
            Assert.AreEqual(FILL_ME_IN, state.First());
        }

        [Koan]
        public void LinqToXmlProducesEnumerableData()
        {
            var contactInfo = senatorsDoc.Root;
            var nameOfThirdSenator = from s in contactInfo.Elements()
                           // fill in query here
                           select s;

            /* write a line of code that gets the last_name of the third XElement in the "senators" list */
            Assert.AreEqual("Ayotte", nameOfThirdSenator);

        }


        [Koan]
        public void LinqToXmlCreatesObjectsFromXmlElements()
        {
            var contactInfo = senatorsDoc.Root;

            /* write a LINQ query to generate a list of Senator objects  from the senator document
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

            /* don't change this: just make sure it passes */
            Assert.IsInstanceOf<IEnumerable<Senator>>(orderedRepubs);

            /* Write a query to find the state of the Independent senator.  (Party = ID) */
            var state = "Replace this string with a LINQ to XML Query";

            Assert.AreEqual(state, "CT");


        }


        public class Food
        { 
            /* you will need to fill this in */
        }


        [Koan]
        public void YouCanMakeComplexQueriesIntoXmlFilesWithLinq()
        {

            var root = nutritionDoc.Root;

            /* Write a query to capture the data in the xml document as an enumerable of type Food. 
             * You will need to create the Food class first */
         //   IEnumerable<Food> food = null;
        
        }
    }
}
