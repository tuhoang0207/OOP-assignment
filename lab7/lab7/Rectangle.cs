using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class Rectangle : Shape
    {
        double length,width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public override double getArea()
        {
            return length * width;
        }

        public override void toString()
        {   
            double result = getArea();
            Console.WriteLine(result);
        }
    }
}
