using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.ConsoleUI
{
    class ConsoleDraw : GameObject, GameEngine.Objects.Interfaces.IRenderable
    {

        public ConsoleDraw() :base("Draw", 0, 0)
        { }


        public override void Render(string name, int x, int y)
        {
            switch (name)
            { 
                case ("Gun"):                   
                    Console.SetCursorPosition(x, y);                      
                    Console.Write("XXXX");                                        
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

    }
}
