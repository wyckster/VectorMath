using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    using System;

    public struct Rational : IConvertible
    {
        public long numerator;
        public long denominator;

        public Rational( long numerator )
        {
            this.numerator = numerator;
            this.denominator = 1L;
        }
        public Rational( long numerator, long denominator )
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }

        public static readonly Rational Zero = new Rational( 0, 1 );
        public static readonly Rational One = new Rational( 1, 1 );

        // Conversion to String
        public override System.String ToString()
        {
            return this.numerator.ToString() + "/" + this.denominator.ToString();
        }

        // Addition
        public static Rational operator +( Rational r1, Rational r2 )
        {
            // (a / b) + (c / d)
            // (a * d) / (b * d) + (c * b) / (d * b)
            // ((a * d) + (c * b)) / (d * b)
            if( r1.denominator == r2.denominator )
            {
                return new Rational( r1.numerator + r2.numerator, r1.denominator );
            }
            else
            {
                return new Rational( r1.numerator * r2.denominator + r2.numerator * r1.denominator, r2.denominator * r1.denominator );
            }
        }

        // Unary Plus
        public static Rational operator +( Rational A )
        {
            return new Rational( +A.numerator, A.denominator );
        }

        // Subtraction
        public static Rational operator -( Rational r1, Rational r2 )
        {

            // (a / b) - (c / d)
            // (a * d) / (b * d) + (c * b) / (d * b)
            // ((a * d) - (c * b)) / (d * b)
            if( r1.denominator == r2.denominator )
            {
                return new Rational( r1.numerator - r2.numerator, r1.denominator );
            }
            else
            {
                return new Rational( r1.numerator * r2.denominator - r2.numerator * r1.denominator, r2.denominator * r1.denominator );
            }
        }

        // Unary Negative
        public static Rational operator -( Rational A )
        {
            return new Rational( -A.numerator, A.denominator );
        }

        // Multiplication
        public static Rational operator *( Rational r1, Rational r2 )
        {
            // (a / b) * (c / d)
            // (a * c ) / ( b * d )
            return new Rational( r1.numerator * r2.numerator, r1.denominator * r2.denominator );
        }

        // Division
        public static Rational operator /( Rational r1, Rational r2 )
        {
            // (a / b) / (c / d)
            // (a / b) * (d / c)
            // (a * d) / (b * c)
            return new Rational( r1.numerator * r2.denominator, r1.denominator * r2.numerator );
        }

        // Reduce to lowest terms, in place.
        public void Reduce()
        {
            if( this.numerator == 0 )
            {
                this.denominator = 1L;
            }
            else
            {
                long n = GCD( this.numerator, this.denominator );
                this.numerator /= n;
                this.denominator /= n;
            }
        }

        // Compute greatest common divisor
        private static long GCD( long num1, long num2 )
        {
            long a;
            long b;
            if( num1 > num2 )
            {
                a = num1;
                b = num2;
            }
            else
            {
                b = num1;
                a = num2;
            }
            long n;
            while( true )
            {
                n = a % b;
                if( n == 0 )
                {
                    return b;
                }
                else
                {
                    a = b;
                    b = n;
                }
            }
        }

        // Reciprocal (1/x)
        public Rational Reciprocal()
        {
            return new Rational( denominator, numerator );
        }

        #region IConvertible Members

        public ulong ToUInt64( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToUInt64 implementation
            return (ulong)(this.numerator / this.denominator);
        }

        public sbyte ToSByte( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToSByte implementation
            return (sbyte)(this.numerator / this.denominator);
        }

        public double ToDouble( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToDouble implementation
            return ((double)this.numerator) / ((double)this.denominator);
        }

        public DateTime ToDateTime( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToDateTime implementation
            return new DateTime();
        }

        public float ToSingle( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToSingle implementation
            return ((float)this.numerator) / ((float)this.denominator);
        }

        public bool ToBoolean( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToBoolean implementation
            return (this.numerator != 0);
        }

        public int ToInt32( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToInt32 implementation
            return (int)(this.numerator / this.denominator);
        }

        public ushort ToUInt16( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToUInt16 implementation
            return (ushort)(this.numerator / this.denominator);
        }

        public short ToInt16( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToInt16 implementation
            return (short)(this.numerator / this.denominator);
        }

        string System.IConvertible.ToString( IFormatProvider provider )
        {
            // TODO:  Add Rational.System.IConvertible.ToString implementation
            return this.ToString();
        }

        public byte ToByte( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToByte implementation
            return (byte)(this.numerator / this.denominator);
        }

        public char ToChar( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToChar implementation
            return '/';
        }

        public long ToInt64( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToInt64 implementation
            return (this.numerator / this.denominator);
        }

        public System.TypeCode GetTypeCode()
        {
            // TODO:  Add Rational.GetTypeCode implementation
            return TypeCode.Object;
        }

        public decimal ToDecimal( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToDecimal implementation
            return ((decimal)this.numerator) / ((decimal)this.denominator);
        }

        public object ToType( Type conversionType, IFormatProvider provider )
        {
            // TODO:  Add Rational.ToType implementation
            return null;
        }

        public uint ToUInt32( IFormatProvider provider )
        {
            // TODO:  Add Rational.ToUInt32 implementation
            return (uint)(this.numerator / this.denominator);
        }

        #endregion
    }
}
