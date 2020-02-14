using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct double2x2
    {
        public double
            m11, m21,
            m12, m22;

        public double2x2(
            double m11, double m21,
            double m12, double m22
            )
        {
            this.m11 = m11;
            this.m21 = m21;
            this.m12 = m12;
            this.m22 = m22;
        }

        public static double2x2 Identity = new double2x2( 1, 0, 0, 1 );

        // Vector Multiplication
        public static double2 operator *( double2x2 m, double2 v )
        {
            return new double2(
                m.m11 * v.x + m.m21 * v.y,
                m.m12 * v.x + m.m22 * v.y
                );
        }

        // Scalar Multiplication
        public static double2x2 operator *( double2x2 m, double s )
        {
            return new double2x2(
                m.m11 * s,
                m.m21 * s,
                m.m12 * s,
                m.m22 * s
                );
        }

        // Matrix Multiplication
        public static double2x2 operator *( double2x2 A, double2x2 B )
        {
            return new double2x2(
                A.m11 * B.m11 + A.m21 * B.m12,
                A.m11 * B.m21 + A.m21 * B.m22,
                A.m12 * B.m11 + A.m22 * B.m12,
                A.m12 * B.m21 + A.m22 * B.m22
                );
        }

        // Reverse multiplication.
        public double2x2 Then( double2x2 M )
        {
            return M * this;
        }

        // Conversion to String
        public override string ToString()
        {
            return string.Format( "{0,6} {1,6}|\n|{2,6} {3,6}|",
                m11, m21,
                m21, m22
                );
        }

        // Inverse
        public double2x2 Inverse()
        {
            double determinant = m11 * m22 - m21 * m12;
            return new double2x2(
                m22, -m21,
                -m12, m11
                ) * (1.0 / determinant);
        }
    }
}
