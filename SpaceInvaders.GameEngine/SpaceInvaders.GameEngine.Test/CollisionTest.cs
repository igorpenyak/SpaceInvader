using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine;
using SpaceInvaders.GameEngine.Objects;

namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class CollisionTest
    {
        Bullet b1 = new Bullet(2,3,true);
        Bullet b2 = new Bullet(3,5,false);

        
        
        [TestMethod]
        public void findDistanceTest()
        {            
            double d = Collision.findDistance(b1, b2);
            Assert.AreEqual(2.0, d);
        }

         
        //[TestMethod]
        //public void findColisionSimpleTest()
        //{
        //    Bullet b3 = new Bullet(5,9,false);
        //    Process p = new Process();
        //    LazerGun l = new LazerGun(5,9);
        //    Invader inv = new Invader(5,9,10,2);
        //    p.m_GameObjects.Insert(1, l);

        //    p.i_arr[1, 1] = inv;
        //    p.i_arr[1, 1].enem_bullet.Add(b3);          
        //    Collision.FindCollision(p);
        //    Assert.AreEqual(2,p.m_GameObjects[1].NumberOfLives);
        //}
    
    }
}
