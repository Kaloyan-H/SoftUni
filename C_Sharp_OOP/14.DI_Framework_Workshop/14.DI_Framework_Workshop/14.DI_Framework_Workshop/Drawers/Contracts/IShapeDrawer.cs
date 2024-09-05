using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DI_Framework_Workshop.Drawers.Contracts
{
    using Shapes;

    public interface IShapeDrawer
    {
        public void DrawCircle(Circle circle);
        public void DrawRectangle(Rectangle rectangle);
    }
}
