using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatePractice
{
    internal class Program
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set
            {
                if (this._name != value)
                {
                    this._name = value;
                    Console.WriteLine("名前が変更されました");
                    RaiseNameChanged();
                }
            }
        }

        public event EventHandler NameChanged;
        static void Main(string[] args)
        {



        }

    }
}
