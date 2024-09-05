using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DI_Framework_Workshop
{
    using Drawers.Contracts;
    using Shapes;

    public class Engine
    {
        private IShapeDrawer shapeDrawer;
        private List<Shape> shapes;

        private Engine()
        {
            shapes = new List<Shape>();
            shapes.Add(new Circle());
            shapes.Add(new Rectangle());
        }
        public Engine(IShapeDrawer shapeDrawer)
            : this()
        {
            this.shapeDrawer = shapeDrawer;
        }
        
        public void Run()
        {
            foreach (var shape in shapes)
            {
                if (shape is Circle)
                {
                    shapeDrawer.DrawCircle(shape as Circle);
                }
                if (shape is Rectangle)
                {
                    shapeDrawer.DrawRectangle(shape as Rectangle);
                }
            }
        }
    }
}
