using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.ConsoleUI
{
    class ConsoleDraw : GameObject
    {

        public ConsoleDraw() :base("Draw", 0, 0)
        { }


        public void StartScreen()
        {
            Console.SetCursorPosition(25, 4);
            Console.WriteLine("Space Invaders");

            Console.SetCursorPosition(20, 8);
            Console.WriteLine("Keys:");
            Console.WriteLine("\n"+"Right Arrow - move right;");
            Console.WriteLine("\n" + "Left Arrow - move Left;");
            Console.WriteLine("\n" + "Space - make shot.");
            Console.WriteLine("\n" + "Please press any key to play...");
            Console.ReadKey();
            
        
        }

        public void Render(GameObject obj)
        {
            switch (obj.Name)
            { 
                case ("Gun"):                   
                    Console.SetCursorPosition(obj.PosX-2, obj.PosY);                      
                    Console.Write("XXXXX");                                        
                break;

                case ("Bullet"):
                Console.SetCursorPosition(obj.PosX + 1, obj.PosY);
                    Console.Write("^");                     
                break;

                case ("Invader"):
                Console.SetCursorPosition(obj.PosX, obj.PosY);                   
                     Console.Write("^___^");
                break;

                case ("Field"):
                Console.SetWindowSize(obj.PosX, obj.PosY);
                Console.SetBufferSize(obj.PosX, obj.PosY);
                break;                    
            }
        
        }

        public void Show(string name, int number)
        {
            switch (name)
            {
                case ("Score"):
                    Console.SetCursorPosition(37, 2);
                    Console.Write("Score: {0}", number);
                    break;

                case ("Gun"):
                    Console.SetCursorPosition(12, 2);
                    Console.Write("Lives: {0}", number);
                    break;
            }
        }
    }
}
