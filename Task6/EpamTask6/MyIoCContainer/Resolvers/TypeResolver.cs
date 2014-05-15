using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer.Resolvers
{
    class TypeResolver: ResolverBase
    {
        public TypeResolver(MyIoC ioc, Type concreteType):
            base(ioc, concreteType)
        {
        }


        public override object Resolve()
        {
            ConstructorInfo[] constructors = _concreteType.GetConstructors();
            if (constructors.Length == 1)
            {
                ConstructorInfo construct = constructors[0];
                ParameterInfo[] parameters = construct.GetParameters();
                if (CheckResolvableOrDefaultConstructor(parameters))
                {
                    object[] constrArgs = new object[parameters.Length];
                    for (int i = 0; i < parameters.Length; ++i)
                    {
                        constrArgs[i] = _ioc.Resolve(parameters[i].ParameterType);
                    }
                    return construct.Invoke(constrArgs);
                }
                else
                {
                    throw new ArgumentException("Concrete type havent constructor without arguments, use Register witn constructor args");
                }
            }
            else
            {
                // TODO Not one constructor
            }
            return null;
        }

        private bool CheckResolvableOrDefaultConstructor(IEnumerable<ParameterInfo> parameters)
        {
            foreach (var p in parameters)
            {
                if (p.ParameterType.IsInterface && _ioc.CanResolveInterface(p.ParameterType))
                    continue;
                else
                    return false;
            }
            return true;
        }

        
    }
}
