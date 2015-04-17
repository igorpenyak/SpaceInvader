using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.GameEngine;
using SpaceInvaders.GameEngine.Objects;
using System.Threading;

namespace SpaceInvaders.ConsoleUI
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Process p = new Process();
            ConsoleDraw draw = new ConsoleDraw();
            p.Init(60,50,7,5);
            draw.StartScreen();
            p.toDraw += draw.Render;         
            p.toShow += draw.Show;

            while (!p.IsExit)
            {              
                int k = Press_Key();
                p.Update(k);            
                               
                Console.Clear();
                p.Render();       
            }

            if (p.IsExit && p.Win)
            {
                Console.Clear();
                Console.SetCursorPosition(15, 25);
                Console.WriteLine("Congratulation! You are the Winner! Your score: {0}", p.sc.score );
                Console.CursorVisible = false;
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(15, 25);
                Console.WriteLine("Thanks for playing. Your score: {0}", p.sc.score);
                Console.CursorVisible = false;
                Console.ReadKey();
            }
               
        }

        //take user's command
        #region Statics Method

        private static int Press_Key() // transformate user`s command 
        {                      
            ConsoleKey key = readKey();

            if (key == ConsoleKey.RightArrow)
            {
                return 1;
            }
            else if (key == ConsoleKey.LeftArrow)
            {
                return -1;
            }
            else if (key == ConsoleKey.Spacebar)
            {                      
                return 5;
            }
            else
            {
                return 0; 
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

