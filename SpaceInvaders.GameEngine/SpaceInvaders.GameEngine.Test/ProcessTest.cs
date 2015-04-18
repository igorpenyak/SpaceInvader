using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpaceInvaders.GameEngine.Logic;

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

        //  [TestMethod]
        //public void TryLevelTest()
        //{
        //    IDistanceStrategy d = new DistanceStrategy();
        //    Process p = new Process(d);
        //    p.Init(60, 50, 5, 7);
        //    for (var c = 0; c < 6; c++)
        //    {
        //        for (var i = 0; i < p.i_arr.GetLength(0); i++)
        //        {
        //            for (var j = 0; j < p.i_arr.GetLength(1); j++)
        //            {
        //                p.i_arr[i, j].Live = false;
        //            }
        //        }
        //        p.TryChangeLevel();
        //        if (c == 0)
        //        {
        //            Assert.AreEqual(35, p.i_arr[1, 1].Speed);
        //        }
        //        else if (c == 1)
        //        {
        //            Assert.AreEqual(25, p.i_arr[1, 1].Speed);
        //        }
        //        else if (c == 2)
        //        {
        //            Assert.AreEqual(20, p.i_arr[1, 1].Speed);
        //        }
        //        else if (c == 3)
        //        {
        //            Assert.AreEqual(10, p.i_arr[1, 1].Speed);
        //        }
        //        else if (c == 4)
        //        {
        //            Assert.AreEqual(5, p.i_arr[1, 1].Speed);
        //        }
        //        else
        //        {
        //            Assert.IsTrue(p.Win);
        //        }
        //    }
        //}
        //  [TestMethod]
        //  public void TryExitTest()
        //  {
        //      IDistanceStrategy d = new DistanceStrategy();
        //      Process p = new Process(d);
        //      p.Init(60, 50, 5, 7);
        //      for (var c = 0; c < 6; c++)
        //      {
        //          for (var i = 0; i < p.i_arr.GetLength(0); i++)
        //          {
        //              for (var j = 0; j < p.i_arr.GetLength(1); j++)
        //              {
        //                  p.i_arr[i, j].Live = false;
        //              }
        //          }
        //          if (c <= 4)
        //          {
        //              p.TryChangeLevel();
        //          }
        //          else
        //          {                      
        //              p.m_GameObjects[1].Live = false;
        //              p.TryExitGame();
        //              Assert.IsTrue(p.IsExit);
        //          }
                 
        //      }
        //  }

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

         //[TestMethod]
         //public void RenderTest_3()
         //{
         //    bool methodCalled = false;
         //    int methodCall = 0;
         //    IDistanceStrategy d = new DistanceStrategy();
         //    Process p = new Process(d);
         //    p.Init(60, 50, 5, 5);
         //    while (!p.i_arr[0, 0].firstShot() && !p.i_arr[1,1].firstShot() && !p.i_arr[1, 0].firstShot())
         //    {
         //        p.Update(0);
         //    }
         //    p.Draw += delegate { methodCalled = true; };
         //    p.Show += delegate { methodCall = 1; };
         //    p.Render();

         //    Assert.AreEqual(1, methodCall);

         //}

       
       //  }
    }
}
