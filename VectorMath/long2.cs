using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct long2
    {
        public long x, y;

        public long2( long x, long y )
        {
            this.x = x;
            this.y = y;
        }

        public long2( long2 A )
        {
            this.x = A.x;
            this.y = A.y;
        }

        public static readonly long2 Zero = new long2( 0, 0 );
        public static readonly long2 One = new long2( 1, 1 );

        // Addition
        public static long2 operator +( long2 A, long2 B )
        {
            return new long2( A.x + B.x, A.y + B.y );
        }

        // Unary Plus
        public static long2 operator +( long2 A )
        {
            return new long2( +A.x, +A.y );
        }

        // Subtraction
        public static long2 operator -( long2 A, long2 B )
        {
            return new long2( A.x - B.x, A.y - B.y );
        }

        // Unary Negative
        public static long2 operator -( long2 A )
        {
            return new long2( 0 - A.x, 0 - A.y );
        }

        // Scalar Multiplication
        public static long2 operator *( long2 A, long v )
        {
            return new long2( A.x * v, A.y * v );
        }

        // Vector Multiplication
        public static long2 operator *( long2 A, long2 B )
        {
            return new long2( A.x * B.x, A.y * B.y );
        }

        // Scalar Division
        public static long2 operator /( long2 A, long v )
        {
            return new long2( A.x / v, A.y / v );
        }

        // Vector Division
        public static long2 operator /( long2 A, long2 B )
        {
            return new long2( A.x / B.x, A.y / B.y );
        }

        // Dot Product (Inner Product)
        public static long DotProduct( long2 A, long2 B )
        {
            return A.x * B.x + A.y * B.y;
        }

        // Cross Product returns last component of (Ax,Ay,0) x (Bx,By,0)
        public static long CrossProduct( long2 A, long2 B )
        {
            return A.x * B.y - A.y * B.x;
        }

        // Magnitude (Length) squared
        public long Magnitude2()
        {
            return x * x + y * y;
        }

        // Conversion to String
        public override string ToString()
        {
            return string.Format( "{0}{1}, {2}{3}", '{', x, y, '}' );
        }
    }
}
