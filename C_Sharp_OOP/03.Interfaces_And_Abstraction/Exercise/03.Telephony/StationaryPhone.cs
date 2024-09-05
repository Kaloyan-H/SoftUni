using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class StationaryPhone : Phone
    {
        public override bool ValidNumber(string number)
        {
            bool flag = true;

            if (number.Length != 7)
            {
                flag = false;
                return flag;
            }

            foreach (var character in number)
            {
                if (!Char.IsDigit(character))
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
        public override void Call(ICallable callableDevice)
        {
            Console.WriteLine($"Dialing... {callableDevice.Number}");
        }
        public override void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
