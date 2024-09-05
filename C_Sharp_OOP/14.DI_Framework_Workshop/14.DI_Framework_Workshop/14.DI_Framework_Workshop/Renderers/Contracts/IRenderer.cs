using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DI_Framework_Workshop.Renderers.Contracts
{
    public interface IRenderer
    {
        public void Write(object obj);
        public void WriteLine(object obj);
    }
}
