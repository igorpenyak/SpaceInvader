using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine.Objects;
using SpaceInvaders.GameEngine.Objects.Interfaces;


namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class ScoreTest
    {
        
        Score sc = new Score();
        
        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(0, sc.score);
        }

        [TestMethod]
        public void AddScoreTest()
        {
            sc.AddScore(50);
            Assert.AreEqual(50, sc.score);
        }


        //[TestMethod]
        //public void ShowTest()
        //{
        //    sc.Show(sc.name,70);

        //    Assert.AreEqual(70, sc.score);
        //}
    }
}
