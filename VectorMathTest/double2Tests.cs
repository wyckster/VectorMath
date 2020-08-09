using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTest
{
    [TestClass]
    public class double2Tests
    {
        [TestMethod]
        public void Addition()
        {
            Assert.AreEqual( new double2( 10, 20 ), new double2( 2, 4 ) + new double2( 8, 16 ) );
        }

        [TestMethod]
        public void Subtraction()
        {
            Assert.AreEqual( new double2( -6, -12 ), new double2( 2, 4 ) - new double2( 8, 16 ) );
        }

        [TestMethod]
        public void ScalarMultiplication()
        {
            Assert.AreEqual( new double2( 10, 15 ), new double2( 2, 3 ) * 5 );
        }

        [TestMethod]
        public void VectorMultiplication()
        {
            Assert.AreEqual( new double2( 45, 77 ), new double2( 9, 11 ) * new double2( 5, 7 ) );
        }

        [TestMethod]
        public void Division()
        {
            Assert.AreEqual( new double2( 3, 5 ), new double2( 6, 10 ) / 2 );
            Assert.AreEqual( new double2( 8, 16 ), new double2( 16, 64 ) / new double2( 2, 4 ) );
        }

        [TestMethod]
        public void AsString()
        {
            Assert.AreEqual( "(1, 2)", new double2( 1, 2 ).ToString() );
        }

        [TestMethod]
        public void DotProduct()
        {
            Assert.AreEqual( 31, double2.DotProduct( new double2( 2, 3 ), new double2( 5, 7 ) ) );
        }

        [TestMethod]
        public void CrossProduct()
        {
            Assert.AreEqual( -1, double2.CrossProduct( new double2( 2, 3 ), new double2( 5, 7 ) ) );
        }

        [TestMethod]
        public void Magnitude2()
        {
            Assert.AreEqual( 25, new double2( 3, -4 ).Magnitude2() );
        }

        [TestMethod]
        public void Magnitude()
        {
            Assert.AreEqual( 5, new double2( 3, -4 ).Magnitude() );
        }

        [TestMethod]
        public void Double2Constructor()
        {
            Assert.AreEqual( new double2( 31, 33 ), new double2( new double2( 31, 33 ) ) );
        }

        [TestMethod]
        public void UnaryNegation()
        {
            // Sanity check
            double t = 0;
            Assert.AreEqual( t, -t );

            Assert.AreEqual( double2.Zero, -double2.Zero );
            Assert.AreEqual( new double2( -1, -1 ), -double2.One );
            Assert.AreEqual( new double2( 3, -2 ), -new double2( -3, 2 ) );
        }

        [TestMethod]
        public void UnaryPlus()
        {
            // Sanity check
            double t = 0;
            Assert.AreEqual( t, +t );

            Assert.AreEqual( double2.Zero, +double2.Zero );
            Assert.AreEqual( new double2( 1, 1 ), +double2.One );
            Assert.AreEqual( new double2( -3, 2 ), +new double2( -3, 2 ) );
        }
    }
}
