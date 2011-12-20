using System;

namespace CSharpKoans.Core
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class KoanAttribute : Attribute
    {
    }
}
