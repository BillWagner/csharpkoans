using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.Linq;

namespace CSharpKoans.Core
{
    public class KoanContainer
    {

        private IEnumerable<MethodInfo> FindKoanMethods(KoanContainer container)
        {
            return container.GetType().GetMethods().Where(m => hasKoanAttribute(m));
        }

        private bool hasKoanAttribute(MethodInfo info)
        {
            return (info.GetCustomAttributes(typeof(KoanAttribute), true).Count()>0);
        }

        public IEnumerable<KoanResult> RunKoans(KoanContainer container)
        {
            return from k in FindKoanMethods(container) select getKoanResult(container, k);
        }

        private KoanResult getKoanResult(KoanContainer container, MethodInfo m)
        {
            try{
                m.Invoke(container, new object[] { });
                return new Success(m.Name + " has expanded your awareness.");
            }
            catch(Exception e)
            {
                return new Failure(m.Name + " has damaged your karma.", e.InnerException);
            }
 
        }
    }

}
