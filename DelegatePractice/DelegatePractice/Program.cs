using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DelegatePractice.DelegateClass;

namespace DelegatePractice
{
    internal class Program
    {

        static void Main(string[] args)
        {
            int value = 0;
            del_func del_func_instance = new del_func(func1);
            del_func_instance += new del_func(func2);
            del_func_instance += new del_func(func3);

            del_func_instance(value);



        }

    }
}
