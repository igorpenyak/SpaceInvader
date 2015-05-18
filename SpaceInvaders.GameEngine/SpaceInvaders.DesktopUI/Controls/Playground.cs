using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpaceInvaders.GameEngine;
using SpaceInvaders.GameEngine.Logic;
using SpaceInvaders.GameEngine.Objects;

namespace SpaceInvaders.DesktopUI.Controls
{
    public partial class Playground : UserControl
    {
        public ChooseKey UserKey{get; set;}

        private GameCommand _game;

        private ControlGameDraw _draw;
        
        private Timer _timer;

        public event EventHandler GameEndInvader;

        public event EventHandler GameEndPlayer;
        public Playground(Form parent)
        {
  
            InitializeComponent();

            _parentForm = parent;
            _parentForm.KeyPreview = true;

            IDistanceStrategy d = new FormsDistanceStrategy();
           _game = new GameCommand(d,10,10,10);

            Graphics graphicControl = this.CreateGraphics();
            _draw= new ControlGameDraw(graphicControl, this.Size.Width, this.Size.Height);

            _game.InputKey += Press_Key;

            _game.Draw += this.InvalidateDispatched;
            _timer = new System.Windows.Forms.Timer();
            _timer.Interval = 200;

        }


        private void Playground_Load(object sender, EventArgs e)
        {
            InitKeyPress(sender, e);
        }

       
        //take user's command
        #region Helpers


        private void OnGameEndInvader()
        {
            if (GameEndInvader != null)
            {
                this.GameEndInvader(this, EventArgs.Empty);
            }
        }



        public void Run()
        {            
            _game.Init(this.Size.Width - 50, this.Size.Height - 50, 40, 50);
            _timer.Tick += new EventHandler(Gameplay);
            _timer.Start();         
        }



    
        private void Gameplay(object sender, EventArgs e)
        {   
           _game.GameUpdate();
           UserKey = ChooseKey.Wait;
           if (_game.Win && _game.IsExit)
           {
            //   this.Hide();
               
           }
           else if (!_game.Win && _game.IsExit)
           {
               this.Hide();
             
                   
                              
           }

        //    this.Refresh();
           // this.Invalidate();
                         
        }



        private void InvalidateDispatched(object sender, GameObject gameObject)
        {
            // change state of the _draw object       
             //  this._gameObject = gameObject;

            Action d  = () =>
            {
                this.Invalidate();                   
            };

            this.BeginInvoke(d);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Render the whole gameplay
            this._draw.RenderGamePlay(_game,e);
            this.lblNumderScore.Text = _game.Score.ToString();
            this.lblNumderLives.Text = _game.LazerGun.NumberOfLives.ToString();

            //if (this._gameObject != null)
            //{
            //    _draw.Render(this._gameObject, e);
            //}

        }


        private void InitKeyPress(object sender, EventArgs e)
        {
            _parentForm.KeyPreview = true;         
        }
         

        private  ChooseKey Press_Key() // transformate user`s command 
        {          
            if (UserKey == ChooseKey.Right)
            {
                return ChooseKey.Right;
            }
            else if (UserKey == ChooseKey.Left)
            {
                return ChooseKey.Left;
            }
            else if (UserKey == ChooseKey.Shot)
            {
                return ChooseKey.Shot;
            }
                 if (UserKey == ChooseKey.Pause)
            {
                return ChooseKey.Pause;
            }
            else if (UserKey == ChooseKey.Restore)
            {
                return ChooseKey.Restore;
            }
            else
            {
                return ChooseKey.Wait;
              
            }       

        }

        private void Playground_KeyDown(object sender, KeyEventArgs e)
        {          
            switch (e.KeyData)
            {
                case Keys.Left: UserKey = ChooseKey.Left;
                    break;
                case Keys.Right: UserKey = ChooseKey.Right;
                    break;
                case Keys.Space: UserKey = ChooseKey.Shot;
                    break;
                case Keys.Escape: UserKey = ChooseKey.Pause;
                    break;
                case Keys.Enter: UserKey = ChooseKey.Restore;
                    break;
                default: UserKey = ChooseKey.Wait;
                    break;
            }

        }

        // override method for Arrows Keys
        protected override bool ProcessDialogKey(Keys keyData)
        {
            OnKeyDown(new KeyEventArgs(keyData));
            return base.ProcessDialogKey(keyData);
        }

              
        #endregion  

      

        }       
      
    }

