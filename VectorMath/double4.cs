using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct double4
    {
        public double x, y, z, w;

        public double4( double x, double y, double z, double w )
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public double4( double4 A )
        {
            this.x = A.x;
            this.y = A.y;
            this.z = A.z;
            this.w = A.w;
        }

        public double4( double3 xyz, double w )
        {
            this.x = xyz.x;
            this.y = xyz.y;
            this.z = xyz.z;
            this.w = w;
        }

        public static readonly double4 Zero = new double4( 0, 0, 0, 0 );
        public static readonly double4 One = new double4( 1, 1, 1, 1 );

        // Addition
        public static double4 operator +( double4 A, double4 B )
        {
            return new double4( A.x + B.x, A.y + B.y, A.z + B.z, A.w + B.w );
        }

        // Unary Plus
        public static double4 operator +( double4 A )
        {
            return new double4( +A.x, +A.y, +A.z, +A.w );
        }

        // Subtraction
        public static double4 operator -( double4 A, double4 B )
        {
            return new double4( A.x - B.x, A.y - B.y, A.z - B.z, A.w - B.w );
        }

        // Unary Negative
        public static double4 operator -( double4 A )
        {
            return new double4( 0.0 - A.x, 0.0 - A.y, 0.0 - A.z, 0.0 - A.w );
        }

        // Scalar Multiplication
        public static double4 operator *( double4 A, double v )
        {
            return new double4( A.x * v, A.y * v, A.z * v, A.w * v );
        }

        // Vector Multiplication
        public static double4 operator *( double4 A, double4 B )
        {
            return new double4( A.x * B.x, A.y * B.y, A.z * B.z, A.w * B.w );
        }

        // Scalar Division
        public static double4 operator /( double4 A, double v )
        {
            return new double4( A.x / v, A.y / v, A.z / v, A.w / v );
        }

        // Vector Division
        public static double4 operator /( double4 A, double4 B )
        {
            return new double4( A.x / B.x, A.y / B.y, A.z / B.z, A.w / B.w );
        }

        // Dot Product (Inner Product)
        public static double DotProduct( double4 A, double4 B )
        {
            return A.x * B.x + A.y * B.y + A.z * B.z + A.w * B.w;
        }

        // Magnitude (Length) squared
        public double Magnitude2()
        {
            return x * x + y * y + z * z * w * w;
        }

        // Magnitude (Length)
        public double Magnitude()
        {
            return Math.Sqrt( Magnitude2() );
        }

        // Conversion to String
        public override string ToString()
        {
            return string.Format( "{0}{1}, {2}, {3}, {4}{5}", '(', x, y, z, w, ')' );
        }

        // Swizzle
        public double2 xy
        {
            get
            {
                return new double2( x, y );
            }
        }

        public double3 xyz
        {
            get
            {
                return new double3( x, y, z );
            }
        }
    }
}
