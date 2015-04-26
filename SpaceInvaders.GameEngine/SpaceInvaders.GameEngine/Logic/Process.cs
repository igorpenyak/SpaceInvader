using SpaceInvaders.GameEngine.Logic;
using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace SpaceInvaders.GameEngine
{
    public enum KeyPress
    {
        Left,
        Right,
        Shot,
        Wait,
        Pause,
        Restore
    }

    public enum Status
    {
        IsNeedInitialize,        
        IsRuning,
        IsPaused,
        IsExit
    }
    public class Process
    {
        #region Fields
        
            private const int _pause = 100;
            private int _count=0;
            private int _enemy_posx;
            private int _enemy_posy;
            private Timer _timer;
         
            private readonly IDistanceStrategy _distanceStrategy;          
                         
            List<Bullet> b_list = new List<Bullet>();
            Invader[,] i_arr;
            Score _sc = new Score();
            LazerGun _gun;
            Field _playground;


        #endregion

        #region Properties
        public bool IsExit { get; set; }     
        public bool Win { get; set; }   // flag for ending with player's win            
        public int GetScore 
        { get 
            { 
                return _sc.score;
            }
        }
        public Status GameStatus { get; private set; }
        public KeyPress Key { get; set; } 
              
        #endregion
        
        #region Events
        public event Action<GameObject> Draw;          
        public event Action<Score> Show;
        public event Action Clear;
        public event Func<KeyPress> InputKey;
        #endregion
        
        public Process(IDistanceStrategy distanceStrategy)
        {
            IsExit = false;
            this._distanceStrategy = distanceStrategy;
            GameStatus = Status.IsNeedInitialize;
            _timer = new Timer(100);
            _timer.Elapsed += GameUpdate; 
        }

        public void Init(int x, int y, int pos_x, int pos_y)
        {
            if (x<=0 || y<=0 || pos_x<=0 || pos_y<=0 || pos_x>=x/6 || pos_y>=y/6 || y<pos_y+20)
            {
                throw new InvalidOperationException("Game cann't be initialize with this parametrs!");
            }

            Field Playground = new Field(x, y);  //Define Size of playground
            LazerGun gun = new LazerGun(x/2, y-1);
            _gun = gun;
            _playground = Playground;

            _enemy_posx = pos_x;
            _enemy_posy = pos_y;
            CreateEnemyArray(x, y);
            SetEnemy(i_arr, y-1, 50, pos_x, pos_y);

            GameStatus = Status.IsRuning;
            _timer.Start();
        }

        #region Helpers
        
        public void OnDraw(GameObject gameObj)
        {
            if (this.Draw != null)
            {
                this.Draw(gameObj);
            }
        }

        public void OnShow(Score sc)
        {
            if (this.Show != null)
            {
                this.Show(sc);
            }
        }

        public void OnClear() 
        {
            if (this.Clear != null)
            {
                this.Clear();
            }
        }

        public KeyPress OnInputKey()
        {
            if (this.InputKey != null)
            {
              return this.InputKey();                
            }

            return KeyPress.Wait;
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

            #region Validation
            if (i <= 0 && j <= 0)
            {
                throw new InvalidOperationException("Array cann't be initialize with this parametrs!");
            }

            #endregion

            i_arr = new Invader[i, j];         
        }     

        public void TryExitGame()
        {
            if (!this._gun.Live || _count > 5)
            {
                this.IsExit = true;
                GameStatus = Status.IsExit;
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
              
        public void Pause()
        {
            #region Validation

            if (GameStatus != Status.IsRuning && GameStatus != Status.IsPaused)
            {
                throw new InvalidOperationException("Game can`t be paused");
            }
            

            #endregion

            GameStatus = Status.IsPaused;         
        }

        public void Restore()
        {
            #region Validation

            if (GameStatus != Status.IsPaused && GameStatus != Status.IsRuning)
            {
                throw new InvalidOperationException("Not paused game can`t be restored");
            }

            #endregion

            GameStatus = Status.IsRuning;                      
        }

        public void UpdatePlayer(KeyPress key)
        {
            Bullet bull = new Bullet(_gun.PosX, _gun.PosY, true);

            if (key == KeyPress.Shot) 
            {
                bull.InsertBull(b_list);
            }

            _gun.Update(key, _playground.PosX);                                                              
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

        private void SetEnemy(Invader[,] arr, int x, int s, int pos_x, int pos_y)  // set an army of invaders
        {
            int posx = pos_x;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int posy = pos_y;

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Invader inv = new Invader(posx, posy, x, posx + posy);
                    inv.Speed = s;
                    arr[i, j] = inv;
                    posy += 6;
                }
                posx += 8;
            }
        }

        private bool Level()
        {
            int count = 0;
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
                    this.HidePlayerBullet();
                    SetEnemy(i_arr, _gun.PosY, 35, _enemy_posx, _enemy_posy + 3);
                    break;

                case (2):
                    this.HidePlayerBullet();
                    SetEnemy(i_arr, _gun.PosY, 25, _enemy_posx, _enemy_posy + 7);
                    break;

                case (3):
                    this.HidePlayerBullet();
                    SetEnemy(i_arr, _gun.PosY, 20, _enemy_posx, _enemy_posy + 9);
                    break;

                case (4):
                    this.HidePlayerBullet();
                    SetEnemy(i_arr, _gun.PosY, 10, _enemy_posx, _enemy_posy + 12);
                    break;

                case (5):
                    this.HidePlayerBullet();
                    SetEnemy(i_arr, _gun.PosY, 5, _enemy_posx, _enemy_posy + 15);
                    break;
                default:
                    IsExit = true;
                    Win = true;
                    GameStatus = Status.IsExit;
                    break;
            }
        }

        private void HidePlayerBullet()
        {
            b_list.RemoveAll(b => b.Live == true);
        }

        private static long getCurrentTime()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.Millisecond;
        }                  
                                
        #endregion
        
        public void GameUpdate(object source, ElapsedEventArgs e)
        {
            Key = OnInputKey();
            if (Key == KeyPress.Pause)
            {
                this.Pause();
            }
            else if (Key == KeyPress.Restore)
            {
                this.Restore();               
            }
            else
            {
                this.Update(Key);
            }
           this.Render();
        }
             
        public void Update(KeyPress key)  
        {
            if (GameStatus!= Status.IsPaused)
            {
                
                TryExitGame();
                TryChangeLevel();
                                
                long current = getCurrentTime();

                #region Update objects

                this.UpdatePlayer(key);
                this.UpdateEnemy((int)current);

                #endregion

                FindCollision();
                this.Render();
            }
        }
                               
        #region Graphic part

        public void Render()  
    {
            OnClear();
            OnDraw(_playground);
            OnDraw(_gun);                                                              
            for (var i = 0; i < b_list.Count; i++)
            {
                OnDraw(b_list[i]);   //draw LazerGun`s bullet   
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
                        OnDraw(i_arr[i, j].GetBullet());  // draw Invader`s bullet                             
                    }
                }
            }
        }
            OnShow(_sc);
                
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
