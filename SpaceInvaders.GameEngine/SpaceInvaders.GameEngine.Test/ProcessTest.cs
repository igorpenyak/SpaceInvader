using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SpaceInvaders.GameEngine.Test
{
    [TestClass]
    public class ProcessTest
    {
        Process p = new Process();

        [TestMethod]
        public void ConstructorTest()
        {
            Assert.IsFalse(p.IsExit);
        }

        [TestMethod]
        public void InitTest()
        {
            p.Init(10,20);
            Assert.IsTrue(p.m_GameObjects.Count!=0);
        }

        [TestMethod]
        public void UpdScoreTest()
        {
            p.UpdScore(20);
            Assert.AreEqual(20, p.sc.score);
        }

        [TestMethod]
        public void UpdateTest()
        {
            p.Init(10,10);
            p.Update(5);
            Assert.IsTrue(p.b_list.Count!=0);
        }

        [TestMethod]
        public void UpdateAnotherTest()
        {
            p.Init(10, 10);
            p.Update(1);
            Assert.IsTrue(p.b_list.Count == 0);      
        }

          [TestMethod]
        public void TryLevelTest()
        {
            p.Init(10, 10);
            for (var c = 0; c < 6; c++)
            {
                for (var i = 0; i < p.i_arr.GetLength(0); i++)
                {
                    for (var j = 0; j < p.i_arr.GetLength(1); j++)
                    {
                        p.i_arr[i, j].Live = false;
                    }
                }
                p.TryChangeLevel();
                if (c == 0)
                {
                    Assert.AreEqual(35, p.i_arr[1, 1].Speed);
                }
                else if (c == 1)
                {
                    Assert.AreEqual(25, p.i_arr[1, 1].Speed);
                }
                else if (c == 2)
                {
                    Assert.AreEqual(20, p.i_arr[1, 1].Speed);
                }
                else if (c == 3)
                {
                    Assert.AreEqual(10, p.i_arr[1, 1].Speed);
                }
                else if (c == 4)
                {
                    Assert.AreEqual(5, p.i_arr[1, 1].Speed);
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
              p.Init(10, 10);
              for (var c = 0; c < 6; c++)
              {
                  for (var i = 0; i < p.i_arr.GetLength(0); i++)
                  {
                      for (var j = 0; j < p.i_arr.GetLength(1); j++)
                      {
                          p.i_arr[i, j].Live = false;
                      }
                  }
                  if (c <= 4)
                  {
                      p.TryChangeLevel();
                  }
                  else
                  {                      
                      p.m_GameObjects[1].Live = false;
                      p.TryExitGame();
                      Assert.IsTrue(p.IsExit);
                  }
                 
              }
          }

    }
}
