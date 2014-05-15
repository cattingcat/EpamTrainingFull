using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer
{
    internal static class ParametrizedResolverHelper
    {
        public static object Resolve(Type type, MyIoC ioc, object args)
        {
            if (args is Array)
            {
                Array argsArray = args as Array;
                IEnumerable<ConstructorInfo> constructors =
                    from c in type.GetConstructors() where c.GetParameters().Length == argsArray.Length select c;

                ConstructorInfo goodConstructor = constructors.First();

                List<object> tmp = new List<object>();
                foreach(object o in argsArray)
                    tmp.Add(o);

                return goodConstructor.Invoke(tmp.ToArray());
            }
            else  // args is anonymous type: new { a = 5, b = "sdfsdf", c = new object(), ... };
            {
                var existedNameType = NameTypeValue.FromObjectProperties(args);

                IEnumerable<ConstructorInfo> constructors =
                    from c in type.GetConstructors() where c.GetParameters().Length != 0 select c;

                ConstructorInfo goodConstructor = null;
                foreach (var ctor in constructors)
                {
                    var requiredNameType = NameTypeValue.FromMethod(ctor);

                    bool isGoodConstructor = true;
                    foreach (var nt in requiredNameType)
                    {
                        if (!(existedNameType.Contains(nt, new NameTypeValueComparer()) || ioc.CanResolveInterface(nt.Type))
                            || requiredNameType.Length < existedNameType.Length)
                        {
                            isGoodConstructor = false;
                            break;
                        }
                    }
                    if (isGoodConstructor)
                    {
                        goodConstructor = ctor;
                        break;
                    }
                }

                if (goodConstructor != null)
                {
                    ParameterInfo[] parameters = goodConstructor.GetParameters();
                    object[] ctorArgs = new object[parameters.Length];
                    for (int i = 0; i < parameters.Length; ++i)
                    {
                        ParameterInfo param = parameters[i];
                        NameTypeValue ntv = (from ent in existedNameType where ent.Name == param.Name select ent).FirstOrDefault();
                        if (ntv != null)
                            ctorArgs[i] = ntv.Value;
                        else
                            ctorArgs[i] = ioc.Resolve(param.ParameterType);
                    }
                    return goodConstructor.Invoke(ctorArgs);
                }
                throw new ArgumentException("Invalid args");
            }
        }
    }
}
