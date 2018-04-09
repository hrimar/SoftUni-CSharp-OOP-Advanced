using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            var circle = new Circle();
            var graficEditor = new GraphicEditor();
            graficEditor.DrawShape(circle);
        }
    }
}
