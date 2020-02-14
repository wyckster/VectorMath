using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct int2
    {
        public int x, y;

        public int2( int x, int y )
        {
            this.x = x;
            this.y = y;
        }

        public int2( int2 A )
        {
            this.x = A.x;
            this.y = A.y;
        }

        public static readonly int2 Zero = new int2( 0, 0 );
        public static readonly int2 One = new int2( 1, 1 );

        // Addition
        public static int2 operator +( int2 A, int2 B )
        {
            return new int2( A.x + B.x, A.y + B.y );
        }

        // Unary Plus
        public static int2 operator +( int2 A )
        {
            return new int2( +A.x, +A.y );
        }

        // Subtraction
        public static int2 operator -( int2 A, int2 B )
        {
            return new int2( A.x - B.x, A.y - B.y );
        }

        // Unary Negative
        public static int2 operator -( int2 A )
        {
            return new int2( 0 - A.x, 0 - A.y );
        }

        // Scalar Multiplication
        public static int2 operator *( int2 A, int v )
        {
            return new int2( A.x * v, A.y * v );
        }

        // Vector Multiplication
        public static int2 operator *( int2 A, int2 B )
        {
            return new int2( A.x * B.x, A.y * B.y );
        }

        // Scalar Division
        public static int2 operator /( int2 A, int v )
        {
            return new int2( A.x / v, A.y / v );
        }

        // Vector Division
        public static int2 operator /( int2 A, int2 B )
        {
            return new int2( A.x / B.x, A.y / B.y );
        }

        // Dot Product (Inner Product)
        public static int DotProduct( int2 A, int2 B )
        {
            return A.x * B.x + A.y * B.y;
        }

        // Cross Product returns last component of (Ax,Ay,0) x (Bx,By,0)
        public static int CrossProduct( int2 A, int2 B )
        {
            return A.x * B.y - A.y * B.x;
        }

        // Magnitude (Length) squared
        public int Magnitude2()
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
