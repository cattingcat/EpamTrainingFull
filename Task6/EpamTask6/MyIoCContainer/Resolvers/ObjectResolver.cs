using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer.Resolvers
{
    class ObjectResolver: IResolver
    {
        private object _instance;

        public ObjectResolver(object instance)
        {
            _instance = instance;
        }

        public object Resolve()
        {
            return _instance;
        }
    }
}
