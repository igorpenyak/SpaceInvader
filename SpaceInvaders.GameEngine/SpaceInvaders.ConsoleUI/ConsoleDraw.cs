﻿using SpaceInvaders.GameEngine;
using SpaceInvaders.GameEngine.Logic.EventArguments;
using SpaceInvaders.GameEngine.Objects;
using System;

namespace SpaceInvaders.ConsoleUI
{
    class ConsoleDraw
    {
        #region Methods
        public void StartScreen()
        {
            Console.SetCursorPosition(25, 4);
            Console.WriteLine("Space Invaders");

            Console.SetCursorPosition(20, 8);
            Console.WriteLine("Keys:");
            Console.WriteLine("\n"+"Right Arrow - move right;");
            Console.WriteLine("\n" + "Left Arrow - move Left;");
            Console.WriteLine("\n" + "Space - make shot;");
            Console.WriteLine("\n" + "Escape - Pause;");
            Console.WriteLine("\n" + "Enter - Resort game.");
            Console.SetCursorPosition(20, 20);
            Console.WriteLine("Please press any key to play...");
            
            Console.ReadKey();           
        }

        public void Render(object sender, GameObject obj)
        { 
            if(obj is Field)
            {
                this.RenderField((Field)obj);
            }
            else if (obj is LazerGun)
            {
                this.RenderGun((LazerGun)obj);
            }
            else if (obj is Invader)
            {
                this.RenderInvader((Invader)obj);
            }
            else
            {
                this.RenderBullet((Bullet)obj);
            }        
        }

        private void RenderGun(LazerGun obj)
        {
            Console.SetCursorPosition(12, 2);
            Console.Write("Lives: {0}", obj.NumberOfLives);
            Console.SetCursorPosition(obj.PosX - 2, obj.PosY);
            Console.Write("XXXXX");         
        }

        private void RenderInvader(Invader obj)
        {
            Console.SetCursorPosition(obj.PosX, obj.PosY);
            Console.Write("^___^");
        }

        private void RenderField(Field obj)
        {
            Console.SetWindowSize(obj.PosX, obj.PosY);
            Console.SetBufferSize(obj.PosX, obj.PosY);
        }

        private void RenderBullet(Bullet obj)
        {
            Console.SetCursorPosition(obj.PosX + 1, obj.PosY);
            Console.Write("^");      
        }

        public static void GameOverScreen(String s, int i)
        {
            Console.Clear();
            Console.SetCursorPosition(15, 25);
            Console.WriteLine(s);
            Console.SetCursorPosition(15, 26);
            Console.WriteLine("Your score: {0}", i);
            Console.CursorVisible = false;
            Console.ReadKey();
        }

        public void Show(object sender, Score sc)
        {         
            Console.SetCursorPosition(37, 2);
            Console.Write("Score: {0}", sc.score);
        }

        #endregion    
    }
}
