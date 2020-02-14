using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VectorMath
{
    // Quaternions are kind of like 4 dimensional complex numbers.
    // A 2-dimensional number is like a + bi where i * i = -1
    //
    // Recall, that for quaternions:
    //
    // i * i = -1
    // j * j = -1
    // k * k = -1
    // i * j * k = -1
    // ij = k
    // jk = i
    // j = j
    // ji = -k
    // kj = -i
    // ik = -j

    public struct Quaternion
    {
        // a + bi + cj + dk
        public double a, b, c, d;

        public Quaternion( double a, double b, double c, double d )
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public static Quaternion operator +( Quaternion A, Quaternion B )
        {
            return new Quaternion(
                A.a + B.a,
                A.b + B.b,
                A.c + B.c,
                A.d + B.d
                );
        }

        public static Quaternion operator *( Quaternion A, Quaternion B )
        {
            // Order is important!
            // (A.a + A.b*i + A.c*j + A.d*k) * (B.a + B.b*i + B.c*j + B.d*k)
            // A.a * [B.a + B.b*i + B.c*j + B.d*k]
            // A.b*i * [B.a + B.b*i + B.c*j + B.d*k]
            // A.c*j * [B.a + B.b*i + B.c*j + B.d*k]
            // A.d*k * [B.a + B.b*i + B.c*j + B.d*k]
            // 
            // [A.a*B.a + A.a*B.b*i + A.a*B.c*j + A.a*B.d*k]
            // [A.b*i*B.a + A.b*i*B.b*i + A.b*i*B.c*j + A.b*i*B.d*k]
            // [A.c*j*B.a + A.c*j*B.b*i + A.c*j*B.c*j + A.c*j*B.d*k]
            // [A.d*k*B.a + A.d*k*B.b*i + A.d*k*B.c*j + A.d*k*B.d*k]
            // 
            // [+ A.a*B.a + A.a*B.b*i + A.a*B.c*j + A.a*B.d*k]
            // [- A.b*B.b + A.b*B.a*i - A.b*B.d*j + A.b*B.c*k]
            // [- A.c*B.c + A.c*B.d*i + A.c*B.a*j - A.c*B.b*k]
            // [- A.d*B.d - A.d*B.c*i + A.d*B.b*j + A.d*B.a*k]

            return new Quaternion( 
                A.a*B.a - A.b*B.b - A.c*B.c - A.d*B.d,
                A.a*B.b + A.b*B.a + A.c*B.d - A.d*B.c,
                A.a*B.c - A.b*B.d + A.c*B.a + A.d*B.b,
                A.a*B.d + A.b*B.c - A.c*B.b + A.d*B.a
                );
        }

        public static Quaternion RotationAboutAxis( double3 axis, double angle_radians )
        {
            double half_angle = angle_radians / 2.0;
            double cos_half_angle = Math.Cos( half_angle );
            double sin_half_angle = Math.Sin( half_angle );
            return new Quaternion( 
                cos_half_angle,
                axis.x * sin_half_angle,
                axis.y * sin_half_angle,
                axis.z * sin_half_angle
                );
        }

        public double Magnitude2()
        {
            return a * a + b * b + c * c + d * d;
        }

        public double Magnitude()
        {
            return Math.Sqrt( Magnitude2() );
        }

        public static Quaternion operator *( Quaternion Q, double v )
        {
            return new Quaternion( Q.a * v, Q.b * v, Q.c * v, Q.d * v );
        }

        public double4x4 ToMatrix()
        {
            Quaternion Q = this * (1.0 / Magnitude());
            
            return new double4x4(
                1.0 - 2.0 * (Q.c * Q.c + Q.d * Q.d),
                2.0 * (Q.b * Q.c - Q.a * Q.d),
                2.0 * (Q.b * Q.d + Q.a * Q.c),
                0,

                2.0 * (Q.b * Q.c + Q.a * Q.d),
                1.0 - 2.0 * (Q.b * Q.b + Q.d * Q.d),
                2.0 * (Q.c * Q.d - Q.a * Q.b),
                0,

                2.0 * (Q.b * Q.d - Q.a * Q.c),
                2.0 * (Q.c * Q.d + Q.a * Q.b),
                1.0 - 2.0 * (Q.b * Q.b + Q.c * Q.c),
                0,

                0, 0, 0, 1
                );
        }
    }
}
