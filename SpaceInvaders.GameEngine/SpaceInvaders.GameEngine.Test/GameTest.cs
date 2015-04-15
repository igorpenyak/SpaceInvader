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

        [TestMethod]
        public void RenderTest()
        {
            Game g = new Game(10, 10);
            g.Render(g.Name,g.PosX,g.PosY);
            Assert.AreEqual(1,g.Test);
        }

        [TestMethod]
        public void UpdateTest()
        {
            Game g = new Game(10, 10);
            g.Update(5);
            Assert.AreEqual(5, g.Test);
        }

        [TestMethod]
        public void ShowTest()
        {
            Game g = new Game(10, 10);
            g.Show(g.Name, g.PosX);
            Assert.AreEqual(3, g.Test);
        }



    }
}
