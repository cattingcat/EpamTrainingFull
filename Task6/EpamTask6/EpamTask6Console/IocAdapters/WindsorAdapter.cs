using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask6Console.IocAdapters
{
    class WindsorAdapter: IIocContainer
    {
        WindsorContainer _windsor = new WindsorContainer();

        public void Register<TFrom, TTo>() where TTo : TFrom
            where TFrom : class
        {
            _windsor.Register(Component.For<TFrom>().ImplementedBy<TTo>());
        }

        public T Resolve<T>() where T : class
        {
            return _windsor.Resolve<T>();
        }

        public void Register<T>(T instance) where T : class
        {
            _windsor.Register(Component.For<T>().Instance(instance));
        }
    }
}
