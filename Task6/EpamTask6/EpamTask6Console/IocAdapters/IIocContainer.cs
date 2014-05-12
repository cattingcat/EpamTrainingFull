using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask6Console.IocAdapters
{
    internal interface IIocContainer
    {
        void Register<TFrom, TTo>() where TTo : TFrom
            where TFrom : class;
        T Resolve<T>() where T: class;
        void RegisterInstance<T>(T instance) where T : class;
    }
}
