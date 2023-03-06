using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab7
{
    internal class Triangle : Shape
    {
        double Base,heigth;

        public Triangle(double Base, double heigth)
        {
            Base = Base;
            this.heigth = heigth;
        }

        public override double getArea()
        {
            return Base * heigth;
        }

        public override void toString()
        {
            throw new NotImplementedException();
        }
    }
}
