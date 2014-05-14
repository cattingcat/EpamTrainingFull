using Autofac;
using MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask6Console.IocAdapters
{
    class AutofacAdapter: IIocContainer
    {
        ContainerBuilder _builder = new ContainerBuilder();
        IContainer _container = null;

        public void Register<TFrom, TTo>()
            where TFrom : class
            where TTo : TFrom
        {
            //_builder.RegisterType<TFrom>().Named<TTo>();
            _container = null;
        }

        public T Resolve<T>() where T : class
        {
            if (_container == null)
                _container = _builder.Build();
            return _container.Resolve<T>();
        }

        public void Register<T>(T instance) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
