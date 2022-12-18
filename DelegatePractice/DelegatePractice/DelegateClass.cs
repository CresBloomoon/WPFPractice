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

        public static void func1(int val)
        {
            Console.WriteLine($"func1 is executed. val + 1 = {val + 1}");
            return;
        }

        public static void func2(int val)
        {
            Console.WriteLine($"func2 is executed. val + 2 = {val + 2}");
            return;
        }
        
        public static void func3(int val)
        {
            Console.WriteLine($"func3 is executed. val + 3 = {val + 3}");
            return;
        }

    }
}
