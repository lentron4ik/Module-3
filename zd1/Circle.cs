using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zd1
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            Radius = radius;
        }

        // Переопределение метода для вычисления площади круга
        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }
}
