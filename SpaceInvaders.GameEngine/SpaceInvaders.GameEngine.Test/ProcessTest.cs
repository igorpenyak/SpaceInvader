using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine.Logic;
using SpaceInvaders.GameEngine.Objects;

namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class ProcessTest
    {
        

        [TestMethod]
        public void ConstructorTest()
        {
            IDistanceStrategy d = new DistanceStrategy();
            Process p = new Process(d);
            Assert.IsFalse(p.IsExit);
        }

        //[TestMethod]
        //public void InitTest()
        //{
        //    IDistanceStrategy d = new DistanceStrategy();
        //    Process p = new Process(d);
        //    p.Init(60,50,5,7);
        //    Assert.IsTrue(p.m_GameObjects.Count!=0);
        //}

        [TestMethod]
        public void UpdScoreTest()
        {
            IDistanceStrategy d = new DistanceStrategy();
            Process p = new Process(d);
            p.UpdScore(20);
            Assert.AreEqual(20, p.GetScore);
        }

        //[TestMethod]
        //public void UpdateTest()
        //{
        //    IDistanceStrategy d = new DistanceStrategy();
        //    Process p = new Process(d);
        //    p.Init(60,50,5,7);
        //    p.Update(5);
        //    Assert.IsTrue(p.b_list.Count!=0);
        //}

        //[TestMethod]
        //public void UpdateAnotherTest()
        //{
        //    IDistanceStrategy d = new DistanceStrategy();
        //    Process p = new Process(d); 
        //    p.Init(60, 50, 5, 7);
        //    p.Update(1);
        //    Assert.IsTrue(p.b_list.Count == 0);      
        //}

        [TestMethod]
        public void TryLevelTest()
        {
            
            IDistanceStrategy d = new DistanceStrategy();
            Process p = new Process(d);

            PrivateObject privateobj=new PrivateObject(p);
            
            p.Init(60, 50, 5, 7);

            Invader[,] inv = (Invader[,])privateobj.GetField("i_arr");
            for (var c = 0; c < 6; c++)
            {
                for (var i = 0; i < inv.GetLength(0); i++)
                {
                    for (var j = 0; j < inv.GetLength(1); j++)
                    {
                        inv[i, j].Live = false;
                    }
                }
                p.TryChangeLevel();
                if (c == 0)
                {
                    Assert.AreEqual(35, inv[1, 1].Speed);
                }
                else if (c == 1)
                {
                    Assert.AreEqual(25, inv[1, 1].Speed);
                }
                else if (c == 2)
                {
                    Assert.AreEqual(20, inv[1, 1].Speed);
                }
                else if (c == 3)
                {
                    Assert.AreEqual(10, inv[1, 1].Speed);
                }
                else if (c == 4)
                {
                    Assert.AreEqual(5, inv[1, 1].Speed);
                }
                else
                {
                    Assert.IsTrue(p.Win);
                }
            }
        }

        [TestMethod]
        public void TryExitTest()
        {
            IDistanceStrategy d = new DistanceStrategy();
            Process p = new Process(d);
            PrivateObject privateobj = new PrivateObject(p);
            
            p.Init(60, 50, 5, 7);


            Invader[,] inv = (Invader[,])privateobj.GetField("i_arr");
            LazerGun gun = (LazerGun)privateobj.GetField("_gun");
            for (var c = 0; c < 6; c++)
            {
                for (var i = 0; i < inv.GetLength(0); i++)
                {
                    for (var j = 0; j < inv.GetLength(1); j++)
                    {
                        inv[i, j].Live = false;
                    }
                }
                if (c <= 4)
                {
                    p.TryChangeLevel();
                }
                else
                {
                    gun.Live = false;
                    p.TryExitGame();
                    Assert.IsTrue(p.IsExit);
                }
            }
        }

          [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
          public void CreateEnemyTest()
          {
              IDistanceStrategy d=new DistanceStrategy();
              Process p = new Process(d);
              p.CreateEnemyArray(-2, -2);              
          }

          [TestMethod]
          [ExpectedException(typeof(InvalidOperationException))]
          public void InitExceptionTest()
          {
              IDistanceStrategy d = new DistanceStrategy();
              Process p = new Process(d);
              p.Init(-2, -2, 0, 2);
          }

          [TestMethod]
          
          public void RenderTest()
          {
               bool methodCalled = false;
               int methodCall = 0;
               IDistanceStrategy d = new DistanceStrategy();
               Process p = new Process(d);
              p.Init(60, 50, 5, 5);          
              p.Update(5);
              p.Draw+=delegate{ methodCalled = true;};
              p.Show += delegate { methodCall = 1; };
              p.Render();       
                    
           Assert.IsTrue(methodCalled);
          }

         [TestMethod]
          public void RenderTest_2()
          {
              bool methodCalled = false;
              int methodCall = 0;
              IDistanceStrategy d = new DistanceStrategy();
              Process p = new Process(d);
              p.Init(60, 50, 5, 5);             
              p.Update(5);
              p.Draw += delegate { methodCalled = true; };
              p.Show += delegate { methodCall = 1; };
              p.Render();

              Assert.AreEqual(1,methodCall);
          }

         [TestMethod]
         public void RenderTest_3()
         {
             bool methodCalled = false;
             int methodCall = 0;
             IDistanceStrategy d = new DistanceStrategy();
             Process p = new Process(d);
             PrivateObject privateobj = new PrivateObject(p);

             p.Init(30, 24, 3, 3);
             Invader[,] inv = (Invader[,])privateobj.GetField("i_arr");

             while (!inv[0, 1].firstShot())
             {
                 p.Update(0);
                 inv[0, 1].Update(208);
                 
             }
             p.Draw += delegate { methodCalled = true; };
             p.Show += delegate { methodCall = 1; };
             p.Render();

             Assert.AreEqual(1, methodCall);
         }

         [TestMethod]
         public void InvaderWin_Test()
         {
             LazerGun gun = new LazerGun(5,5);
             Invader invader = new Invader(5,6,20,9);
             IDistanceStrategy d = new DistanceStrategy();
             Process p = new Process(d);
             bool a=p.InvaderWin(gun,invader);
             Assert.AreEqual(true, a);                         
         }

         [TestMethod]
         public void CollisionInvader_Test()
         {
             LazerGun gun = new LazerGun(5, 5);
             Invader[,] invaders = new Invader[1,2];
             Invader invader = new Invader(5, 6, 20, 9);
             invaders[0, 0] = invader;
             invaders[0, 1] = new Invader(5, 6, 10, 7);
                

             IDistanceStrategy d = new DistanceStrategy();
             Process p = new Process(d);

             p.CollisionInvader(invaders,0,1,gun);             
             Assert.IsFalse(gun.Live);
         }

         [TestMethod]
         public void CollisionInvader_Test1()
         {
             LazerGun gun = new LazerGun(5, 15);
             Invader[,] invaders = new Invader[1, 2];
      
             invaders[0, 1] = new Invader(5, 5, 15, 9);
             invaders[0, 1].Speed = 40;

             IDistanceStrategy d = new DistanceStrategy();
             Process p = new Process(d);
             while (invaders[0,1].CanShot ==0) 
             {
                 invaders[0, 1].Update(208);                 

             }
             while (!p.isCollision(invaders[0, 1].EnemyBullet, gun))
             {
                 invaders[0, 1].Update(516);              
             }

             p.CollisionInvader(invaders, 0, 1, gun);
             
             Assert.AreEqual(2,gun.NumberOfLives);
         }

         [TestMethod]
         public void CollisionLazerGun_Test1()
         {
             IDistanceStrategy d = new DistanceStrategy();
             Process p = new Process(d);
             int a;
             p.Init(60, 50, 5, 5);

             while (p.GetScore<=220)
             {
                 a = 0;

                 while (a!=3)
                 {
                     p.Update(5);
                     
                     a++;
                 }
                 p.Update(5);
                 p.Update(1);
             }        

             Assert.IsTrue(p.GetScore>=220);
         }
    }
}
