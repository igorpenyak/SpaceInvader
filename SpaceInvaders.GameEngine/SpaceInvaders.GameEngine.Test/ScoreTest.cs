using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine.Objects;


namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class ScoreTest
    {               
        [TestMethod]
        public void ConstructorTest()
        {
            Score sc = new Score();
            Assert.AreEqual(0, sc.score);
        }

        [TestMethod]
        public void AddScoreTest()
        {
            Score sc = new Score();
            sc.AddScore(50);
            Assert.AreEqual(50, sc.score);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void AddScoreTest2()
        {
            Score sc = new Score();
            sc.AddScore(-50);          
        }
    }
}
