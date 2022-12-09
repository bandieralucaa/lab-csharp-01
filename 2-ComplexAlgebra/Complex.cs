using System;

namespace ComplexAlgebra
{
    /// <summary>
    /// A type for representing Complex numbers.
    /// </summary>
    ///
    /// TODO: Model Complex numbers in an object-oriented way and implement this class.
    /// TODO: In other words, you must provide a means for:
    /// TODO: * instantiating complex numbers
    /// TODO: * accessing a complex number's real, and imaginary parts
    /// TODO: * accessing a complex number's modulus, and phase
    /// TODO: * complementing a complex number
    /// TODO: * summing up or subtracting two complex numbers
    /// TODO: * representing a complex number as a string or the form Re +/- iIm
    /// TODO:     - e.g. via the ToString() method
    /// TODO: * checking whether two complex numbers are equal or not
    /// TODO:     - e.g. via the Equals(object) method
    public class Complex
    {
        // TODO: fill this class\
        public int Real { get; set; }
        public int Imaginary { get; set; }

        public Complex(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }   

        public double Modulus => Math.Sqrt(Real * Real + Imaginary * Imaginary);
        
        public double Phase => Math.Atan2(Imaginary, Real);

        public Complex Complement() => new Complex(Real, -Imaginary);

        protected bool Equals(Complex other)
        {
            return Real == other.Real && Imaginary == other.Imaginary;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Complex) obj);
        }


        public override int GetHashCode() => HashCode.Combine(Real, Imaginary);

        public Complex Plus(Complex other) => new Complex(Real + other.Real, Imaginary + other.Imaginary);

        public Complex Minus(Complex other) => new Complex(Real - other.Real, Imaginary - other.Imaginary);

        public override string ToString()
        {
            if (Imaginary == 0.0) return Real.ToString();
            var ima = Math.Abs(Imaginary);
            var val = ima == 1.0 ? "" : ima.ToString();
            string s;
            if (Real == 0.0)
            {
                s = Imaginary > 0 ? "" : "-";
                return s + val + "i";
            }

            s = Imaginary > 0 ? " + " : " - ";
            return $"{Real}{s}{val}i";
        }

        
    }
}