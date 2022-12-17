using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    internal class MainViewModel : INotifyPropertyChanged
    {
        private string _upperString;

        public string UpperString
        {
            get { return _upperString; }
            private set
            {
                if (this._upperString != value)
                {
                    this._upperString = value;
                }
            }
        }

        private string _inputString;

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged([CallerMemberName]string propertyName = null)
        {
            var h = this.PropertyChanged;
            if (h != null)
            {
                h(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public string InputString
        {
            get { return _inputString; }
            set
            {
                if (this._inputString != value)
                {
                    _inputString = value;
                    this.UpperString = this._inputString.ToUpper();
                    System.Diagnostics.Debug.WriteLine("Upperstring=" + this.UpperString);
                }
            }
        }
    }
}
