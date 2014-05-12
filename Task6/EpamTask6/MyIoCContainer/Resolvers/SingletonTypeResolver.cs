using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer.Resolvers
{
    class SingletonTypeResolver: TypeResolver
    {
        private object _instance;


        public SingletonTypeResolver(MyIoC ioc, Type concreteType) :
            base(ioc, concreteType)
        {
        }        


        public override object Resolve()
        {
            if (_instance == null)
            {
                _instance = base.Resolve();
            }
            return _instance;
        }
    }
}
