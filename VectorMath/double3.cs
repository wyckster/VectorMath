using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct double3
    {
        public double x, y, z;

        public double3( double x, double y, double z )
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public double3( double2 v, double z )
        {
            this.x = v.x;
            this.y = v.y;
            this.z = z;
        }

        public double3( double3 V )
        {
            this.x = V.x;
            this.y = V.y;
            this.z = V.z;
        }

        public static readonly double3 Zero = new double3( 0, 0, 0 );
        public static readonly double3 One = new double3( 1, 1, 1 );

        // Addition
        public static double3 operator +( double3 A, double3 B )
        {
            return new double3( A.x + B.x, A.y + B.y, A.z + B.z );
        }

        // Unary Plus
        public static double3 operator +( double3 A )
        {
            return new double3( +A.x, +A.y, +A.z );
        }

        // Subtraction
        public static double3 operator -( double3 A, double3 B )
        {
            return new double3( A.x - B.x, A.y - B.y, A.z - B.z );
        }

        // Unary Negative
        public static double3 operator -( double3 A )
        {
            return new double3( 0.0-A.x, 0.0-A.y, 0.0-A.z );
        }

        // Scalar Multiplication
        public static double3 operator *( double3 A, double v )
        {
            return new double3( A.x * v, A.y * v, A.z * v );
        }

        // Vector Multiplication
        public static double3 operator *( double3 A, double3 B )
        {
            return new double3( A.x * B.x, A.y * B.y, A.z * B.z );
        }

        // Scalar Division
        public static double3 operator /( double3 A, double v )
        {
            return new double3( A.x / v, A.y / v, A.z / v );
        }

        // Vector Division
        public static double3 operator /( double3 A, double3 B )
        {
            return new double3( A.x / B.x, A.y / B.y, A.z / B.z );
        }

        // Dot Product (Inner Product)
        public static double DotProduct( double3 A, double3 B )
        {
            return A.x * B.x + A.y * B.y + A.z * B.z;
        }

        // Cross Product
        public static double3 CrossProduct( double3 A, double3 B )
        {
            // Ax Ay Az Ax Ay Az
            // Bx By Bz Bx By Bz
            return new double3(
                A.y * B.z - A.z * B.y,
                A.z * B.x - A.x * B.z,
                A.x * B.y - A.y * B.x );
        }

        // Magnitude (Length) squared
        public double Magnitude2()
        {
            return x * x + y * y + z * z;
        }

        // Magnitude (Length)
        public double Magnitude()
        {
            return Math.Sqrt( Magnitude2() );
        }

        public double3 Normalized()
        {
            double m = this.Magnitude();
            if( m != 0 ) {
                return this * (1.0 / m);
            } else {
                return double3.Zero;
            }
        }

        // Determinant of 3 vectors forming a 3x3 matrix
        public static double Det3( double3 A, double3 B, double3 C )
        {
            return
                 A.x * (B.y * C.z - B.z * C.y)
               - A.y * (B.x * C.z - B.z * C.x)
               + A.z * (B.x * C.y - B.y * C.x);
        }

        // Conversion to String
        public override string ToString()
        {
            return string.Format( "{0}{1}, {2}, {3}{4}", '(', x, y, z, ')' );
        }

        // Homogeneous coordinates
        public double4 xyz1
        {
            get
            {
                return new double4( x, y, z, 1 );
            }
        }

        public double2 xy
        {
            get
            {
                return new double2( x, y );
            }
        }
    }
}
