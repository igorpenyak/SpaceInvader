using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine.Objects;

namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class LazerGunTest
    {

        [TestMethod]
        public void ConstructorTest()
        {
            LazerGun l = new LazerGun(2, 5);
            Assert.AreEqual(2,l.PosX);
        }

        [TestMethod]
        public void GetNameTest()
        {
            LazerGun l = new LazerGun(2, 5);
            Assert.AreEqual(2, l.PosX);
        }

        [TestMethod]
        public void UpdateTest()
        {
            LazerGun l = new LazerGun(5, 2);
            l.Update(KeyPress.Right,10);
            Assert.AreEqual(6, l.PosX);
            l.Update(KeyPress.Left,10);
            Assert.AreEqual(5,l.PosX);
        }

        [TestMethod]
        public void isDieTest()
        {
            LazerGun l = new LazerGun(2, 5);
            while (l.NumberOfLives != 0)
            { l.isDie(); }
            Assert.AreEqual(0, l.NumberOfLives);
        }
    }
}
