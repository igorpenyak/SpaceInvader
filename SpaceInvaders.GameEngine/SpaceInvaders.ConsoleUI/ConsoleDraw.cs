using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.ConsoleUI
{
    class ConsoleDraw:GameObject,GameEngine.Objects.Interfaces.IRenderable
    {

        public ConsoleDraw() :base("Draw", 0, 0)
        { }


        public override void Render(string name, int x, int y)
        {
            switch (name)
            { 
                case ("Gun"):
                    if (x >= 0 && x < 57)
                    {
                        Console.SetCursorPosition(x, y);
                        char[] Gun = { 'X', 'X', 'X' };
                        foreach (var g in Gun)
                        {
                            Console.Write(g);
                        }
                    }
                break;

                case ("Bullet"):
                    //if (y > 2)
                    //{
                   
                    Console.SetCursorPosition(x+1, y);
                    Console.Write("^");
                    ////if (y >= 48)
                    ////{ y = 46; };
                   // Console.SetCursorPosition(x, y + 1);
                    //Console.Write("");
                    //}
                    //else
                    //{ 
                    //    LazerGun.first_shot = false; 
                    //}                    
                break;

                case ("Invader"):
                     Console.SetCursorPosition(x, y);
                    //char[,] Invader = { { 'X', 'X', 'X', 'X' }, { ' ', 'X', 'X', ' ' } };
                    //for (int i = 0; i < Invader.GetLength(1); i++)
                    //{
                    //    Console.Write(Invader[0, i]);
                    //}
                    //Console.SetCursorPosition(x, y + 1);
                    //for (int i = 0; i < Invader.GetLength(1); i++)
                    //{
                    //    Console.Write(Invader[1, i]);
                    //}
                     Console.Write("^___^");
                break;

                case ("Shield"):
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Build a shield!");
                break;

                case ("Field"):  
                    //Console.CursorVisible=false;
                    Console.SetWindowSize(x, y);
                    Console.SetBufferSize(x, y);
                        break;






            }
        
        }

    }
}
