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

            Action<int> del_func_instance = delegate (int a)
            {
                Console.WriteLine($"anonymous method is executed {value + 1}");
            };

            del_func_instance(value);
            Console.ReadKey();



        }

    }
}
