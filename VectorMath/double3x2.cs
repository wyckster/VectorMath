using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct double3x2
    {
        public double 
            m11, m21, m31,
            m12, m22, m32;

        public double3x2(
            double m11, double m21, double m31,
            double m12, double m22, double m32
            )
        {
            this.m11 = m11;
            this.m21 = m21;
            this.m31 = m31;
            this.m12 = m12;
            this.m22 = m22;
            this.m32 = m32;
        }

        public static double3x2 Identity = new double3x2( 1, 0, 0, 0, 1, 0 );

        public static double3x2 Translation( double2 displacement )
        {
            return new double3x2(
                1, 0, displacement.x,
                0, 1, displacement.y
                );
        }

        public static double3x2 Translation( double dx, double dy )
        {
            return new double3x2(
                1, 0, dx,
                0, 1, dy
                );
        }

        public static double3x2 Rotation( double angle_radians )
        {
            double C = Math.Cos( angle_radians );
            double S = Math.Sin( angle_radians );
            return new double3x2(
                C, S, 0,
                -S, C, 0
                );
        }

        public static double3x2 Scale( double2 scale )
        {
            return new double3x2(
                scale.x, 0, 0,
                0, scale.y, 0
                );
        }

        public static double3x2 Scale( double scale )
        {
            return new double3x2(
                scale, 0, 0,
                0, scale, 0
                );
        }

        // Vector Multiplication
        public static double2 operator *( double3x2 m, double2 v )
        {
            return new double2(
                m.m11 * v.x + m.m21 * v.y + m.m31,
                m.m12 * v.x + m.m22 * v.y + m.m32
                );
        }

        // Scalar Multiplication
        public static double3x2 operator *( double3x2 m, double s )
        {
            return new double3x2(
                m.m11 * s,
                m.m21 * s,
                m.m31 * s,
                m.m12 * s,
                m.m22 * s,
                m.m32 * s
                );
        }

        // Matrix Multiplication
        public static double3x2 operator *( double3x2 A, double3x2 B )
        {
            return new double3x2(
                A.m11 * B.m11 + A.m21 * B.m12,
                A.m11 * B.m21 + A.m21 * B.m22,
                A.m11 * B.m31 + A.m21 * B.m32 + A.m31,
                A.m12 * B.m11 + A.m22 * B.m12,
                A.m12 * B.m21 + A.m22 * B.m22,
                A.m12 * B.m31 + A.m22 * B.m32 + A.m32
                );
        }

        // Reverse multiplication.
        public double3x2 Then( double3x2 M )
        {
            return M * this;
        }

        // Conversion to String
        public override string ToString()
        {
            return string.Format( "|{0,6} {1,6} {2,6}|\n|{3,6} {4,6} {5,6}|",
                m11, m21, m31,
                m12, m22, m32
                );
        }

        // Inverse
        public double3x2 Inverse()
        {

            // m11 m21 m31
            // m12 m22 m32
            //   0   0   1
            double determinant = m11 * m22 - m21 * m12;

            // the cofactor matrix
            // m22 -m12 0
            // -m21 m11 0
            // m21 * m32 - m31 * m22   -( m11 * m32 - m31 * m12)    m11 * m22 - m21 * m12

            // the cofactor matrix transposed
            // m22 -m21  m21 * m32 - m31 * m22
            // -m12 m11  m31 * m12 - m11 * m32
            //   0   0   m11 * m22 - m21 * m12

            return new double3x2(
                m22, 0.0-m21, m21 * m32 - m31 * m22,
                0.0-m12, m11, m31 * m12 - m11 * m32
                ) * (1.0 / determinant);
        }

    }
}
