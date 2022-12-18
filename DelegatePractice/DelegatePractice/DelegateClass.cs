using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractice
{
    internal class DelegateClass
    {
        public delegate void del_func(int val);

        public static int func1(int val)
        {
            Console.WriteLine($"func1 is executed. val + 1 = {val + 1}");
            return val + 1;
        }

        public static int func2(int val)
        {
            Console.WriteLine($"func2 is executed. val + 2 = {val + 2}");
            return val + 2;
        }
        
        public static int func3(int val)
        {
            Console.WriteLine($"func3 is executed. val + 3 = {val + 3}");
            return val + 3;
        }

    }
}
