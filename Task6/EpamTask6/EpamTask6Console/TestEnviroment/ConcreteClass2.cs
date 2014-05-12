using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpamTask6Console.TestEnviroment
{
    class ConcreteClass2: ISomeInterface
    {
        public override string ToString()
        {
            return "concrete class 2";
        }

        public void foo()
        {
            Console.WriteLine(this.ToString());
        }
    }
}
