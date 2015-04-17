using SpaceInvaders.GameEngine.Objects;
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

        #region Fields
        
            private const int _pause = 100;
            private int _count=0;
            private int _enemy_posx;
            private int _enemy_posy;

        #endregion

        #region Properties
        public bool IsExit { get; set; }
        public bool Win { get; set; }   // flag for ending with player's win            
                
        public List<GameObject> m_GameObjects = new List<GameObject>();
        public List<Bullet> b_list = new List<Bullet>();
        public Invader[,] i_arr;
        public Score sc = new Score();

        #endregion
        
        #region Events and Delegates
        public delegate void DrawMethod(string s, int a, int b);
        public delegate void ShowMethod(string s, int a);
        public event DrawMethod toDraw;           
        public event ShowMethod toShow;
        #endregion


        public Process()
        {
            IsExit = false;
        }

        public void Init(int x, int y, int pos_x, int pos_y)
        {
            if (x<=0 || y<=0 || pos_x<=0 || pos_y<=0 || pos_x>=x/6 || pos_y>=y/6 || y<pos_y+20)
            {
                throw new InvalidOperationException("Game cann't be initialize with this parametrs!");
            }

            Game Playground = new Game(x, y);  //Define Size of playground
            LazerGun gun = new LazerGun(x/2, y-1);

            _enemy_posx = pos_x;
            _enemy_posy = pos_y;
            CreateEnemyArray(x, y);
            SetEnemy(i_arr, y-1, 50, pos_x, pos_y);
            m_GameObjects.Add(Playground);
            m_GameObjects.Add(gun);                       
        }

        #region Helpers

        public void UpdScore(int number)
        {
            sc.AddScore(number);
            
        }

        public void CreateEnemyArray(int x, int y)
        {

            int i = x / 10;
            int j;
            if (y / 8 < 3)
            {
                j = y / 8;
            }
            else
            {
                j = 3;
            }                
            if (i <= 0 && j <= 0)
            {
                throw new InvalidOperationException("Array cann't be initialize with this parametrs!");
            }
               
                i_arr = new Invader[i, j];         
        }
        private static void SetEnemy(Invader[,] arr, int x, int s, int pos_x, int pos_y)  // set an army of invaders
    { 
        int posx=pos_x;            

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
                    SetEnemy(i_arr, m_GameObjects[1].PosY, 35, _enemy_posx, _enemy_posy + 3);
                    break;

                case (2):
                    SetEnemy(i_arr, m_GameObjects[1].PosY, 25, _enemy_posx, _enemy_posy + 7);
                    break;

                case (3):
                    SetEnemy(i_arr, m_GameObjects[1].PosY, 20, _enemy_posx, _enemy_posy + 9);
                    break;

                case (4):
                    SetEnemy(i_arr, m_GameObjects[1].PosY, 10, _enemy_posx, _enemy_posy + 12);
                    break;

                case (5):
                    SetEnemy(i_arr, m_GameObjects[1].PosY, 5, _enemy_posx, _enemy_posy + 15);
                    break;
                default:
                    IsExit = true;
                    Win = true;
                    break;
            }            
        }

        private static long getCurrentTime()
    {
        DateTime currentDate = DateTime.Now;
        return currentDate.Millisecond;
    }                  

        public void TryExitGame()
        {
            if (!this.m_GameObjects[1].Live || _count>5)
            {
                this.IsExit = true;
                return;
            }
        }

        public void TryChangeLevel()
        {
            if (this.Level())
            {
                _count++;
                NextLevel(_count);
            }
        }             
           
        public void UpdatePlayer(int k)
        {
            Bullet bull = new Bullet(m_GameObjects[1].PosX, m_GameObjects[1].PosY, true);

            if (k == 5) 
            {
                bull.InsertBull(b_list);
            }
                
            m_GameObjects[1].Update(k, m_GameObjects[0].PosX);                                                              
            Bullet.bulletBehavior(b_list,0);  
        }

        public void UpdateEnemy(int c)
        {
            for (var i = 0; i < i_arr.GetLength(0); i++)
            {
                for (var j = 0; j < i_arr.GetLength(1); j++)
                {
                    if (i_arr[i, j].Live)
                    {
                        i_arr[i, j].Update(c);
                    }

                }
            }
        }
            
        #endregion
        
        public void Update(int k)  
        {

        TryExitGame();
        TryChangeLevel();
        Thread.Sleep(20);       
            
	    //elapsedMilliseconds += INTERVAL;

        long current = getCurrentTime();

        #region Update objects

        this.UpdatePlayer(k);
        this.UpdateEnemy((int)current);                             

        #endregion

        Collision.FindCollision(this);

        }
                       
        
        #region Graphic part

        public void Render()  
    {
            foreach (var gameObject in m_GameObjects)
            {
               
                toDraw(gameObject.Name, gameObject.PosX, gameObject.PosY);
                if (gameObject is LazerGun)
                {                                                                                 
                    for (var i = 0; i < b_list.Count; i++)
                    {                                            
                        //draw LazerGuns bullet    
                        toDraw(b_list[i].Name, b_list[i].PosX, b_list[i].PosY);   
                    }                                                              
                }
            }


        for (var i = 0; i < i_arr.GetLength(0); i++)
        {
            for (var j = 0; j < i_arr.GetLength(1); j++)
            {
                if (i_arr[i, j].Live)
                {                   
                    toDraw(i_arr[i, j].Name, i_arr[i, j].PosX, i_arr[i, j].PosY);
                    string name;
                    int _x;
                    int _y;
                    if (i_arr[i, j].firstShot())
                    {
                        i_arr[i, j].GetBullet(out name, out _x, out _y);
                        toDraw(name, _x, _y);  // draw Invaders  Bullet                             
                    }
                }
            }
        }
            toShow(sc.name, sc.score);
            toShow(m_GameObjects[1].Name, m_GameObjects[1].NumberOfLives);
            Thread.Sleep(_pause);
    }

            #endregion

    }
}
