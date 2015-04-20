using SpaceInvaders.GameEngine.Logic;
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
            private readonly IDistanceStrategy _distanceStrategy;
       
            List<Bullet> b_list = new List<Bullet>();
            Invader[,] i_arr;
            Score _sc = new Score();
            LazerGun _gun;
            Game _playground;


        #endregion

        #region Properties
        public bool IsExit { get; set; }
        public bool Win { get; set; }   // flag for ending with player's win            
        public int GetScore { get 
            { 
                return _sc.score;
            }
        }
      
        #endregion
        
        #region Events
        public event Action<GameObject> Draw;          
        public event Action<string,int> Show;
        #endregion


        public Process(IDistanceStrategy distanceStrategy)
        {
            IsExit = false;
            this._distanceStrategy = distanceStrategy;
           
        }

        public void Init(int x, int y, int pos_x, int pos_y)
        {
            if (x<=0 || y<=0 || pos_x<=0 || pos_y<=0 || pos_x>=x/6 || pos_y>=y/6 || y<pos_y+20)
            {
                throw new InvalidOperationException("Game cann't be initialize with this parametrs!");
            }

            Game Playground = new Game(x, y);  //Define Size of playground
            LazerGun gun = new LazerGun(x/2, y-1);
            _gun = gun;
            _playground = Playground;

            _enemy_posx = pos_x;
            _enemy_posy = pos_y;
            CreateEnemyArray(x, y);
            SetEnemy(i_arr, y-1, 50, pos_x, pos_y);                               
        }

        #region Helpers
        
        public void OnDraw(GameObject gameObj)
        {
            if (this.Draw != null)
            {
                this.Draw(gameObj);
            }
        }

        public void OnShow(string s, int a)
        {
            if (this.Show != null)
            {
                this.Show(s, a);
            }
        }

        public void UpdScore(int number)
        {
            _sc.AddScore(number);
            
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
        private void SetEnemy(Invader[,] arr, int x, int s, int pos_x, int pos_y)  // set an army of invaders
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
                    SetEnemy(i_arr, _gun.PosY, 35, _enemy_posx, _enemy_posy + 3);
                    break;

                case (2):
                    SetEnemy(i_arr, _gun.PosY, 25, _enemy_posx, _enemy_posy + 7);
                    break;

                case (3):
                    SetEnemy(i_arr, _gun.PosY, 20, _enemy_posx, _enemy_posy + 9);
                    break;

                case (4):
                    SetEnemy(i_arr, _gun.PosY, 10, _enemy_posx, _enemy_posy + 12);
                    break;

                case (5):
                    SetEnemy(i_arr, _gun.PosY, 5, _enemy_posx, _enemy_posy + 15);
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
            if (!this._gun.Live || _count > 5)
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
            Bullet bull = new Bullet(_gun.PosX, _gun.PosY, true);

            if (k == 5) 
            {
                bull.InsertBull(b_list);
            }

            _gun.Update(k, _playground.PosX);                                                              
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
      //  Thread.Sleep(20);       
            
	    //elapsedMilliseconds += INTERVAL;

        long current = getCurrentTime();

        #region Update objects

        this.UpdatePlayer(k);
        this.UpdateEnemy((int)current);                             

        #endregion

        FindCollision();

        }
                       
        
        #region Graphic part

        public void Render()  
    {
            OnDraw(_playground);
            OnDraw(_gun);                                                              
            for (var i = 0; i < b_list.Count; i++)
            {                                         
                //draw LazerGuns bullet    
                OnDraw(b_list[i]);   
            }                                                              
  
        for (var i = 0; i < i_arr.GetLength(0); i++)
        {
            for (var j = 0; j < i_arr.GetLength(1); j++)
            {
                if (i_arr[i, j].Live)
                {
                    OnDraw(i_arr[i, j]);
                   
                    if (i_arr[i, j].firstShot())
                    {
                        OnDraw(i_arr[i, j].GetBullet());  // draw Invaders  Bullet                             
                    }
                }
            }
        }
            OnShow(_sc.name, _sc.score);
            OnShow(_gun.Name, _gun.NumberOfLives);
            //Thread.Sleep(_pause);
    }

            #endregion

        #region ColliosionsMethod

        public void FindCollision()
        {
            for (var i = 0; i < i_arr.GetLength(0); i++)
            {
                for (var j = i_arr.GetLength(1) - 1; j >= 0; j--)
                {
                    if (i_arr[i, j].Live)
                    {
                        CollisionLazerGun(i_arr, i, j,b_list);
                        CollisionInvader(i_arr, i, j, _gun);
                    }
                }
            }
        }

        public bool isCollision(GameObject striker, GameObject receiver)
        {
            return ((_distanceStrategy.GetDistance(striker, receiver)) <= 0);
        }


        public bool InvaderWin(GameObject obj1, GameObject obj2)
        {
            int k = obj2.PosY - obj1.PosY;
            if (k <= 1)
            {
                return true;
            }
            return false;
        }

        public void CollisionInvader(Invader[,] Enemy, int i, int j, LazerGun gun)
        {

            if (InvaderWin(Enemy[i, j], gun))  // when Invader win
            {
                gun.Live = false;
            }


            if (Enemy[i, j].CanShot != 0)
            {

                if (isCollision(Enemy[i, j].EnemyBullet, gun))
                {
                    gun.isDie();
                }
            }

        }


        public void CollisionLazerGun( Invader[,] Enemy, int i, int j, List<Bullet> gun_bullet)
        {
            for (int b = 0; b < gun_bullet.Count; b++)
            {

                if (isCollision(Enemy[i, j], gun_bullet[b]))  // when LazerGun kill an Invader
                {
                    b_list.Remove(gun_bullet[b]);
                    Enemy[i, j].Live = false;
                    if (j == 2)
                    {
                        UpdScore(50);
                    }
                    else if (j == 1)
                    {
                        UpdScore(70);
                    }
                    else
                    {
                        UpdScore(100);
                    }
                }
            }
        }

        #endregion
    }
}
