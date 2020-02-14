using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct Rational2
    {
        public Rational x, y;

        public Rational2( Rational x, Rational y )
        {
            this.x = x;
            this.y = y;
        }

        public static readonly Rational2 Zero = new Rational2( new Rational( 0 ), new Rational( 0 ) );
        public static readonly Rational2 One = new Rational2( new Rational( 1 ), new Rational( 1 ) );

        // Addition
        public static Rational2 operator +( Rational2 a, Rational2 b )
        {
            return new Rational2( a.x + b.x, a.y + b.y );
        }

        // Unary Plus
        public static Rational2 operator +( Rational2 A )
        {
            return new Rational2( +A.x, +A.y );
        }

        // Subtraction
        public static Rational2 operator -( Rational2 a, Rational2 b )
        {
            return new Rational2( a.x - b.x, a.y - b.y );
        }

        // Unary Negative
        public static Rational2 operator -( Rational2 A )
        {
            return new Rational2( -A.x, -A.y );
        }

        // Dot Product
        public static Rational DotProduct( Rational2 a, Rational2 b )
        {
            return a.x * b.x + a.y * b.y;
        }

        // Cross Product returns last component of (Ax,Ay,0) x (Bx,By,0)
        public static Rational CrossProduct( Rational2 A, Rational2 B )
        {
            // Ax Ay 0 Ax Ay 0
            // Bx By 0 Bx By 0
            return A.x * B.y - B.x * A.y;
        }

        public Rational Magnitude2()
        {
            return x * x + y * y;
        }

        // Scalar Multiplication (Scalar 1st)
        public static Rational2 operator *( Rational2 a, Rational v )
        {
            return new Rational2( a.x * v, a.y * v );
        }

        // Scalar Multiplication (Scalar 2nd)
        public static Rational2 operator *( Rational v, Rational2 a )
        {
            return new Rational2( a.x * v, a.y * v );
        }

        // Vector Multiplication
        public static Rational2 operator *( Rational2 a, Rational2 b )
        {
            return new Rational2( a.x * b.x, a.y * b.y );
        }

        // Scalar division
        public static Rational2 operator /( Rational2 a, Rational v )
        {
            return a / v;
        }

        // Vector division
        public static Rational2 operator /( Rational2 a, Rational2 b )
        {
            return new Rational2( a.x / b.x, a.y / b.y );
        }

        public override string ToString()
        {
            return string.Format( "({0},{1})", x, y );
        }
    }
}
