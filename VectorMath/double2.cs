using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct double2
    {
        public double x, y;

        public double2( double x, double y )
        {
            this.x = x;
            this.y = y;
        }

        public double2( double2 A )
        {
            this.x = A.x;
            this.y = A.y;
        }

        public static readonly double2 Zero = new double2( 0, 0 );
        public static readonly double2 One = new double2( 1, 1 );

        // Addition
        public static double2 operator +( double2 A, double2 B )
        {
            return new double2( A.x + B.x, A.y + B.y );
        }

        // Unary Plus
        public static double2 operator +( double2 A )
        {
            return new double2( +A.x, +A.y );
        }

        // Subtraction
        public static double2 operator -( double2 A, double2 B )
        {
            return new double2( A.x - B.x, A.y - B.y );
        }

        // Unary Negative
        public static double2 operator -( double2 A )
        {
            return new double2( 0.0-A.x, 0.0-A.y );
        }

        // Scalar Multiplication
        public static double2 operator *( double2 A, double v )
        {
            return new double2( A.x * v, A.y * v );
        }

        // Scalar Multiplication
        public static double2 operator *( double v, double2 A )
        {
            return new double2( v * A.x, v * A.y );
        }

        // Vector Multiplication
        public static double2 operator *( double2 A, double2 B )
        {
            return new double2( A.x * B.x, A.y * B.y );
        }

        // Scalar Division
        public static double2 operator /( double2 A, double v )
        {
            return new double2( A.x / v, A.y / v );
        }

        // Vector Division
        public static double2 operator /( double2 A, double2 B )
        {
            return new double2( A.x / B.x, A.y / B.y );
        }

        // Dot Product (Inner Product)
        public static double DotProduct( double2 A, double2 B )
        {
            return A.x * B.x + A.y * B.y;
        }

        // Cross Product returns last component of (Ax,Ay,0) x (Bx,By,0)
        public static double CrossProduct( double2 A, double2 B )
        {
            return A.x * B.y - A.y * B.x;
        }

        // Magnitude (Length) squared
        public double Magnitude2()
        {
            return x * x + y * y;
        }

        // Magnitude (Length)
        public double Magnitude()
        {
            return Math.Sqrt( Magnitude2() );
        }

        public double2 Normalized()
        {
            double m = this.Magnitude();
            if( m != 0 ) {
                return this * (1.0 / m);
            } else {
                return double2.Zero;
            }
        }

        // Conversion to String
        public override string ToString()
        {
            return string.Format( "{0}{1}, {2}{3}", '(', x, y, ')' );
        }
    }
}
