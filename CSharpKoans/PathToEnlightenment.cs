using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSharpKoans.Core;

namespace CSharpKoans
{
    public class PathToEnlightenment
    {

        public IList<KoanContainer> containers {
            get { return new List<KoanContainer>() { new AboutAsserts() }; }
            }
        //let (containers: obj list) = [ ``about asserts``(); 
        //                               ``about let``();
        //                               ``about functions``();
        //                               ``about the order of evaluation``();
        //                               ``about unit``();
        //                               ``about tuples``();
        //                               ``about strings``();
        //                               ``about branching``();
        //                               ``about lists``();
        //                               ``about pipelining``();
        //                               ``about arrays``();
        //                               ``about dot net collections``();
        //                               ``about looping``();
        //                               ``more about functions``();
        //                               ``about record types``();
        //                               ``about option types``();
        //                               ``about descriminated unions``();
        //                               ``about modules``();
        //                               ``about classes``();
        //                               ]
     

        public void Execute()
        {
            var runner = new KoanRunner(containers);
            var result = runner.ExecuteKoans();
            if (result is Success) Console.WriteLine(result.Message);
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
                Console.WriteLine("Press any key to continue...");
                System.Console.ReadKey();
            }
        }
        //match result with
        //| Success message -> printf "%s" message
        //| Failure (message, ex) -> 
        //    printf "%s" message
        //    printfn ""
        //    printfn ""
        //    printfn ""
        //    printfn ""
        //    printfn "You have not yet reached enlightenment ..."
        //    printfn "%s" ex.Message
        //    printfn ""
        //    printfn "Please meditate on the following code:"
        //    printfn "%s" ex.StackTrace

        //printfn ""
        //printfn ""
        //printfn ""
        //printfn ""
        //printf "Press any key to continue..."
        //System.Console.ReadKey() |> ignore
    }
}
