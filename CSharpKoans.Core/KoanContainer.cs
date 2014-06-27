using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace CSharpKoans.Core
{
    public class KoanContainer
    {
        public static IEnumerable<MethodInfo> FindKoanMethods(KoanContainer container)
        {
            return container.GetType().GetMethods().Where(HasKoanAttribute);
        }

        private static bool HasKoanAttribute(MethodInfo info)
        {
            return (info.GetCustomAttributes(typeof(KoanAttribute), true).Any());
        }

        public IEnumerable<IKoanResult> RunKoans()
        {
            return from k in FindKoanMethods(this) select GetKoanResult(k);
        }

        private IKoanResult GetKoanResult(MethodInfo m)
        {
            try{
                m.Invoke(this, new object[] { });
                return new Success(m.Name + " has expanded your awareness.");
            }
            catch(Exception e)
            {
                return new Failure(m.Name + " has damaged your karma.", e.InnerException);
            }
        }
    }
}
