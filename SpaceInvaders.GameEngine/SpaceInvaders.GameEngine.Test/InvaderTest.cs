using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine.Objects;
using System.Collections.Generic;

namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class InvaderTest
    {
        [TestMethod]
        public void ConstructorTest()
        {
            Invader inv = new Invader(2, 3, 20, 9);
            Assert.AreEqual(2,inv.PosX);
        }

        [TestMethod]
        public void MoveTest()
        {
            Invader inv = new Invader(2, 3, 20, 9);
            inv.Move();
            Assert.AreEqual(4, inv.PosY);

        }

        [TestMethod]
        public void ShotTest()
        {
            Invader inv = new Invader(2, 3, 20, 9);
            Assert.IsFalse(inv.Shot(10));
            Assert.IsFalse(!inv.Shot(208));
        }


        [TestMethod]
        public void UpdateTest()
        {
          
            Invader inv = new Invader(2, 3, 20, 9);
       
            inv.Speed = 1;
            inv.Update(10000);
            Assert.IsTrue(inv.CanShot==0);
        }

        [TestMethod]
        public void firstShotTest()
        {
            Invader inv = new Invader(2, 3, 20, 9);
            Assert.IsFalse(inv.IsFirstShot());
        }

         [TestMethod]
       public void UpdateTrueTest()
        {
            Invader inv = new Invader(2, 3, 20, 9);
            inv.Speed = 1;
            inv.Update(208);
            inv.Update(208);
            Assert.IsTrue(inv.CanShot != 0);              
         } 

         [TestMethod]
         public void FirstShotTrueTest()
         {
             Invader inv = new Invader(2, 3, 20, 9);
             PrivateObject privateObj = new PrivateObject(inv);
             Bullet b = new Bullet(1,2,false);
             List<Bullet> bullet_list = (List<Bullet>)privateObj.GetField("_enemyBullet");
                 inv.Speed = 1;
             bullet_list.Add(b);
             Assert.IsTrue(inv.IsFirstShot());
         }


         [TestMethod]
         public void canShotTrueTest()
         {
             Invader inv = new Invader(2, 3, 20, 9);
             inv.Speed = 1;

             for (var i = 0; i <= 9; i++)
             {

                 if (i == 3)
                 {
                     inv.K = 4;
                     inv.Update(416);                     
                     Assert.IsTrue(inv.CanShot != 0);
                 }
                 else if(i==5)
                 {
                     inv.K = 7;
                     inv.Update(416);                   
                     Assert.IsTrue(inv.CanShot != 0);
                 }
                 else if (i == 8)
                 {
                     inv.K = 2;
                     inv.Update(416);                     
                     Assert.IsTrue(inv.CanShot != 0);
                 }
                 else 
                 {
                     inv.Update(208);
                 }

             }
         }

         [TestMethod]
         public void GetBulletTest()
         {
             Invader inv = new Invader(2, 3, 20, 9);
             Bullet b = new Bullet(inv.PosX, inv.PosY, false);

             PrivateObject privateObj = new PrivateObject(inv);
             List<Bullet> bullet_list = (List<Bullet>)privateObj.GetField("_enemyBullet");

             inv.Speed = 1;            
             bullet_list.Add(b);
             Bullet c = inv.GetEnemyBullet();

             Assert.AreEqual(2,c.PosX );           
         }
         [TestMethod]
         public void GetEnemy_BulletTest()
         {
             Invader inv = new Invader(2, 3, 20, 9);
             
             inv.Speed = 1;
             inv.Update(208);
             Bullet b = inv.EnemyBullet;          

             Assert.AreEqual(b.PosX, inv.PosX);
         }
    }
}
