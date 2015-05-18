using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.GameEngine;
using SpaceInvaders.GameEngine.Objects;
using System.Threading;
using SpaceInvaders.GameEngine.Logic;
using System.Timers;

namespace SpaceInvaders.ConsoleUI
{
    class Program
    {
        public static GameCommand Game{get; set;}
        
        static void Main(string[] args)
        {
            IDistanceStrategy d = new DistanceStrategy();
            GameCommand game = new GameCommand(d,1,1,1);
            ConsoleDraw draw = new ConsoleDraw();
            game.Draw += draw.Render;
            game.Show += draw.Show;
            game.Clear += Clear;
            Game = game;

            System.Timers.Timer t = new System.Timers.Timer(500);
            t.Start();  
            draw.StartScreen();
            game.Init(60, 50, 7, 5);            
            game.InputKey += Press_Key;
            while (!game.IsExit)
            {
                t.Elapsed += Program.Play;
                Thread.Sleep(1000);
            }
            if (game.Win || game.IsExit)
            {
                ConsoleDraw.GameOverScreen("Congratulation! You are the Winner!", Game.Score);
            }
            if (!game.Win || game.IsExit)
            {
                ConsoleDraw.GameOverScreen("Thanks for playing.", Game.Score);
            }
            
 
               
            
               
        }

        //take user's command
        #region Statics Method
        public static void Play(object source, ElapsedEventArgs e)
        {
           // Program program = source as Program;
            Game.GameUpdate();
            //if (!Game.IsExit)
            //{
            //    if (Game.Win)
            //    {
            //        ConsoleDraw.GameOverScreen("Congratulation! You are the Winner!", Game.Score);
            //    }
            //    else
            //    {
            //        ConsoleDraw.GameOverScreen("Thanks for playing.", Game.Score);
            //    }
            //}
                     
        
        }

        private static ChooseKey Press_Key() // transformate user`s command 
        {                      
            ConsoleKey key = readKey();

            if (key == ConsoleKey.RightArrow)
            {
                return ChooseKey.Right;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                return ChooseKey.Left;
            }
            else if (key == ConsoleKey.Spacebar)
            {                      
                return ChooseKey.Shot;
            }
            else if (key == ConsoleKey.Escape)
            {
                return ChooseKey.Pause;
            }
            else if (key == ConsoleKey.Enter)
            {
                return ChooseKey.Restore;
            }
            else
            {
                return ChooseKey.Wait; 
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

        private static void Clear(object sender, EventArgs e)
        {
            Console.Clear();
        }

        #endregion  





    }
}

