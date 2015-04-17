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

        [TestMethod]
        public void InvaderWineTest()
        {
            Invader inv = new Invader(5, 5, 2, 5);
            LazerGun l = new LazerGun(5, 5);
            bool t = Collision.InvaderWin(inv, l);
            Assert.IsTrue(t);
        }

        [TestMethod]
        public void CollisionInvaderTest_1()
        {
          
            Process p = new Process();
    
            p.Init(60, 24, 5, 3);
            while (Collision.InvaderWin(p.m_GameObjects[1],p.i_arr[1,1]))
            {               
                p.Update(0);               
            }
            
            Assert.IsTrue(!p.m_GameObjects[1].Live);          
        }      

        [TestMethod]
        public void findCollisionTest()
        {
            int a=1;
            int b=5;
            int count = 0;
            
            
            Process p = new Process();

            p.Init(40, 50, 5, 5);
            while (p.sc.score<220)
            {
                if (a == b)
                {
                    p.Update(a);
                    b = 5;
                }
                else
                {
                    while (count < 4)
                    {
                        p.Update(b);
                        count++;
                    }
                    count = 0;
                    b = a;
                }
            }

            Assert.IsTrue(p.sc.score!=0);

        }
    
    }
}
