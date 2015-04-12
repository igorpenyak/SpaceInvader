using SpaceInvaders.GameEngine.Objects;
using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine
{
    public class Process
    {
          
            public bool IsExit { get; set; }        
            long previous = getCurrentTime();   
         // const int TIME_LIMIT_SECONDS = 300;
            const int pause = 100;
            private int _count=0;
        

            public List<GameObject> m_GameObjects = new List<GameObject>();
            public List<Bullet> b_list = new List<Bullet>();
            public Invader[,] i_arr = new Invader[6, 3];


            public Process()
            {
                IsExit = false;
            }

            public void Init(int x, int y)
          {
            Game Playground = new Game(x, y);  //Define Size of playground
            LazerGun gun = new LazerGun(x/2, y-1);

            SetEnemy(i_arr, y-1, 50, 2);
            m_GameObjects.Add(Playground);
            m_GameObjects.Add(gun);
                
          }  
        
            private static void SetEnemy(Invader[,] arr, int x, int s, int pos_y)  // set an army of invaders
        { 
            int posx=7;            

            for(int i=0;i<arr.GetLength(0);i++)
            {
                int posy = pos_y;

                    for (int j = 0; j < arr.GetLength(1); j++)
                    {
                        Invader inv = new Invader(posx, posy,x,posx+posy);
                        inv.Speed=s;
                        arr[i,j]= inv;
                        posy+=6;
                    }
                posx+=8;
            }        
        }


            private bool Level()
            { 
                int count=0;
                for (var i = 0; i < i_arr.GetLength(0); i++)
                {
                    for (var j = 0; j < i_arr.GetLength(1); j++)
                    {
                        if (i_arr[i, j].Live)
                        {
                            count++;
                        }
                    }
                
                }
                if (count == 0)
                {
                    return true;
                }
                return false;
            
            }

            private void NextLevel(int c)
            {
                switch (c)
                {
                    case (1):
                        SetEnemy(i_arr, m_GameObjects[1].PosY, 35, 8);
                        break;

                    case (2):
                        SetEnemy(i_arr, m_GameObjects[1].PosY, 25,12);
                        break;

                    case (3):
                        SetEnemy(i_arr, m_GameObjects[1].PosY, 20,16);
                        break;
                    case (4):
                        SetEnemy(i_arr,m_GameObjects[1].PosY, 10,18);
                        break;

                    case (5):
                        SetEnemy(i_arr, m_GameObjects[1].PosY,5,20);
                        break;
                }            
            }

            private static long getCurrentTime()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.Ticks;
        }                  

           public void Update(int k,GameObject obj)  
            {

            if (!this.m_GameObjects[1].Live || _count>5)
            {
                this.IsExit = true;
                return;
            }

            if (this.Level())
            {
                _count++;
                NextLevel(_count);
            }                           
           
            Thread.Sleep(pause);

	        //elapsedMilliseconds += INTERVAL;

            long current = getCurrentTime();

            #region Update objects

            foreach (var g in m_GameObjects)
            {
                if (g is IUpdateble)
                {
                    Bullet bull = new Bullet(g.PosX, g.PosY, true);

                    if (k == 5)
                    {
                        bull.InsertBull(b_list);
                    }
                    g.Update(k);
                            
                    Bullet.bulletBehavior(b_list,0);                           
                }
            }

            for (var i = 0; i < i_arr.GetLength(0); i++)
            {
                for (var j = 0; j < i_arr.GetLength(1); j++)
                {
                    if (i_arr[i, j].Live)
                    {
                        i_arr[i, j].Update((int)current);
                    }

                }
            }
            #endregion

            Console.Clear();

                #region Graphic part
                foreach (var gameObject in m_GameObjects)
                if (gameObject is IRenderable)
                {
                    obj.Render(gameObject.Name, gameObject.PosX, gameObject.PosY);
                    if (gameObject.Name == LazerGun.GetName())
                    {                                                                                 
                        for (var i = 0; i < b_list.Count; i++)
                        {                                            
                            obj.Render(b_list[i].Name, b_list[i].PosX, b_list[i].PosY);                                           
                        }                                                              
                    }
                }


            for (var i = 0; i < i_arr.GetLength(0); i++)
            {
                for (var j = 0; j < i_arr.GetLength(1); j++)
                {
                    if (i_arr[i, j].Live)
                    {
                        obj.Render(i_arr[i, j].Name, i_arr[i, j].PosX, i_arr[i, j].PosY);
                        string name;
                        int _x;
                        int _y;
                        if (i_arr[i, j].firstShot())
                        {
                            i_arr[i, j].GetBullet(out name, out _x, out _y);
                            obj.Render(name, _x, _y);
                        }
                    }
                }
            }
                #endregion
            Collision.FindCollision(this);
        }

             
    }
}
