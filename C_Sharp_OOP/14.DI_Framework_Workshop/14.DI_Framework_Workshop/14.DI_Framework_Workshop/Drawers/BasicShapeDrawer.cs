using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DI_Framework_Workshop.Drawers
{
    using Renderers.Contracts;
    using Contracts;
    using Shapes;

    public class BasicShapeDrawer : IShapeDrawer
    {
        private readonly IRenderer renderer;

        public BasicShapeDrawer(IRenderer renderer)
        {
            this.renderer = renderer;
        }

        public void DrawCircle(Circle circle)
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(@"   ****")
                .AppendLine(@" **    **")
                .AppendLine(@"*        *")
                .AppendLine(@"*        *")
                .AppendLine(@" **    **")
                .AppendLine(@"   ****");

            renderer.WriteLine(sb.ToString().TrimEnd());
        }

        public void DrawRectangle(Rectangle rectangle)
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine(@"*******")
                .AppendLine(@"*     *")
                .AppendLine(@"*     *")
                .AppendLine(@"*     *")
                .AppendLine(@"*******");

            renderer.WriteLine(sb.ToString().TrimEnd());
        }
    }
}
