using System.Collections.Generic;
using System.Linq;
using CSharpKoans.Core;
using System.Xml.Linq;
using System.IO;
using NUnit.Framework;

namespace CSharpKoans
{
    /// <summary>
    /// LINQ is useful in searching XML files. For the Koans in this file
    /// it may be required to open the XML file and investigate.
    /// </summary>
    public class AboutLinqToXml : KoanContainer
    {
        private class Senator
        {
            public string LastName { get; set; }
            public string Party { get; set; }
            public string State { get; set; }
        }

        /// <summary>
        /// XML documents are a tree like structure.
        /// </summary>
        /// <instructions>
        /// Fill in the values with the expected behavior.
        /// </instructions>
        [Koan]
        public void LinqToXmlBuildsAnObjectTreeFromTheXmlDocument()
        {
            var contactInfo = SenatorsDoc.Root;

            Assert.AreEqual(FILL_ME_IN, contactInfo.Name.LocalName);
            Assert.AreEqual(FILL_ME_IN, contactInfo.Parent);
            Assert.AreEqual(FILL_ME_IN, contactInfo.HasElements);
        }

        /// <summary>
        /// Each node in the tree is the root of its own tree.
        /// </summary>
        /// <instructions>
        /// Fill in the values with the expected behavior.
        /// </instructions>
        [Koan]
        public void EachNodeInTheTreeIsAlsoATree()
        {
            var contactInfo = SenatorsDoc.Root;

            var senators = from s in contactInfo.Elements()
                           select s;        

            var firstSenator = senators.First();

            Assert.AreEqual(FILL_ME_IN, firstSenator.Name.LocalName);
            Assert.AreEqual(FILL_ME_IN, firstSenator.Parent.Name.LocalName);
            Assert.AreEqual(FILL_ME_IN, firstSenator.HasElements);

            Assert.AreEqual(FILL_ME_IN, firstSenator.Ancestors().Count());

            var lastNameNodes = firstSenator.Elements("last_name");

            var lastName = lastNameNodes.First();

            Assert.AreEqual(FILL_ME_IN, lastName.Name.LocalName);
            Assert.AreEqual(FILL_ME_IN, lastName.Value);
        }

        /// <summary>
        /// You can use LINQ to query XML documents as well.
        /// </summary>
        /// <instructions>
        /// Fill in the values with the expected behavior.
        /// </instructions>
        [Koan]
        public void YouCanUseLinqToQueryElements()
        {
            var contactInfo = SenatorsDoc.Root;
            var senators = contactInfo.Elements();
            var firstSenator = senators.First();

            var state = from e in firstSenator.Elements()
                        where e.Name == "state"
                        select e.Value;

            Assert.AreEqual(FILL_ME_IN, state.Count());
            Assert.AreEqual(FILL_ME_IN, state.First());
        }

        /// <summary>
        /// The XML documents are enumerable, and so they are searchable with LINQ.
        /// </summary>
        /// <instructions>
        /// Fill in the LINQ query to match the expected behavior.
        /// </instructions>
        [Koan]
        public void LinqToXmlProducesEnumerableData()
        {
            var contactInfo = SenatorsDoc.Root;
            var nameOfThirdSenator = LINQ_FILL_ME_IN;

            Assert.AreEqual("Ayotte", nameOfThirdSenator);
        }

        /// <summary>
        /// LINQ may be combined with the XML documents to turn the XML data into objects.
        /// </summary>
        /// <instructions>
        /// Fill in the LINQ queries to match the expected behavior.
        /// </instructions>
        /// <hint>
        /// The independent party has a party code of "ID"
        /// </hint>
        [Koan]
        public void LinqToXmlCreatesObjectsFromXmlElements()
        {
            var contactInfo = SenatorsDoc.Root;

            var senatorObjects = LINQ_FILL_ME_IN;

            Assert.AreEqual(FILL_ME_IN, senatorObjects.Last().LastName);

            var democrats = LINQ_FILL_ME_IN;

            Assert.AreEqual(51, democrats.Count());

            var stateOfIndependentSenator = LINQ_FILL_ME_IN;

            Assert.AreEqual(stateOfIndependentSenator, "CT");
        }

        private const int FILL_ME_IN = -1;
        private IEnumerable<Senator> LINQ_FILL_ME_IN;
        private string[] ARRAY_FILL_ME_IN = new string[] { };
        XDocument SenatorsDoc = XDocument.Load(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, "senators_cfm.xml"));
    }
}
