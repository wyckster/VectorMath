using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTest
{
    [TestClass]
    public class double4x4Tests
    {
        [TestMethod]
        public void MatrixToString()
        {
            double4x4 m = new double4x4( 
                1, 2, 3, 4, 
                5, 6, 7, 8,
                9, 1, 3, 5,
                7, 2, 4, 6 );
            Assert.AreEqual(
                "|     1      2      3      4|\n|     5      6      7      8|\n|     9      1      3      5|\n|     7      2      4      6|", m.ToString() );
        }

        [TestMethod]
        public void InverseIdentityTest()
        {
            double4x4 M = double4x4.Identity;
            double4x4 MI = M.Inverse();
            Assert.AreEqual( double4x4.Identity, MI );
        }

        [TestMethod]
        public void InverseSimpleTest()
        {
            double4x4 M = new double4x4(
                0, 0, 1, 0,
                0, 1, 0, 0,
                0, 0, 0, 1,
                1, 0, 0, 0
                );
            double4x4 MI = M.Inverse();
            Assert.AreEqual( double4x4.Identity, M * MI );
            Assert.AreEqual( double4x4.Identity, MI * M );
        }

        [TestMethod]
        public void InverseBiggerTest()
        {
            double4x4 M = new double4x4(
                2, 3, 4, 5,
                2, 5, 9, 15,
                3, 5, 7, 10,
                4, 8, 13, 21
                );
            double4x4 MI = M.Inverse();
            Assert.AreEqual( double4x4.Identity, M * MI );
            Assert.AreEqual( double4x4.Identity, MI * M );
        }
    }
}
