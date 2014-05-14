using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer.Resolvers
{
    class ParametrizedResolver: ResolverBase
    {
        private object _ctorArgs;

        public ParametrizedResolver(MyIoC ioc, Type concreteType, object args):
            base(ioc, concreteType)
        {
            _ctorArgs = args;
        }


        public override object Resolve()
        {
            return ParametrizedResolverHelper.Resolve(_concreteType, _ioc, _ctorArgs);
        }
    }
}
