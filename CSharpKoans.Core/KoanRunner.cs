using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpKoans.Core
{
    public class KoanRunner
    {
        public KoanResult ExecuteKoans(IEnumerable<KoanContainer> containers)
        {

            var koanResults = containers.Select(c => executeContainer(c));
           return koanResults.Aggregate<KoanResult,KoanResult>(new Success(""),combineContainersUnlessFailed); 



            
        }


        private KoanResult executeContainer(KoanContainer container)
        {

            var name = container.GetType().Name;
            var lineOne = string.Format("When contemplating {0}", name);

            var koanResults = new KoanContainer().RunKoans(container);
            var returnValue = koanResults.Aggregate<KoanResult, KoanResult>(new Success(lineOne), combineLinesUnlessFailed);
            return returnValue;

        
        }


        private KoanResult combineContainersUnlessFailed(KoanResult state, KoanResult next)
        {
            var newMsg = String.Concat(state.Message, System.Environment.NewLine, System.Environment.NewLine, next.Message);

            if (next is Success) return new Success(newMsg);
            else return new Failure(newMsg, (next as Failure).Exception);
        }
        private KoanResult combineLinesUnlessFailed(KoanResult state, KoanResult next)
        {
            var newMsg = String.Concat(state.Message, System.Environment.NewLine, "    ", next.Message);

            if (next is Success) return new Success(newMsg);
            else return new Failure(newMsg, (next as Failure).Exception);
      
   
        }

        



    }
}
