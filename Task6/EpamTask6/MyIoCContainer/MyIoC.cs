using MyIoCContainer.Resolvers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MyIoCContainer
{
    public class MyIoC: IIocContainer
    {  
        private IDictionary<Type, IResolver> _resolverPool;


        public MyIoC()
        {
            _resolverPool = new Dictionary<Type, IResolver>();
        }


        #region Generic methods
        /// <summary>
        /// Регистрация зависимости
        /// </summary>
        /// <typeparam name="TFrom">Интерфейс</typeparam>
        /// <typeparam name="TTo">Тип зависимости</typeparam>
        public void Register<TFrom, TTo>()
            where TTo : TFrom
            where TFrom : class
        {
            Register(typeof(TFrom), typeof(TTo));
        }
        /// <summary>
        /// Регистрация сингтона
        /// </summary>
        /// <typeparam name="TFrom">Интерфейс</typeparam>
        /// <typeparam name="TTo">Тип зависимости</typeparam>
        public void RegisterSingle<TFrom, TTo>()
        {
            RegisterSingleScope(typeof(TFrom), typeof(TTo));
        }
        /// <summary>
        /// Регистрация зависимости, с типом имеющим конструктор с параметрами
        /// </summary>
        /// <typeparam name="TFrom">Интерфейс</typeparam>
        /// <typeparam name="TTo">Тип</typeparam>
        /// <param name="args">Параметры конструктора</param>
        public void Register<TFrom, TTo>(object args)
        {
            Register(typeof(TFrom), typeof(TTo), args);
        }
        /// <summary>
        /// Помещение готового экземпляра под контроль контейнера
        /// </summary>
        /// <typeparam name="TFrom">Интерфейс</typeparam>
        /// <param name="instance">Объект</param>
        public void Register<TFrom>(TFrom instance) where TFrom: class
        {
            Register(typeof(TFrom), instance);
        }
        /// <summary>
        /// Разрешение зависимости
        /// </summary>
        /// <typeparam name="T">Интерфейс или класс</typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            Type type = typeof(T);
            return (T)Resolve(type);
        }
        /// <summary>
        /// Разрещешение зависимости, если T имеет параметр конструктора
        /// </summary>
        /// <typeparam name="T">Класс</typeparam>
        /// <param name="args">Параметры конструктора</param>
        /// <returns></returns>
        public T Resolve<T>(object args)
        {
            Type type = typeof(T);
            return (T)Resolve(type, args);
        }
        #endregion


        public void Register(Type interfaceType, Type concreteType)
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException("Parameter must be interface!");
            IResolver resolver = new TypeResolver(this, concreteType);
            _resolverPool.Add(interfaceType, resolver);
        }

        public void Register(Type interfaceType, object instance)
        {
            IResolver resolver = new ObjectResolver(instance);
            _resolverPool.Add(interfaceType, resolver);
        }

        public void Register(Type interfaceType, Type concreteType, object anonymObjCtrArgs)
        {
            IResolver resolver = new ParametrizedResolver(this, concreteType, anonymObjCtrArgs);
            _resolverPool.Add(interfaceType, resolver);
        }

        public void RegisterSingleScope(Type interfaceType, Type concreteType)
        {
            if (!interfaceType.IsInterface)
                throw new ArgumentException("Parameter must be interface!");
            IResolver resolver = new SingletonTypeResolver(this, concreteType);
            _resolverPool.Add(interfaceType, resolver);
        }


        public object Resolve(Type type)
        {
            if (_resolverPool.ContainsKey(type))
                return _resolverPool[type].Resolve();
            else
            {
                ConstructorInfo[] constructors = type.GetConstructors();
                IEnumerable<ConstructorInfo> resolvableCtors = from c in constructors where IsResolvableConstructor(c) select c;
                // TODO select constructor algo                
                ConstructorInfo ctor = resolvableCtors.FirstOrDefault();
                if (ctor != null)
                {
                    object[] args = ResolveConstructorArgs(ctor);
                    object res = ctor.Invoke(args);
                    ResolveFieldAndProperties(res);
                    return res;
                }
                else
                {
                    //TODO resolve with params
                    throw new NotImplementedException("Try to use method Resolve(Type type, object args)");
                }
            }
        }

        public object Resolve(Type type, object args)
        {
            if (args == null)
                return Resolve(type);
            else
                return ParametrizedResolverHelper.Resolve(type, this, args);
        }

        public object ResolveFieldAndProperties(object o)
        {
            Type type = o.GetType();
            FieldInfo[] allFields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            PropertyInfo[] allProps = type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            var fields = from f in allFields where f.GetCustomAttribute<InjectAttribute>() != null select f;
            var properties = from p in allProps where p.GetCustomAttribute<InjectAttribute>() != null select p;

            foreach (var f in fields)
            {
                object resolvable = Resolve(f.FieldType);
                f.SetValue(o, resolvable);
            }

            foreach (var p in properties)
            {
                object resolvable = Resolve(p.PropertyType);
                p.SetValue(o, resolvable);
            }

            return o;
        }


        public bool CanResolveInterface(Type interfaceType)
        {            
            return _resolverPool.ContainsKey(interfaceType);
        }


        private bool IsResolvableConstructor(ConstructorInfo constructor)
        {
            ParameterInfo[] parameters = constructor.GetParameters();
            foreach (var p in parameters)
            {
                Type paramType = p.ParameterType;
                if (!CanResolveInterface(paramType))
                    return false;                
            }
            return true;
        }

        private object[] ResolveConstructorArgs(ConstructorInfo constructor)
        {
            ParameterInfo[] parameters = constructor.GetParameters();
            object[] args = new object[parameters.Length];
            for (int i = 0; i < args.Length; ++i)
            {
                args[i] = Resolve(parameters[i].ParameterType);
            }
            return args;
        }        
    }
}
