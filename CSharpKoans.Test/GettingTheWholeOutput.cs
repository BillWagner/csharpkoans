using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NUnit.Framework;
using CSharpKoans.Core;
using NUnit.Framework.Constraints;

namespace CSharpKoans.Test
{

    public class ContainerOne : KoanContainer
    {
        [Koan]
        public string One()
        { return "FTW!"; }


        [Koan]
        public string Two()
        { return "FTW!"; }

        [Koan]
        public string Three()
        { return "FTW!"; }




    }

    public class ContainerTwo : KoanContainer
    {

        [Koan]
        public string Four()
        {
            return "FTW";
        }

        [Koan]
        public void Five()
        {
            Assert.Fail("Expected");
        }
        [Koan]
        public string Six()
        {
            return "FTW!";
        }




    }

    [TestFixture]
    public class GettingTheWholeOutput
    {
        [Test]
        public void OutputContainsContainerNameFollowedByKoanResultsAndStopsOnFailure()
        {
            //Redirect console output to my own stream to allow me to compare it to the expected value.
            var oldOut = Console.Out;
            MemoryStream outStream = new MemoryStream();
            StreamWriter outWriter = new StreamWriter(outStream);
            outWriter.AutoFlush = true;
            Console.SetOut(outWriter);

            var runner = new KoanRunner(new List<KoanContainer> { new ContainerOne(), new ContainerTwo() });

            runner.ExecuteKoans();

            var expected = "While contemplating ContainerOne: \r\n\tOne has expanded your awareness.\r\n\tTwo has expanded your awareness.\r\n\tThree has expanded your awareness.\r\nWhile contemplating ContainerTwo: \r\n\tFour has expanded your awareness.\r\n\tFive has damaged your karma.\r\n\n\n\n\r\nYou have not yet reached enlightenment.\r\nMeditate on the following code: \r\n\r\n   at NUnit.Framework.Assert.Fail(String message, Object[] args)\r\n   at NUnit.Framework.Assert.Fail(String message)\r\n   at CSharpKoans.Test.ContainerTwo.Five() in c:\\Users\\HP\\Source\\Repos\\csharpkoans\\CSharpKoans.Test\\GettingTheWholeOutput.cs:line 45\r\n\n\n\r\n";

            outStream.Seek(0, SeekOrigin.Begin);
            Console.SetOut(oldOut);
            using (StreamReader reader = new StreamReader(outStream))
            {
                Assert.AreEqual(expected, reader.ReadToEnd());
            }
        }
    }
}
