using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public class Smartphone : Phone, IAbleToBrowse
    {
        public override bool ValidNumber(string number)
        {
            bool flag = true;

            if (number.Length != 10)
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
            Console.WriteLine($"Calling... {callableDevice.Number}");
        }
        public override void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
        public bool ValidUrl(string url)
        {
            bool flag = true;

            foreach (var character in url)
            {
                if (Char.IsDigit(character))
                {
                    flag = false;
                    break;
                }
            }

            return flag;
        }
        public void Browse(string url)
        {
            Console.WriteLine($"Browsing: {url}!");
        }
    }
}
