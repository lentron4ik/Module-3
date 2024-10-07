using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    public class Triangle : Shape
    {
        public double Base { get; set; }
        public double Height { get; set; }

        public Triangle(double @base, double height)
        {
            Base = @base;
            Height = height;
        }

        // Переопределение метода для вычисления площади треугольника
        public override double CalculateArea()
        {
            return 0.5 * Base * Height;
        }
    }
}
