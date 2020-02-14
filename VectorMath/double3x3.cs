using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct double3x3
    {
        double 
            m11, m21, m31,
            m12, m22, m32,
            m13, m23, m33;

        public double3x3(
            double m11, double m21, double m31,
            double m12, double m22, double m32,
            double m13, double m23, double m33 )
        {
            this.m11 = m11;
            this.m21 = m21;
            this.m31 = m31;
            this.m12 = m12;
            this.m22 = m22;
            this.m32 = m32;
            this.m13 = m13;
            this.m23 = m23;
            this.m33 = m33;
        }

        public static double3x3 operator *( double3x3 a, double3x3 b )
        {
            return new double3x3(
                a.m11 * b.m11 + a.m21 * b.m12 + a.m31 * b.m13,
                a.m11 * b.m21 + a.m21 * b.m22 + a.m31 * b.m23,
                a.m11 * b.m31 + a.m21 * b.m32 + a.m31 * b.m33,
                a.m12 * b.m11 + a.m22 * b.m12 + a.m32 * b.m13,
                a.m12 * b.m21 + a.m22 * b.m22 + a.m32 * b.m23,
                a.m12 * b.m31 + a.m22 * b.m32 + a.m32 * b.m33,
                a.m13 * b.m11 + a.m23 * b.m12 + a.m33 * b.m13,
                a.m13 * b.m21 + a.m23 * b.m22 + a.m33 * b.m23,
                a.m13 * b.m31 + a.m23 * b.m32 + a.m33 * b.m33
                );
        }

        public static double3x3 operator *( double3x3 a, double b )
        {
            return new double3x3(
                a.m11 * b, a.m21 * b, a.m31 * b,
                a.m12 * b, a.m22 * b, a.m32 * b,
                a.m13 * b, a.m23 * b, a.m33 * b
                );
        }

        public static readonly double3x3 Identity = new double3x3(
            1.0, 0.0, 0.0,
            0.0, 1.0, 0.0,
            0.0, 0.0, 1.0
            );

        public static double3x3 Translation( double2 d )
        {
            return Translation( d.x, d.y );
        }
        public static double3x3 Translation( double dx, double dy )
        {
            return new double3x3(
                1.0, 0.0, dx,
                0.0, 1.0, dy,
                0.0, 0.0, 1.0
                );
        }

        public static double2 operator *( double3x3 m, double2 v )
        {
            return new double2(
                m.m11 * v.x + m.m21 * v.y + m.m31,
                m.m12 * v.x + m.m22 * v.y + m.m32
                );
        }
        public static double3 operator *( double3x3 m, double3 v )
        {
            return new double3(
                m.m11 * v.x + m.m21 * v.y + m.m31 * v.z,
                m.m12 * v.x + m.m22 * v.y + m.m32 * v.z,
                m.m13 * v.x + m.m23 * v.y + m.m33 * v.z
                );
        }

        public static double3x3 Rotation( double angle )
        {
            double c = Math.Cos( angle );
            double s = Math.Sin( angle );
            return new double3x3(
                c, s, 0.0,
                -s, c, 0.0,
                0.0, 0.0, 1.0
                );
        }

        public static double3x3 Scale( double sx, double sy )
        {
            return new double3x3(
                sx, 0.0, 0.0,
                0.0, sy, 0.0,
                0.0, 0.0, 1.0
                );
        }

        public double Determinant()
        {
            return m11 * (m33 * m22 - m23 * m32) - m12 * (m33 * m21 - m23 * m31) + m13 * (m32 * m21 - m22 * m31);
        }

        public double3x3 Adjoint()
        {
            return new double3x3(
                m33 * m22 - m23 * m32, -(m33 * m21 - m23 * m31), m32 * m21 - m22 * m31,
                -(m33 * m12 - m13 * m32), m33 * m11 - m13 * m31, -(m32 * m11 - m12 * m31),
                m23 * m12 - m13 * m22, -(m23 * m11 - m13 * m21), m22 * m11 - m12 * m21
                );
        }

        public double3x3 Inverse()
        {
            double D = Determinant();
            if( D != 0.0 )
            {
                return Adjoint() * (1.0 / D);
            }
            else
            {
                return double3x3.Identity;
            }
        }
    }
}
