using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.GameEngine;
using SpaceInvaders.GameEngine.Objects;
using System.Threading;
using SpaceInvaders.GameEngine.Logic;

namespace SpaceInvaders.ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            IDistanceStrategy d = new DistanceStrategy();
            Process game = new Process(d);
            ConsoleDraw draw = new ConsoleDraw();
            game.Draw += draw.Render;
            game.Show += draw.Show;
            game.Clear += Console.Clear;
                      
            draw.StartScreen();
            game.Init(60, 50, 7, 5);
            game.InputKey += Press_Key;

            while (true)
            {
                if(game.IsExit)
                {
                    game.Draw -= draw.Render;
                    game.Show -= draw.Show;
                    game.Clear -= Console.Clear;
                    game.InputKey -= Press_Key;

                    if (game.Win)
                    {                      
                        draw.GameOverScreen("Congratulation! You are the Winner!", game.Score);                      
                    }
                    else
                    {
                        draw.GameOverScreen("Thanks for playing.", game.Score);                      
                    }
                }
            }
               
        }

        //take user's command
        #region Statics Method

        private static KeyPress Press_Key() // transformate user`s command 
        {                      
            ConsoleKey key = readKey();

            if (key == ConsoleKey.RightArrow)
            {
                return KeyPress.Right;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                return KeyPress.Left;
            }
            else if (key == ConsoleKey.Spacebar)
            {                      
                return KeyPress.Shot;
            }
            else if (key == ConsoleKey.Escape)
            {
                return KeyPress.Pause;
            }
            else if (key == ConsoleKey.Enter)
            {
                return KeyPress.Restore;
            }
            else
            {
                return KeyPress.Wait; 
            }       
        }                       
         
        public static ConsoleKey readKey()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey().Key;
                ClearKeyBuffer();
                return key;
            }
            return 0;
        }

        public static void ClearKeyBuffer()
        {
            while (Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }

        #endregion  





    }
}

