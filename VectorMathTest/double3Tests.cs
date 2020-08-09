using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTest
{
    [TestClass]
    public class double3Tests
    {
        [TestMethod]
        public void Addition()
        {
            Assert.AreEqual( new double3( 10, 20, 30 ), new double3( 2, 4, 6 ) + new double3( 8, 16, 24 ) );
        }

        [TestMethod]
        public void Subtraction()
        {
            Assert.AreEqual( new double3( -6, -12, 3 ), new double3( 2, 4, 8 ) - new double3( 8, 16, 5 ) );
        }

        [TestMethod]
        public void ScalarMultiplication()
        {
            Assert.AreEqual( new double3( 10, 15, 35 ), new double3( 2, 3, 7 ) * 5 );
        }

        [TestMethod]
        public void VectorMultiplication()
        {
            Assert.AreEqual( new double3( 45, 77, 195 ), new double3( 9, 11, 15 ) * new double3( 5, 7, 13 ) );
        }

        [TestMethod]
        public void Division()
        {
            Assert.AreEqual( new double3( 3, 5, 7 ), new double3( 6, 10, 14 ) / 2 );
            Assert.AreEqual( new double3( 8, 16, 5 ), new double3( 16, 64, 30 ) / new double3( 2, 4, 6 ) );
        }

        [TestMethod]
        public void AsString()
        {
            Assert.AreEqual( "(1, 2, 3)", new double3( 1, 2, 3 ).ToString() );
        }

        [TestMethod]
        public void DotProduct()
        {
            Assert.AreEqual( 86, double3.DotProduct( new double3( 2, 3, 5 ), new double3( 5, 7, 11 ) ) );
        }

        [TestMethod]
        public void CrossProduct()
        {
            // Axial tests
            Assert.AreEqual( new double3(0,0,1), double3.CrossProduct( new double3(1,0,0), new double3(0,1,0) ) );
        }

        [TestMethod]
        public void Magnitude2()
        {
            Assert.AreEqual( 50, new double3( 3, -4, 5 ).Magnitude2() );
        }

        [TestMethod]
        public void Magnitude()
        {
            Assert.AreEqual( 7, new double3( 2, -3, 6 ).Magnitude() );
        }

        [TestMethod]
        public void Double3Constructor()
        {
            Assert.AreEqual( new double3( 31, 33, 35 ), new double3( new double3( 31, 33, 35 ) ) );
        }

        [TestMethod]
        public void UnaryNegation()
        {
            // Sanity check
            double t = 0;
            Assert.AreEqual( t, -t );

            Assert.AreEqual( double3.Zero, -double3.Zero );
            Assert.AreEqual( new double3( -1, -1, -1 ), -double3.One );
            Assert.AreEqual( new double3( -4, 3, -2 ), -new double3( 4, -3, 2 ) );
        }

        [TestMethod]
        public void UnaryPlus()
        {
            // Sanity check
            double t = 0;
            Assert.AreEqual( t, +t );

            Assert.AreEqual( double3.Zero, +double3.Zero );
            Assert.AreEqual( new double3( 1, 1, 1 ), +double3.One );
            Assert.AreEqual( new double3( 4, -3, 2 ), +new double3( 4, -3, 2 ) );
        }

        [TestMethod]
        public void Det3Minimal()
        {
            // Not really comprehensive
            Assert.AreEqual( 1, double3.Det3( new double3( 1, 0, 0 ), new double3( 0, 1, 0 ), new double3( 0, 0, 1 ) ) );
        }
    }
}
