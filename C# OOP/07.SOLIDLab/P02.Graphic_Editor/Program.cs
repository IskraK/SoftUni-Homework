using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape shape1 = new Circle();
            IShape shape2 = new Rectangle();
            IShape shape3 = new Square();

            shape1.DrawShape();
            shape2.DrawShape();
            shape3.DrawShape();
        }
    }
}
