using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorMath;

namespace VectorMathTest
{
    [TestClass]
    public class RationalTests
    {
        [TestMethod]
        public void EqualityTest()
        {
            Assert.IsTrue( new Rational( 0, 1 ) == new Rational( 0, 2 ) );
        }

        [TestMethod]
        public void LessThan()
        {
            Rational a = new Rational( 2, 1 );
            Rational b = new Rational( 5, 1 );
            Assert.IsTrue( a <= b );
        }

    }
}
