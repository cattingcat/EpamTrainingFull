using MyIoCContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask6Console.TestEnviroment
{
    class ClassDependedInterface
    {
        private ISomeInterface _dependency;



        [Inject]
        public ISomeInterface Prop { get; set; }
        [Inject]
        private ISomeInterface _field;


        public ClassDependedInterface(ISomeInterface dependency)
        {
            _dependency = dependency;
        }

        public void Foo()
        {
            Console.WriteLine(_dependency.ToString());
        }
    }
}
