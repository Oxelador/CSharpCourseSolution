using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCourse.Homework11
{
    public class Complex
    {
        public double Real { get; private set; }
        public double Imaginary { get; private set; }

        public Complex(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public Complex Plus(Complex complex)
        {
            Real += complex.Real;
            Imaginary += complex.Imaginary;
            return new Complex(Real, Imaginary);
        }

        public Complex Minus(Complex complex)
        {
            Real -= complex.Real;
            Imaginary -= complex.Imaginary;
            return new Complex(Real, Imaginary);
        }
    }
}
