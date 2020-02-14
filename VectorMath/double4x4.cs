using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    public struct double4x4
    {
        public double
            m11, m21, m31, m41,
            m12, m22, m32, m42,
            m13, m23, m33, m43,
            m14, m24, m34, m44;

        public double4x4(
            double m11, double m21, double m31, double m41,
            double m12, double m22, double m32, double m42,
            double m13, double m23, double m33, double m43,
            double m14, double m24, double m34, double m44
            )
        {
            this.m11 = m11;
            this.m21 = m21;
            this.m31 = m31;
            this.m41 = m41;

            this.m12 = m12;
            this.m22 = m22;
            this.m32 = m32;
            this.m42 = m42;

            this.m13 = m13;
            this.m23 = m23;
            this.m33 = m33;
            this.m43 = m43;

            this.m14 = m14;
            this.m24 = m24;
            this.m34 = m34;
            this.m44 = m44;
        }

        public override string ToString()
        {
            return string.Format( "|{0,6} {1,6} {2,6} {3,6}|\n|{4,6} {5,6} {6,6} {7,6}|\n|{8,6} {9,6} {10,6} {11,6}|\n|{12,6} {13,6} {14,6} {15,6}|",
                m11, m21, m31, m41,
                m12, m22, m32, m42,
                m13, m23, m33, m43,
                m14, m24, m34, m44
                );
        }

        public static double4x4 Translation( double3 displacement )
        {
            return new double4x4(
                1, 0, 0, displacement.x,
                0, 1, 0, displacement.y,
                0, 0, 1, displacement.z,
                0, 0, 0, 1
                );
        }

        public static double4x4 Scale( double3 scale )
        {
            return new double4x4(
                scale.x, 0, 0, 0,
                0, scale.y, 0, 0,
                0, 0, scale.z, 0,
                0, 0, 0, 1
                );
        }

        public static double4x4 Scale( double scale )
        {
            return new double4x4(
                scale, 0, 0, 0,
                0, scale, 0, 0,
                0, 0, scale, 0,
                0, 0, 0, 1
                );
        }

        public static double4x4 operator *( double4x4 A, double v )
        {
            return new double4x4(
                A.m11 * v,
                A.m21 * v,
                A.m31 * v,
                A.m41 * v,

                A.m12 * v,
                A.m22 * v,
                A.m32 * v,
                A.m42 * v,

                A.m13 * v,
                A.m23 * v,
                A.m33 * v,
                A.m43 * v,

                A.m14 * v,
                A.m24 * v,
                A.m34 * v,
                A.m44 * v
                );
        }

        public static double4x4 operator *( double4x4 A, double4x4 B )
        {
            return new double4x4(
                A.m11 * B.m11 + A.m21 * B.m12 + A.m31 * B.m13 + A.m41 * B.m14,
                A.m11 * B.m21 + A.m21 * B.m22 + A.m31 * B.m23 + A.m41 * B.m24,
                A.m11 * B.m31 + A.m21 * B.m32 + A.m31 * B.m33 + A.m41 * B.m34,
                A.m11 * B.m41 + A.m21 * B.m42 + A.m31 * B.m43 + A.m41 * B.m44,

                A.m12 * B.m11 + A.m22 * B.m12 + A.m32 * B.m13 + A.m42 * B.m14,
                A.m12 * B.m21 + A.m22 * B.m22 + A.m32 * B.m23 + A.m42 * B.m24,
                A.m12 * B.m31 + A.m22 * B.m32 + A.m32 * B.m33 + A.m42 * B.m34,
                A.m12 * B.m41 + A.m22 * B.m42 + A.m32 * B.m43 + A.m42 * B.m44,

                A.m13 * B.m11 + A.m23 * B.m12 + A.m33 * B.m13 + A.m43 * B.m14,
                A.m13 * B.m21 + A.m23 * B.m22 + A.m33 * B.m23 + A.m43 * B.m24,
                A.m13 * B.m31 + A.m23 * B.m32 + A.m33 * B.m33 + A.m43 * B.m34,
                A.m13 * B.m41 + A.m23 * B.m42 + A.m33 * B.m43 + A.m43 * B.m44,

                A.m14 * B.m11 + A.m24 * B.m12 + A.m34 * B.m13 + A.m44 * B.m14,
                A.m14 * B.m21 + A.m24 * B.m22 + A.m34 * B.m23 + A.m44 * B.m24,
                A.m14 * B.m31 + A.m24 * B.m32 + A.m34 * B.m33 + A.m44 * B.m34,
                A.m14 * B.m41 + A.m24 * B.m42 + A.m34 * B.m43 + A.m44 * B.m44
                );
        }

        public double4x4 Then( double4x4 M )
        {
            return M * this;
        }

        public static double4x4 Identity = new double4x4(
            1, 0, 0, 0,
            0, 1, 0, 0,
            0, 0, 1, 0,
            0, 0, 0, 1
            );

        public static double3 operator *( double4x4 A, double3 v )
        {
            return new double3(
                A.m11 * v.x + A.m21 * v.y + A.m31 * v.z + A.m41,
                A.m12 * v.x + A.m22 * v.y + A.m32 * v.z + A.m42,
                A.m13 * v.x + A.m23 * v.y + A.m33 * v.z + A.m43
                );
        }

        public static double4 operator *( double4x4 A, double4 v )
        {
            return new double4(
                A.m11 * v.x + A.m21 * v.y + A.m31 * v.z + A.m41 * v.w,
                A.m12 * v.x + A.m22 * v.y + A.m32 * v.z + A.m42 * v.w,
                A.m13 * v.x + A.m23 * v.y + A.m33 * v.z + A.m43 * v.w,
                A.m14 * v.x + A.m24 * v.y + A.m34 * v.z + A.m44 * v.w
                );
        }

        public double Determinant()
        {
            return 0
            + m11 * m22 * m33 * m44 + m11 * m32 * m43 * m24 + m11 * m42 * m23 * m34
            + m21 * m12 * m43 * m34 + m21 * m32 * m13 * m44 + m21 * m42 * m33 * m14
            + m31 * m12 * m23 * m44 + m31 * m22 * m43 * m14 + m31 * m42 * m13 * m24
            + m41 * m12 * m33 * m24 + m41 * m22 * m13 * m34 + m41 * m32 * m23 * m14
            - m11 * m22 * m43 * m34 - m11 * m32 * m23 * m44 - m11 * m42 * m33 * m24
            - m21 * m12 * m33 * m44 - m21 * m32 * m43 * m14 - m21 * m42 * m13 * m34
            - m31 * m12 * m43 * m24 - m31 * m22 * m13 * m44 - m31 * m42 * m23 * m14
            - m41 * m12 * m23 * m34 - m41 * m22 * m33 * m14 - m41 * m32 * m13 * m24
            ;
        }

        public double4x4 Inverse()
        {
            double oodet = 1.0 / Determinant();
            return new double4x4(
            (m22 * m33 * m44 + m32 * m43 * m24 + m42 * m23 * m34 - m22 * m43 * m34 - m32 * m23 * m44 - m42 * m33 * m24) * oodet,
            (m21 * m43 * m34 + m31 * m23 * m44 + m41 * m33 * m24 - m21 * m33 * m44 - m31 * m43 * m24 - m41 * m23 * m34) * oodet,
            (m21 * m32 * m44 + m31 * m42 * m24 + m41 * m22 * m34 - m21 * m42 * m34 - m31 * m22 * m44 - m41 * m32 * m24) * oodet,
            (m21 * m42 * m33 + m31 * m22 * m43 + m41 * m32 * m23 - m21 * m32 * m43 - m31 * m42 * m23 - m41 * m22 * m33) * oodet,
            (m12 * m43 * m34 + m32 * m13 * m44 + m42 * m33 * m14 - m12 * m33 * m44 - m32 * m43 * m14 - m42 * m13 * m34) * oodet,
            (m11 * m33 * m44 + m31 * m43 * m14 + m41 * m13 * m34 - m11 * m43 * m34 - m31 * m13 * m44 - m41 * m33 * m14) * oodet,
            (m11 * m42 * m34 + m31 * m12 * m44 + m41 * m32 * m14 - m11 * m32 * m44 - m31 * m42 * m14 - m41 * m12 * m34) * oodet,
            (m11 * m32 * m43 + m31 * m42 * m13 + m41 * m12 * m33 - m11 * m42 * m33 - m31 * m12 * m43 - m41 * m32 * m13) * oodet,
            (m12 * m23 * m44 + m22 * m43 * m14 + m42 * m13 * m24 - m12 * m43 * m24 - m22 * m13 * m44 - m42 * m23 * m14) * oodet,
            (m11 * m43 * m24 + m21 * m13 * m44 + m41 * m23 * m14 - m11 * m23 * m44 - m21 * m43 * m14 - m41 * m13 * m24) * oodet,
            (m11 * m22 * m44 + m21 * m42 * m14 + m41 * m12 * m24 - m11 * m42 * m24 - m21 * m12 * m44 - m41 * m22 * m14) * oodet,
            (m11 * m42 * m23 + m21 * m12 * m43 + m41 * m22 * m13 - m11 * m22 * m43 - m21 * m42 * m13 - m41 * m12 * m23) * oodet,
            (m12 * m33 * m24 + m22 * m13 * m34 + m32 * m23 * m14 - m12 * m23 * m34 - m22 * m33 * m14 - m32 * m13 * m24) * oodet,
            (m11 * m23 * m34 + m21 * m33 * m14 + m31 * m13 * m24 - m11 * m33 * m24 - m21 * m13 * m34 - m31 * m23 * m14) * oodet,
            (m11 * m32 * m24 + m21 * m12 * m34 + m31 * m22 * m14 - m11 * m22 * m34 - m21 * m32 * m14 - m31 * m12 * m24) * oodet,
            (m11 * m22 * m33 + m21 * m32 * m13 + m31 * m12 * m23 - m11 * m32 * m23 - m21 * m12 * m33 - m31 * m22 * m13) * oodet
            );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns></returns>
        public static double4x4 RotationX( double angle )
        {
            double c = Math.Cos( angle );
            double s = Math.Sin( angle );
            return new double4x4(
                1.0, 0.0, 0.0, 0.0,
                0.0, c, -s, 0.0,
                0.0, s, c, 0.0,
                0.0, 0.0, 0.0, 1.0
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns></returns>
        public static double4x4 RotationY( double angle )
        {
            double c = Math.Cos( angle );
            double s = Math.Sin( angle );
            return new double4x4(
                c, 0.0, s, 0.0,
                0.0, 1.0, 0.0, 0.0,
                -s, 0.0, c, 0.0,
                0.0, 0.0, 0.0, 1.0
                );
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="angle">Angle in radians</param>
        /// <returns></returns>
        public static double4x4 RotationZ( double angle)
        {
            double c = Math.Cos( angle );
            double s = Math.Sin( angle );
            return new double4x4(
                c, -s, 0.0, 0.0,
                s, c, 0.0, 0.0,
                0.0, 0.0, 1.0, 0.0,
                0.0, 0.0, 0.0, 1.0
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fovy">Angle in radians</param>
        /// <param name="aspect">Width divided by Height</param>
        /// <param name="zn"></param>
        /// <param name="zf"></param>
        /// <returns></returns>
        public static double4x4 PerspectiveFovLH( double fovy, double aspect, double zn, double zf )
        {
            double yScale = 1.0 / Math.Tan( fovy/ 2.0 );
            double xScale = yScale / aspect;
            double Q = zf / (zf - zn);
            return new double4x4(
                xScale, 0, 0, 0,
                0, yScale, 0, 0,
                0, 0, Q, 1.0,
                0, 0, -zn * Q, 0
                );
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fovy">Angle in radians</param>
        /// <param name="aspect">Width divided by Height</param>
        /// <param name="zn"></param>
        /// <param name="zf"></param>
        /// <returns></returns>
        public static double4x4 PerspectiveFovRH( double fovy, double aspect, double zn, double zf )
        {
            double yScale = 1.0 / Math.Tan( fovy / 2.0 );
            double xScale = yScale / aspect;
            return new double4x4(
                xScale, 0, 0, 0,
                0, yScale, 0, 0,
                0, 0, zf / (zn - zf), -1,
                0, 0, zn * zf / (zn - zf), 0
                );
        }

        public static double4x4 PerspectiveOffCenterLH( double l, double r, double b, double t, double zn, double zf )
        {
            return new double4x4(
                2.0 * zn / (r - l), 0, 0, 0,
                0, 2.0 * zn / (t - b), 0, 0,
                (l + r) / (l - r), (t + b) / (b - t), zf / (zf - zn), 1.0,
                0, 0, zn * zf / (zn - zf), 0
                );
        }

        public static double4x4 PerspectiveOffCenterRH( double l, double r, double b, double t, double zn, double zf )
        {
            return new double4x4(
                2.0 * zn / (r - l), 0, 0, 0,
                0, 2.0 * zn / (t - b), 0, 0,
                (l + r) / (r - l), (t + b) / (t - b), zf / (zn - zf), -1.0,
                0, 0, zn * zf / (zn - zf), 0
                );
        }

        public static double4x4 LookAtLH( double3 eye, double3 at, double3 up )
        {
            double3 zaxis = (at - eye).Normalized();
            double3 xaxis = double3.CrossProduct(up, zaxis).Normalized();
            double3 yaxis = double3.CrossProduct( zaxis, xaxis );
            return new double4x4(
                xaxis.x, xaxis.y, xaxis.z, -double3.DotProduct( xaxis, eye ),
                yaxis.x, yaxis.y, yaxis.z, -double3.DotProduct( yaxis, eye ),
                zaxis.x, zaxis.y, zaxis.z, -double3.DotProduct( zaxis, eye ),
                0, 0, 0, 1
                );
        }
        public static double4x4 LookAtRH( double3 eye, double3 at, double3 up )
        {
            throw new NotImplementedException();
#if false
            // must be transposed.
            double3 zaxis = (eye - at).Normalized();
            double3 xaxis = double3.CrossProduct( up, zaxis ).Normalized();
            double3 yaxis = double3.CrossProduct( zaxis, xaxis );
            return new double4x4(
                xaxis.x, yaxis.x, zaxis.x, 0,
                xaxis.y, yaxis.y, zaxis.y, 0,
                xaxis.z, yaxis.z, zaxis.z, 0,
                double3.DotProduct( xaxis, eye ), double3.DotProduct( yaxis, eye ), double3.DotProduct( zaxis, eye ), 1
                );
#endif
        }

        public static double4x4 FromYawPitchRoll( double yaw, double pitch, double roll )
        {
            double sin_r = Math.Sin( roll );
            double cos_r = Math.Cos( roll );
            double sin_y = Math.Sin( yaw );
            double cos_y = Math.Cos( yaw );
            double sin_p = Math.Sin( pitch );
            double cos_p = Math.Cos( pitch );

            return new double4x4(
                cos_y * cos_r,      -cos_p * sin_r + sin_p * sin_y * cos_r,    sin_p * sin_r + cos_p * sin_y * cos_r,      0,
                cos_y * sin_r,      cos_p * cos_r + sin_p * sin_y * sin_r,     -sin_p * cos_r + cos_p * sin_y * sin_r,     0,
                -sin_y,             sin_p * cos_y,                             cos_p * cos_y,                              0,
                0, 0, 0, 1
            );
        }

    }
}
