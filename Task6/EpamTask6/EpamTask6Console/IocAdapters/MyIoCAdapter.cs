using MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask6Console.IocAdapters
{
    class MyIoCAdapter: IIocContainer
    {
        MyIoC _ioc = new MyIoC();

        public void Register<TFrom, TTo>() where TTo : TFrom
            where TFrom : class
        {
            _ioc.Register(typeof(TFrom), typeof(TTo));
        }

        public T Resolve<T>()where T : class
        {
            return _ioc.Resolve<T>();
        }

        public void RegisterInstance<T>(T instance)where T : class
        {
            _ioc.Register(typeof(T), instance);
        }
    }
}
