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
    public enum ChooseKey
    {
        Wait,
        Right,
        Left,       
        Shot,       
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
    public class GameCommand
    {
        #region Fields
        
            private const int THE_PAUSE = 100;
            private const int THE_ENEMYCOLUNS =70;
            private const int THE_ENEMYROWS = 50;
            private const int THE_NUMBERENEMYROWS = 5;
            private readonly IDistanceStrategy _distanceStrategy;   

            private int _count=0;
            private int _enemyPosX;
            private int _enemyPosY;
            private int _gunIndex;
            private int _enemyIndex;
            private int _bulletIndex;

          //  private Timer _timer;                           

            private List<Bullet> _gunBulletList = new List<Bullet>();
            private Invader[,] _invadersArray;
            private Score _score = new Score();
            private LazerGun _gun;
            private Field _playground;

        #endregion

        #region Properties

            public List<Bullet> GunBulletList
            {
                get {
                    return _gunBulletList;
                }
            }
            public Invader[,] InvadersArray
            {
                get
                {
                    return _invadersArray;
                }
            }
            public LazerGun LazerGun
            {
                get
                {
                    return _gun;
                }
            }

            public int GameLevel
            {
                get
                {
                    return _count;
                }
            }

        public bool IsExit { get; set; }     
        public bool Win { get; protected set; }   // flag for ending with player's win            
        public int Score 
        { 
            get 
            { 
                return _score.score;
            }
        }
        public Status GameStatus { get; private set; }
        public ChooseKey Key { get; set; } 
              
        #endregion
        
        #region Events

        public event EventHandler<GameObject> Draw;          
        public event EventHandler<Score> Show;
        public event EventHandler<EventArgs> Clear;
        public event Func<ChooseKey> InputKey;

        #endregion
        
        public GameCommand(IDistanceStrategy distanceStrategy, int g, int e, int b)
        {
            IsExit = false;
            this._distanceStrategy = distanceStrategy;
            GameStatus = Status.IsNeedInitialize;
            _gunIndex = g;
            _enemyIndex = e;
            _bulletIndex = b;
          //  _timer = new Timer(500);
            
        }

        public void Init(int x, int y, int pos_x, int pos_y)
        {
            if ( (x<=0) || (y<=0) || (pos_x<=0) || (pos_y<=0) || (pos_x>=x/6) || (pos_y>=y/6) || (y<pos_y+20) )
            {
                throw new InvalidOperationException("Game cann't be initialize with this parametrs!");
            }

            Field Playground = new Field(x, y);  //Define Size of playground
            LazerGun gun = new LazerGun(x/2, y-1, _gunIndex);
            _gun = gun;
            _playground = Playground;

            _enemyPosX = pos_x;
            _enemyPosY = pos_y;
            CreateEnemyArray(x, y);
            SetEnemy(_invadersArray, y-1, 40, pos_x, pos_y);

            GameStatus = Status.IsRuning;
          //  _timer.Start();
           // _timer.Elapsed += GameUpdate; 
            
        }

        #region Helpers
        
        public void OnDraw(GameObject gameObj)
        {
            if (this.Draw != null)
            {
                this.Draw(this, gameObj);
            }
        }

        public void OnShow(Score sc)
        {
            if (this.Show != null)
            {
                this.Show(this, sc);
            }
        }

        public void OnClear() 
        {
            if (this.Clear != null)
            {
                this.Clear(this, EventArgs.Empty);
            }
        }

        public ChooseKey OnInputKey()
        {
            if (this.InputKey != null)
            {
               return this.InputKey();                
            }

          return ChooseKey.Wait;
        }

        public void UpdScore(int number)
        {
            _score.AddScore(number);
            
        }

        public void CreateEnemyArray(int x, int y)
        {

            int i = x / THE_ENEMYCOLUNS;
            int j;
            if (y / THE_ENEMYROWS < THE_NUMBERENEMYROWS)
            {
                j = y / THE_ENEMYROWS;
            }
            else
            {
                j = THE_NUMBERENEMYROWS;
            }

            #region Validation
            if (i <= 0 && j <= 0)
            {
                throw new InvalidOperationException("Array cann't be initialize with this parametrs!");
            }

            #endregion

            _invadersArray = new Invader[i, j];         
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

        public void UpdatePlayer(ChooseKey key)
        {
            Bullet bull = new Bullet(_gun.PosX, _gun.PosY, true, _bulletIndex);

            if (key == ChooseKey.Shot) 
            {
                bull.InsertBull(_gunBulletList);
            }

            _gun.Update(key, _playground.PosX);                                                              
            Bullet.BulletBehavior(_gunBulletList,0);  
        }

        public void UpdateEnemy(int time)
        {
            for (var i = 0; i < _invadersArray.GetLength(0); i++)
            {
                for (var j = 0; j < _invadersArray.GetLength(1); j++)
                {
                    if (_invadersArray[i, j].Live)
                    {
                        _invadersArray[i, j].Update(time);
                    }
                }
            }
        }

        private void SetEnemy(Invader[,] arr, int x, int speed, int pos_x, int pos_y)  // set an army of invaders
        {
            int posx = pos_x;

            for (int i = 0; i < arr.GetLength(0); i++)
            {
                int posy = pos_y;

                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Invader invader = new Invader(posx, posy, x, posx + posy, _enemyIndex);
                    invader.Speed = speed;
                    arr[i, j] = invader;
                    posy += 30;
                }
                posx += 70;
            }
        }

        private bool Level()
        {
            int Count = 0;
            for (var i = 0; i < _invadersArray.GetLength(0); i++)
            {
                for (var j = 0; j < _invadersArray.GetLength(1); j++)
                {
                    if (_invadersArray[i, j].Live)
                    {
                        Count++;
                    }
                }

            }
            if (Count == 0)
            {
                return true;
            }
            return false;

        }

        private void NextLevel(int levelNumber)
        {
            switch (levelNumber)
            {
                case (1):
                    Level(35, 3 * _enemyIndex);                   
                    break;

                case (2):
                    Level(25, 7 * _enemyIndex);
                    break;

                case (3):
                    Level(20, 9 * _enemyIndex);
                    break;

                case (4):
                    Level(10, 12 * _enemyIndex);
                    break;

                case (5):
                    Level(5, 15 * _enemyIndex);
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
            _gunBulletList.RemoveAll(b => b.Live == true);
        }

         private void Level(int speed, int addToPos_y) 	
        { 
            HidePlayerBullet(); 
           SetEnemy(this._invadersArray, this._gun.PosY, speed, this._enemyPosX, this._enemyPosY + addToPos_y); 	
      }

        private static long GetCurrentTime()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.Millisecond;
        }                  
                                
        #endregion
        
      //  public void GameUpdate(object source, ElapsedEventArgs e)
            public void GameUpdate()
        {
            Key = OnInputKey();
            if (Key == ChooseKey.Pause)
            {
                this.Pause();
            }
            else if (Key == ChooseKey.Restore)
            {
                this.Restore();               
            }
            else
            {
                this.Update(Key);
            }
          this.Render();
        }
             
        public void Update(ChooseKey key)  
        {
            if (GameStatus!= Status.IsPaused)
            {                
                TryExitGame();
                TryChangeLevel();
                                
                long Current = GetCurrentTime();

                #region Update objects

                this.UpdatePlayer(key);
                this.UpdateEnemy((int)Current);

                #endregion

                FindCollision();               
            }
        }
                               
        #region Graphic part

        public void Render()  
    {
            OnClear();
         //  OnDraw(_playground);
            OnDraw(_gun);              
                                                
            for (var i = 0; i < _gunBulletList.Count; i++)
            {
                OnDraw(_gunBulletList[i]);   //draw LazerGun`s bullet   
            }                                                              
  
            for (var i = 0; i < _invadersArray.GetLength(0); i++)
            {
                for (var j = 0; j < _invadersArray.GetLength(1); j++)
                {
                    if (_invadersArray[i, j].Live)
                    {
                        OnDraw(_invadersArray[i, j]);
                   
                        if (_invadersArray[i, j].IsFirstShot())
                        {
                            OnDraw(_invadersArray[i, j].GetEnemyBullet());  // draw Invader`s bullet                             
                        }
                    }
                }
            }
            OnShow(_score);
            
    }

        #endregion

        #region ColliosionsMethod

        public void FindCollision()
        {
            for (var i = 0; i < _invadersArray.GetLength(0); i++)
            {
                for (var j = _invadersArray.GetLength(1) - 1; j >= 0; j--)
                {
                    if (_invadersArray[i, j].Live)
                    {
                        CollisionLazerGun(_invadersArray, i, j,_gunBulletList);
                        CollisionInvader(_invadersArray, i, j, _gun);
                    }
                }
            }
        }

        public bool IsCollision(GameObject striker, GameObject receiver)
        {
            return ((_distanceStrategy.GetDistance(striker, receiver)) <= 0);
        }


        public bool InvaderWin(GameObject obj1, GameObject obj2)
        {
            int k = obj2.PosY - obj1.PosY;
            if (k <= 1*_enemyIndex)
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

                if (IsCollision(Enemy[i, j].EnemyBullet, gun))
                {
                    gun.isDie();
                }
            }

        }


        public void CollisionLazerGun( Invader[,] Enemy, int i, int j, List<Bullet> gun_bullet)
        {
            for (int b = 0; b < gun_bullet.Count; b++)
            {

                if (IsCollision(Enemy[i, j], gun_bullet[b]))  // when LazerGun kill an Invader
                {
                    _gunBulletList.Remove(gun_bullet[b]);
                    Enemy[i, j].Live = false;
                    if (j == 2)
                    {
                        UpdScore(50);
                    }
                    else if (j == 1)
                    {
                        UpdScore(70);
                    }
                    else if (j == 0)
                    {
                        UpdScore(100);
                    }
                    else
                    {
                        UpdScore(30);
                    }
                }
            }
        }

        #endregion
    }
}
