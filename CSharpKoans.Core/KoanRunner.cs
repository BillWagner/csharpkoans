using System;
using System.Collections.Generic;

namespace CSharpKoans.Core
{
    public class KoanRunner
    {
        private IEnumerable<KoanContainer> Containers { get; set; }

        public KoanRunner(IEnumerable<KoanContainer> containers)
        {
            this.Containers = containers;
        }

        public void ExecuteKoans()
        {
            foreach (var c in Containers)
            {
                if (OutputKoansWhileSuccessful(c))
                    return;
            }
            Console.WriteLine();
            Console.WriteLine("Congratulations. You have solved all of the Koans!");
        }

        /// <summary>
        /// Outputs the results of a <see cref="KoanContainer"/> to the console.
        /// Stops when a failed Koan is detected.
        /// </summary>
        /// <param name="container"><see cref="KoanContainer"/> to be evaluated and output.</param>
        /// <returns>true if a failure has been found.</returns>
        private bool OutputKoansWhileSuccessful(KoanContainer container)
        {
            Console.WriteLine("While contemplating {0}: ", container.GetType().Name);
            foreach (var koan in container.RunKoans())
            {
                Console.WriteLine("  {0}", koan.Message);
                if (koan is Failure)
                {
                    var k = koan as Failure;
                    Console.WriteLine("\n\n");
                    Console.WriteLine("You have not yet reached enlightenment.");
                    Console.WriteLine("Meditate on the following code: ");
                    Console.WriteLine();
                    Console.WriteLine(k.Exception.StackTrace);
                    Console.WriteLine("\n\n");
                    return true;
                }
                Console.WriteLine();
            }
            return false;
        }
    }
}
