using MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoC_Test
{
    interface IDependency { void Foo(); }
    class Dependency1: IDependency {
        int i = 0;
        public Dependency1(int a, int b) { i = a + b; }
        public void Foo() { Console.WriteLine("Dep1; args: {0}", i); } 
    }
    class Dependency2 : IDependency { public void Foo() { Console.WriteLine("Dep2;"); } }
    class Dependended
    {
        public Dependended() { Console.WriteLine("Dependended()"); }
        public Dependended(int a) { Console.WriteLine("Dependended(a)"); }
        public Dependended(IDependency d, int a, int b, int c) { }
        public Dependended(IDependency d, int a, int b, int[] c) {
            Console.WriteLine("Dependended; args: a, b, c[0]: {0}, {1}, {2}", a, b, c[0]);
            Console.WriteLine("IDependency.Foo() said: ");
            d.Foo();
        }
    }

    class MsTimer : IDisposable
    {
        private Stopwatch sw;

        public MsTimer()
        {
            sw = new Stopwatch();
            sw.Start();
        }

        public void Dispose()
        {
            sw.Stop();
            Console.WriteLine("Complete! elapsed: {0}ms", sw.ElapsedMilliseconds);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            #region IoC time tests
            int N = 10000;
            using (new MsTimer())
            {
                MyIoC ioc = new MyIoC();
                ioc.Register<IDependency, Dependency1>(new { a = 888, b = 7 });
                for (int i = 0; i < N; ++i)
                {
                    IDependency d1 = ioc.Resolve<IDependency>();
                }
            }

            using (new MsTimer())
            {
                MyIoC ioc = new MyIoC();
                ioc.Register<IDependency, Dependency2>();
                for (int i = 0; i < N; ++i)
                {
                    IDependency d2 = ioc.Resolve<IDependency>();
                }
            }

            using (new MsTimer())
            {
                MyIoC ioc = new MyIoC();
                ioc.Register<IDependency, Dependency2>();
                for (int i = 0; i < N; ++i)
                {
                    Dependended d = ioc.Resolve<Dependended>(new { a = 1, b = 2, c = 3 });
                }
            }
            #endregion

            MyIoC c = new MyIoC();
            c.Register<IDependency, Dependency1>(new { a = 7, b = 8 });
            var tmp = c.Resolve<Dependended>(new { a = 77, b = 88, c = new[]{1, 2, 3}});

            Console.ReadKey();
        }
    }
}
