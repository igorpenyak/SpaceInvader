using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.ConsoleUI
{
    class ConsoleDraw : GameObject, GameEngine.Objects.Interfaces.IRenderable, GameEngine.Objects.Interfaces.ISettings
    {

        public ConsoleDraw() :base("Draw", 0, 0)
        { }


        public override void Render(string name, int x, int y)
        {
            switch (name)
            { 
                case ("Gun"):                   
                    Console.SetCursorPosition(x, y);                      
                    Console.Write("XXX");                                        
                break;

                case ("Bullet"):                                      
                    Console.SetCursorPosition(x+1, y);
                    Console.Write("^");                     
                break;

                case ("Invader"):
                     Console.SetCursorPosition(x, y);                   
                     Console.Write("^___^");
                break;

                case ("Shield"):
                Console.SetCursorPosition(x, y);
                Console.WriteLine("Build a shield!");
                break;

                case ("Field"):                 
                    Console.SetWindowSize(x, y);
                    Console.SetBufferSize(x, y);
                break;
                    
            }
        
        }

        public override void Show(string name, int number)
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
