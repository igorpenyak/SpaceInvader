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
            GameCommand p = new GameCommand(d, 1, 1, 1);
            Assert.IsFalse(p.IsExit);
        }
                
        [TestMethod]
        public void UpdScoreTest()
        {
            IDistanceStrategy d = new DistanceStrategy();
            GameCommand p = new GameCommand(d, 1, 1, 1);
            p.UpdScore(20);
            Assert.AreEqual(20, p.Score);
        }              

        [TestMethod]
        public void TryLevelTest()
        {
            
            IDistanceStrategy d = new DistanceStrategy();
            GameCommand p = new GameCommand(d, 1, 1, 1);

            PrivateObject privateobj=new PrivateObject(p);
            
            p.Init(60, 50, 5, 7);

            Invader[,] inv = (Invader[,])privateobj.GetField("_invadersArray");
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
            GameCommand p = new GameCommand(d,1,1,1);
            PrivateObject privateobj = new PrivateObject(p);
            
            p.Init(60, 50, 5, 7);


            Invader[,] inv = (Invader[,])privateobj.GetField("_invadersArray");
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
              GameCommand p = new GameCommand(d, 1, 1, 1);
              p.CreateEnemyArray(-2, -2);              
          }

          [TestMethod]
          [ExpectedException(typeof(InvalidOperationException))]
          public void InitExceptionTest()
          {
              IDistanceStrategy d = new DistanceStrategy();
              GameCommand p = new GameCommand(d, 1, 1, 1);
              p.Init(-2, -2, 0, 2);
          }

          [TestMethod]
          
          public void RenderTest()
          {
               bool methodCalled = false;
               int methodCall = 0;
               IDistanceStrategy d = new DistanceStrategy();
               GameCommand p = new GameCommand(d, 1, 1, 1);
              p.Init(60, 50, 5, 5);
              p.Update(ChooseKey.Shot);
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
              GameCommand p = new GameCommand(d, 1, 1, 1);
              p.Init(60, 50, 5, 5);
              p.Update(ChooseKey.Shot);
              p.Draw += delegate { methodCalled = true; };
              p.Show += delegate { methodCall = 1; };
              p.Render();

              Assert.AreEqual(1,methodCall);
          }

         [TestMethod]
         public void RenderTest_3()
         {             
             int methodCall = 0;
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             PrivateObject privateobj = new PrivateObject(p);

             p.Init(30, 24, 3, 3);
             Invader[,] inv = (Invader[,])privateobj.GetField("_invadersArray");

             while (!inv[0, 1].IsFirstShot())
             {
                 p.Update(0);
                 inv[0, 1].Update(208);                 
             }
             
             p.Show += delegate { methodCall = 1; };
             p.Render();

             Assert.AreEqual(1, methodCall);
         }

         [TestMethod]
         public void InputTest()
         {
             bool methodCalled = false;
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             p.Init(60, 50, 5, 5);

             p.InputKey += delegate { methodCalled = true; return ChooseKey.Shot; };
             p.Update(p.OnInputKey());
            
             Assert.IsTrue(methodCalled);
         }

         [TestMethod]
         public void InputTest2()
         {
             bool methodCalled = false;
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             p.Init(60, 50, 5, 5);               
             Assert.AreEqual(ChooseKey.Wait,p.OnInputKey());
         }


         [TestMethod]

         public void ClearTest()
         {
             
             int methodCall = 0;
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d,1,1,1);
             p.Init(60, 50, 5, 5);

             p.Clear += delegate { methodCall = 1; };
             p.Render();

             Assert.AreEqual(1,methodCall);
         }


         [TestMethod]
         public void InvaderWin_Test()
         {
             LazerGun gun = new LazerGun(5,5,1);
             Invader invader = new Invader(5,6,20,9,1);
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             bool a=p.InvaderWin(gun,invader);
             Assert.AreEqual(true, a);                         
         }

         [TestMethod]
         public void CollisionInvader_Test()
         {
             LazerGun gun = new LazerGun(5, 5, 1);
             Invader[,] invaders = new Invader[1,2];
             Invader invader = new Invader(5, 6, 20, 9, 1);
             invaders[0, 0] = invader;
             invaders[0, 1] = new Invader(5, 6, 10, 7, 1);
                

             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);

             p.CollisionInvader(invaders,0,1,gun);             
             Assert.IsFalse(gun.Live);
         }

         [TestMethod]
         public void CollisionInvader_Test1()
         {
             LazerGun gun = new LazerGun(5, 15, 1);
             Invader[,] invaders = new Invader[1, 2];
      
             invaders[0, 1] = new Invader(5, 5, 15, 9, 1);
             invaders[0, 1].Speed = 40;

             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             while (invaders[0,1].CanShot ==0) 
             {
                 invaders[0, 1].Update(208);                  

             }
             while (!p.IsCollision(invaders[0, 1].EnemyBullet, gun))
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
             GameCommand p = new GameCommand(d, 1, 1, 1);
             int a;
             p.Init(60, 50, 5, 5);

             while (p.Score<=220)
             {
                 a = 0;

                 while (a!=3)
                 {
                     p.Update(ChooseKey.Shot);
                     
                     a++;
                 }
                 p.Update(ChooseKey.Shot);
                 p.Update(ChooseKey.Right);
             }        

             Assert.IsTrue(p.Score>=220);
         }

         [TestMethod]
         public void PauseTest()
         {
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);            
             p.Init(60, 50, 5, 5);
             p.Pause();          
             Assert.AreEqual(Status.IsPaused,p.GameStatus);
         }
        
         [TestMethod]
         [ExpectedException(typeof(InvalidOperationException))]
         public void PauseExceptionTest()
         {
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             p.Pause();
         }

         [TestMethod]
         [ExpectedException(typeof(InvalidOperationException))]
         public void RestoreExceptionTest()
         {
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             p.Restore();
         }

         [TestMethod]
         public void RestoreTest()
         {
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             p.Init(60, 50, 5, 5);
             p.Restore();
             Assert.AreEqual(Status.IsRuning, p.GameStatus);
         }

         [TestMethod]
         public void RestoreTest1()
         {
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             p.Init(60, 50, 5, 5);
             p.Pause();
             p.Restore();
             Assert.AreEqual(Status.IsRuning, p.GameStatus);
         }

         [TestMethod]
         public void HideBulletTest()
         {

             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);

             PrivateObject privateobj = new PrivateObject(p);

             p.Init(60, 50, 5, 7);

             Invader[,] inv = (Invader[,])privateobj.GetField("_invadersArray");
             for (var c = 0; c < 6; c++)
             {
                 for (var i = 0; i < inv.GetLength(0); i++)
                 {
                     for (var j = 0; j < inv.GetLength(1); j++)
                     {
                         inv[i, j].Live = false;
                     }
                 }

                 int count = 0;
                 while (count != 10)
                 {
                     p.Update(ChooseKey.Shot);
                     count++;
                 }
                 p.TryChangeLevel();
                 if (c == 0)
                 {
                     Assert.AreEqual(35, inv[1, 1].Speed);
                 }
                

             }
         }
         [TestMethod]
         public void UpdateObjectTest()
         {
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);
             p.Init(60, 50, 5, 5);
             ChooseKey k = ChooseKey.Restore;
             p.InputKey += delegate { return k; };
             p.Pause();
             if (p.GameStatus == Status.IsPaused)
             {
                 while (p.GameStatus != Status.IsRuning)
                 {
                 }
             }
             Assert.IsTrue(p.GameStatus == Status.IsRuning);
         }


         [TestMethod]
         public void UpdateObjectTest1()
         {         
             IDistanceStrategy d = new DistanceStrategy();
             GameCommand p = new GameCommand(d, 1, 1, 1);    
             p.Init(60, 50, 5, 5);
             p.InputKey += TestingKey;      
            while (p.GameStatus != Status.IsPaused)
            { }
             Assert.IsTrue(p.GameStatus == Status.IsPaused);       
         }

         public static ChooseKey TestingKey()
         {
             return ChooseKey.Pause;         
         }
    }
}
