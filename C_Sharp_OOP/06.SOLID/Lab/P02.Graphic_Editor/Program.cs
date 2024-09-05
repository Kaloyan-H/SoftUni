using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();

            IShape[] shapes = new IShape[]
            {
                new Circle(),
                new Square(),
                new Rectangle()
            };

            foreach (var shape in shapes)
            {
                graphicEditor.DrawShape(shape);
            }
        }
    }
}
