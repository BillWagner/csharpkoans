using System;
using System.Collections.Generic;
using CSharpKoans.Core;

namespace CSharpKoans
{
    public class PathToEnlightenment
    {
        public IEnumerable<KoanContainer> Containers
        {
            get
            {
                yield return new AboutAsserts();
                yield return new AboutNumericTypes();
                yield return new AboutEnums();
                yield return new AboutNullAndTypes();
                yield return new AboutStructs();
                yield return new AboutClasses();
                yield return new AboutInterfaces();
                yield return new AboutGenerics();
                yield return new AboutLambdas();
                yield return new AboutLinq();
                yield return new AboutLinqToXml(); 
            }
        }

        public void Execute()
        {
            var runner = new KoanRunner(Containers);
            var result = runner.ExecuteKoans();

            if (result is Success)
            {
                Console.WriteLine(result.Message);
            }
            else
            {
                var failure = result as Failure;
                Console.WriteLine(result.Message);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("You have not yet reached enlightenment ...");
                Console.WriteLine(failure.Message);
                Console.WriteLine("");
                Console.WriteLine("Please meditate on the following code:");
                Console.WriteLine(failure.Exception.StackTrace);
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.ReadKey();
            }
        }
    }
}
