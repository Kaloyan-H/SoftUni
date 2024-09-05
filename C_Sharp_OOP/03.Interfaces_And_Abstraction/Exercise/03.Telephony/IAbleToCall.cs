using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace _03.Telephony
{
    public interface IAbleToCall
    {
        public bool ValidNumber(string number);
        public void Call(ICallable callableDevice);
        public void Call(string number);
    }
}
