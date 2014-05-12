using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer.Resolvers
{
    abstract class ResolverBase: IResolver
    {
        protected Type _concreteType;
        protected MyIoC _ioc;


        public ResolverBase(MyIoC ioc, Type concreteType)
        {
            _ioc = ioc;
            _concreteType = concreteType;
        }


        public abstract object Resolve();
    }
}
