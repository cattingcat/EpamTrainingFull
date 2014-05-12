using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer.Resolvers
{
    interface IResolver
    {
        object Resolve();
    }
}
