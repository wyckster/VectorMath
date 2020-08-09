using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTest
{
    [TestClass]
    public class double3x2Tests
    {
        [TestMethod]
        public void MatrixToString()
        {
            double3x2 i = new double3x2( 1, 0, 0, 0, 1, 0 );
            Assert.AreEqual( "|     1      0      0|\n|     0      1      0|", i.ToString() );
        }

        [TestMethod]
        public void MatrixMultiply()
        {
            // Identity * Identity == Identity
            Assert.AreEqual( double3x2.Identity, double3x2.Identity * double3x2.Identity );

            double3x2 A, B;
            double3x2 AB;
            AB = new double3x2(
                2 * 17 + 3 * 27,
                2 * 19 + 3 * 29,
                2 * 23 + 3 * 31 + 5,
                7 * 17 + 11 * 27,
                7 * 19 + 11 * 29,
                7 * 23 + 11 * 31 + 13
                );
            A = new double3x2(
                    2, 3, 5,
                    7, 11, 13 );
            B = new double3x2(
                17, 19, 23,
                27, 29, 31 );

            // Matrix of primes helps to fingerprint arithmetic errors.
            Assert.AreEqual( AB, A * B );
            Assert.AreEqual( AB, B.Then( A ) );

            // Rotate 1/4 turn CCW then rorate 1/4 CW == Identity
            Assert.AreEqual(
                double3x2.Identity,
                new double3x2( 0, 1, 0, -1, 0, 0 )
                *
                new double3x2( 0, -1, 0, 1, 0, 0 )
                );
        }

        [TestMethod]
        public void ScalarMultiplication()
        {
            Assert.AreEqual( new double3x2( 6, 9, 15, 21, 33, 39 ), new double3x2( 2, 3, 5, 7, 11, 13 ) * 3.0 );
        }

        [TestMethod]
        public void VectorMultiplication()
        {
            double2 V = new double2( 17, 19 );
            // Identity matrix gives no change
            Assert.AreEqual( V, double3x2.Identity * V );

            // Primes help to fingerprint arithmetic errors.
            Assert.AreEqual(
                new double2( 2 * 17 + 3 * 19 + 5, 7 * 17 + 11 * 19 + 13 ),
                new double3x2( 2, 3, 5, 7, 11, 13 ) * V
                );
        }

        [TestMethod]
        public void Translation()
        {
            Assert.AreEqual(
                new double3x2(
                    1, 0, 17,
                    0, 1, 19
                    ),
                double3x2.Translation( new double2( 17, 19 ) ) );
            Assert.AreEqual(
                double3x2.Translation( new double2( 3, 4 ) ),
                double3x2.Translation( 3, 4 )
                );
        }

        [TestMethod]
        public void Scale()
        {
            Assert.AreEqual(
                new double3x2(
                    17, 0, 0,
                    0, 19, 0
                    ),
                double3x2.Scale( new double2( 17, 19 ) ) );
            Assert.AreEqual(
                double3x2.Scale( new double2( 3.0, 3.0 ) ),
                double3x2.Scale( 3.0 )
                );
        }

        [TestMethod]
        public void InverseIdentity()
        {
            double3x2 M = new double3x2( 1, 0, 0, 0, 1, 0 );
            double3x2 MI = M.Inverse();
            Assert.AreEqual( double3x2.Identity, MI );
            Assert.AreEqual( double3x2.Identity, M * MI );
            Assert.AreEqual( double3x2.Identity, MI * M );
        }

        [TestMethod]
        public void InverseCase1()
        {
            double3x2 M = new double3x2( 2, 0, 0, 0, 2, 0 );
            double3x2 MI = M.Inverse();
            Assert.AreEqual( double3x2.Identity, M * MI );
            Assert.AreEqual( double3x2.Identity, MI * M );
        }

        [TestMethod]
        public void InverseCase2()
        {
            double3x2 M = new double3x2( 0, 2, 0, 2, 0, 0 );
            double3x2 MI = M.Inverse();
            Assert.AreEqual( double3x2.Identity, M * MI );
            Assert.AreEqual( double3x2.Identity, MI * M );
        }

        [TestMethod]
        public void InverseBig()
        {
            double3x2 M = new double3x2( 1, 2, 3, 4, 5, 6 );
            double3x2 MI = M.Inverse();
            Assert.AreEqual( double3x2.Identity, M * MI );
            Assert.AreEqual( double3x2.Identity, MI * M );
        }
    
    }
}
