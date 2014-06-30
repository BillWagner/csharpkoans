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
            runner.ExecuteKoans();
            Console.ReadKey();
        }
    }
}
