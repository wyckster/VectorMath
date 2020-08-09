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

        public static bool operator <(Rational lhs, Rational rhs)
        {
            if (lhs.denominator < 0) {
                if (rhs.denominator < 0) {
                    return lhs.numerator * rhs.denominator < rhs.numerator * lhs.denominator;
                } else {
                    return lhs.numerator * rhs.denominator > rhs.numerator * lhs.denominator;
                }
            } else {
                if (rhs.denominator < 0) {
                    return lhs.numerator * rhs.denominator > rhs.numerator * lhs.denominator;
                } else {
                    return lhs.numerator * rhs.denominator < rhs.numerator * lhs.denominator;
                }
            }
        }

        public static bool operator <=(Rational lhs, Rational rhs)
        {
            if (lhs.denominator < 0) {
                if (rhs.denominator < 0) {
                    return lhs.numerator * rhs.denominator <= rhs.numerator * lhs.denominator;
                } else {
                    return lhs.numerator * rhs.denominator >= rhs.numerator * lhs.denominator;
                }
            } else {
                if (rhs.denominator < 0) {
                    return lhs.numerator * rhs.denominator >= rhs.numerator * lhs.denominator;
                } else {
                    return lhs.numerator * rhs.denominator <= rhs.numerator * lhs.denominator;
                }
            }
        }

        public static bool operator >(Rational lhs, Rational rhs)
        {
            if (lhs.denominator < 0) {
                if (rhs.denominator < 0) {
                    return lhs.numerator * rhs.denominator > rhs.numerator * lhs.denominator;
                } else {
                    return lhs.numerator * rhs.denominator < rhs.numerator * lhs.denominator;
                }
            } else {
                if (rhs.denominator < 0) {
                    return lhs.numerator * rhs.denominator < rhs.numerator * lhs.denominator;
                } else {
                    return lhs.numerator * rhs.denominator > rhs.numerator * lhs.denominator;
                }
            }
        }

        public static bool operator >=(Rational lhs, Rational rhs)
        {
            if (lhs.denominator < 0) {
                if (rhs.denominator < 0) {
                    return lhs.numerator * rhs.denominator >= rhs.numerator * lhs.denominator;
                } else {
                    return lhs.numerator * rhs.denominator <= rhs.numerator * lhs.denominator;
                }
            } else {
                if (rhs.denominator < 0) {
                    return lhs.numerator * rhs.denominator <= rhs.numerator * lhs.denominator;
                } else {
                    return lhs.numerator * rhs.denominator >= rhs.numerator * lhs.denominator;
                }
            }
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
            return (ulong)(this.numerator / this.denominator);
        }

        public sbyte ToSByte( IFormatProvider provider )
        {
            return (sbyte)(this.numerator / this.denominator);
        }

        public static implicit operator double(Rational r)
        {
            return ((double)r.numerator) / ((double)r.denominator);
        }

        public static implicit operator Rational(long d)
        {
            return new Rational(d);
        }

        public double ToDouble( IFormatProvider provider )
        {
            return ((double)this.numerator) / ((double)this.denominator);
        }

        public DateTime ToDateTime( IFormatProvider provider )
        {
            return new DateTime();
        }

        public float ToSingle( IFormatProvider provider )
        {
            return ((float)this.numerator) / ((float)this.denominator);
        }

        public bool ToBoolean( IFormatProvider provider )
        {
            return (this.numerator != 0);
        }

        public int ToInt32( IFormatProvider provider )
        {
            return (int)(this.numerator / this.denominator);
        }

        public ushort ToUInt16( IFormatProvider provider )
        {
            return (ushort)(this.numerator / this.denominator);
        }

        public short ToInt16( IFormatProvider provider )
        {
            return (short)(this.numerator / this.denominator);
        }

        string System.IConvertible.ToString( IFormatProvider provider )
        {
            return this.ToString();
        }

        public byte ToByte( IFormatProvider provider )
        {
            return (byte)(this.numerator / this.denominator);
        }

        public char ToChar( IFormatProvider provider )
        {
            return '/';
        }

        public long ToInt64( IFormatProvider provider )
        {
            return (this.numerator / this.denominator);
        }

        public System.TypeCode GetTypeCode()
        {
            return TypeCode.Object;
        }

        public decimal ToDecimal( IFormatProvider provider )
        {
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

        public static bool TryParse(string text, out Rational result)
        {
            // depends on whether or not there is a '/' character.
            string[] fields = text.Split('/');
            if (fields.Length == 2) {
                if (Rational.TryParse(fields[0], out Rational num) && Rational.TryParse(fields[1], out Rational den)) {
                    result = num / den;
                    return true;
                } else {
                    result = Rational.Zero;
                    return false;
                }
            } else if (fields.Length == 1) {
                // No. no slash.
                string[] decfields = text.Split('.');
                if (decfields.Length == 2) {
                    if (long.TryParse(decfields[0], out long n) && long.TryParse(decfields[1], out long d)) {
                        int pow = decfields[1].Length;
                        long f = 10;
                        for (int i = 1; i < pow; ++i) {
                            f *= 10;
                        }
                        result = new Rational(n * f + d, f);
                        return true;
                    } else {
                        result = Rational.Zero;
                        return false;
                    }
                } else if (decfields.Length == 1) {
                    if (long.TryParse(decfields[0], out long num)) {
                        result = new Rational(num);
                        return true;
                    } else {
                        result = Rational.Zero;
                        return false;
                    }
                } else {
                    result = Rational.Zero;
                    return false;
                }
            } else {
                result = Rational.Zero;
                return false;
            }
        }
        #endregion
    }
}
