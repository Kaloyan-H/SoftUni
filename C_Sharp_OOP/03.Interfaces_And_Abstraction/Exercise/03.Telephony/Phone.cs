using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Text;

namespace _03.Telephony
{
    abstract public class Phone : IAbleToCall, ICallable
    {
        private string number;

        public Phone() { }
        public Phone(string number)
        {
            Number = number;
        }

        public string Number 
        { 
            get { return this.number; }
            private set { this.number = value; }
        }

        abstract public bool ValidNumber(string number);
        abstract public void Call(ICallable callableDevice);
        abstract public void Call(string number);

    }
}
