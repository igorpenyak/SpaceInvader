using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Game g = new Game(10,10);
            Assert.AreEqual("Field", g.Name);
        }

        [TestMethod]
        public void isDieTest()
        {
            Game g = new Game(10, 10);
            g.isDie();
            Assert.IsTrue(g.Live);
        }
              

    }
}
