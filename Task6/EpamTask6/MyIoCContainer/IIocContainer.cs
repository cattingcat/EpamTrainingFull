using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer
{
    public interface IIocContainer
    {
        void Register<TFrom, TTo>()
            where TTo : TFrom
            where TFrom : class;

        T Resolve<T>() where T : class;

        void Register<T>(T instance) where T : class;
    }
}
