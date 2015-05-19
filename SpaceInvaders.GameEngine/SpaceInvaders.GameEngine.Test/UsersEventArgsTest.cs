using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine.Logic.EventArguments;
using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class UsersEventArgsTest
    {
        [TestMethod]
        public void ConstructorGameObjectTest()
        {
            LazerGun l=new LazerGun(10,10,1);
            GameObjectEventArgs arg=new GameObjectEventArgs(l);
            Assert.AreEqual(l.PosX, arg.Gameobj.PosX);           
        }

        [TestMethod]
        public void ConstructorScoreTest()
        {
            Score s = new Score();
            ScoreEventArgs scoreArg = new ScoreEventArgs(s);
            Assert.AreEqual(0, s.score);
        }


    }
}
