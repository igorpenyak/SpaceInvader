using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine.Objects;

namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class LazerGunTest
    {
        LazerGun l = new LazerGun(2,5);

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.AreEqual(2,l.PosX);
        }

        [TestMethod]
        public void GetNameTest()
        {
            Assert.AreEqual(l.Name, LazerGun.GetName());
        }

        [TestMethod]
        public void UpdateTest()
        {
            l.Update(1);
            Assert.AreEqual(3, l.PosX);
            l.Update(-1);
            Assert.AreEqual(2,l.PosX);
        }

        [TestMethod]
        public void isDieTest()
        {
            while (l.NumberOfLives != 0)
            { l.isDie(); }
            Assert.AreEqual(0, l.NumberOfLives);
        }
    }
}
