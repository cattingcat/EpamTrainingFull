using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer
{
    internal class NameTypeValue
    {
        public string Name { get; set; }
        public Type Type { get; set; }
        public object Value { get; set; }

        private NameTypeValue() { }

        public static NameTypeValue[] FromMethod(MethodBase method)
        {
            return (from p in method.GetParameters() select new NameTypeValue { Name = p.Name, Type = p.ParameterType }).ToArray();
        }

        public static NameTypeValue[] FromObjectProperties(object o)
        {
            return (from p in o.GetType().GetProperties() 
                                  select new NameTypeValue { Name = p.Name, Type = p.PropertyType, Value = p.GetValue(o) }).ToArray();
        }
    }

    internal class NameTypeValueComparer : IEqualityComparer<NameTypeValue>
    {
        public bool Equals(NameTypeValue x, NameTypeValue y)
        {
            return x.Name == y.Name && x.Type == y.Type;
        }

        public int GetHashCode(NameTypeValue obj)
        {
            return obj.GetHashCode();
        }
    }
}
