using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpKoans.Core
{
    public class KoanRunner
    {
        private IEnumerable<KoanContainer> containers { get; set; }

        public KoanRunner(IEnumerable<KoanContainer> containers)
        {
            this.containers = containers;
        }

        
        public KoanResult ExecuteKoans()
        {
            var koanResults = from c in containers select executeContainer(c);

            return koanResults.Aggregate<KoanResult, KoanResult>(new Success(""), combineContainersUnlessFailed);

        }


        private KoanResult executeContainer(KoanContainer container)
        {

            var name = container.GetType().Name;
            var lineOne = string.Format("When contemplating {0}:", name);

            var koanResults = new KoanContainer().RunKoans(container);
            var returnValue = koanResults.Aggregate<KoanResult, KoanResult>(new Success(lineOne), combineLinesUnlessFailed);
            return returnValue;


        }
        private KoanResult combine(Func<string, string, string> joinMessages, string message, KoanResult next)
        {
            var newMsg = joinMessages(message, next.Message);

            if (next is Success)
                return new Success(newMsg);
            else
                return new Failure(newMsg, (next as Failure).Exception);
        }



        private string joinLines(string x, string y)
        {
            return String.Concat(x, System.Environment.NewLine,
                                         "    ", y);
        }

        private string joinContainers(string x, string y)
        {
            return String.Concat(x, System.Environment.NewLine,
                                                System.Environment.NewLine, y);
        }

        private KoanResult combineContainersUnlessFailed(KoanResult state, KoanResult next)
        {

            if (state is Success)
                return combine(joinContainers, state.Message, next);
            else return state;

        }

        private KoanResult combineLinesUnlessFailed(KoanResult state, KoanResult next)
        {

            if (state is Success)
                return combine(joinLines, state.Message, next);
            else return state;


        }





    }
}
