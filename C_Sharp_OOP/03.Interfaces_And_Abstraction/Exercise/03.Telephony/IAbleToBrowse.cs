using System;
using System.Collections.Generic;
using System.Text;

namespace _03.Telephony
{
    public interface IAbleToBrowse
    {
        public bool ValidUrl(string url);
        public void Browse(string url);
    }
}
