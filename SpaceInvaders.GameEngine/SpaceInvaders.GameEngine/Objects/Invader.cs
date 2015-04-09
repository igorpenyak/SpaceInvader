using SpaceInvaders.GameEngine.Objects.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine.Objects
{
    public class Invader : GameObject, IUpdateble, IRenderable
    {
        private int numberOfLive;

        //public  void Move();
        public Invader(int x, int y)
            : base("Invader", x, y)
        {
        }

       // List<Bullet> b_list = new List<Bullet>();

        //public void Shot()
        //{
        //    Bullet bullet = new Bullet(PosX + 1, PosY, false);
        //    b_list.Add(bullet);
        //    bullet.Move();
        //}

        // public override void Update(double time)
        //{

        //}
        public virtual void Render()
        {
            //Console.SetCursorPosition(PosX, PosY);
            //char[,] Invader = { { 'X', 'X', 'X', 'X' }, { ' ', 'X', 'X', ' ' } };
            //for (int i = 0; i < Invader.GetLength(1); i++)
            //{
            //    Console.Write(Invader[0, i]);
            //}
            //Console.SetCursorPosition(PosX, PosY + 1);
            //for (int i = 0; i < Invader.GetLength(1); i++)
            //{
            //    Console.Write(Invader[1, i]);
            //}

        }
    }
}
