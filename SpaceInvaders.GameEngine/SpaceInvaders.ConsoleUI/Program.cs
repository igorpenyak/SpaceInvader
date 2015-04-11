using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceInvaders.GameEngine;
using SpaceInvaders.GameEngine.Objects;
using SpaceInvaders.GameEngine.Objects.Interfaces;
using System.Threading;

namespace SpaceInvaders.ConsoleUI
{
    class Program
    {
        static bool quit = false;
        static void Main(string[] args)
        {
            MakeTick();

        }

        public static void MakeTick()
        {
            Console.Title = "Space Invaders";
            Game Playground = new Game(60, 50);  //Задаем размер игрового окна
            LazerGun gun = new LazerGun(30, 49);
            ConsoleDraw draw = new ConsoleDraw();

            List<Bullet> b_list = new List<Bullet>();
            Invader[,] i_arr=new Invader[6,3];
            SetEnemy(i_arr);
            List<GameObject> m_GameObjects = new List<GameObject>();
            m_GameObjects.Add(Playground);
            m_GameObjects.Add(gun);
            //m_GameObjects.Add(draw);
            //  m_GameObjects.Add(bull);






            Console.CursorVisible = false;

            Console.SetCursorPosition(25, 12);
            Console.WriteLine("Press any key to START!");
            long previous = getCurrentTime();
            // Console.WriteLine("{0:N0}",previous);
            long lag = 0;
            while (true)
            {

               
                //// Console.WriteLine("{0:N0}", current);
                //long elapsed = current - previous;

                //previous = current;
                //lag += elapsed;
                //   Console.WriteLine("{0:N0}", elapsed);
                //processInput();   
                
                const int TIME_LIMIT_SECONDS = 300;
                int elapsedMilliseconds = 0;
	            int totalMilliseconds = TIME_LIMIT_SECONDS * 1000;
                const int INTERVAL =100;
                
                while (elapsedMilliseconds < totalMilliseconds && !quit)
                {
                    Thread.Sleep(INTERVAL);
	                elapsedMilliseconds += INTERVAL;
                    long current = getCurrentTime();

                    foreach (var gameObject in m_GameObjects)
                    {
                        if (gameObject is IUpdateble)
                        {
                            int k = Press_Key(gameObject, b_list);

                            gameObject.Update(k);
                            Bullet.bulletBehavior(b_list,0);                                 
                                
                            }
                        }

                    for (var i = 0; i < i_arr.GetLength(0); i++)
                    {

                        for (var j = 0; j < i_arr.GetLength(1); j++)
                        {
                            i_arr[i, j].Update((int)current);

                        }

                    }  
                    
                    Console.Clear();
                    
                    foreach (var gameObject in m_GameObjects)
                        if (gameObject is IRenderable)
                        {
                            draw.Render(gameObject.Name, gameObject.PosX, gameObject.PosY);
                            if (gameObject == gun)
                            {                                                                                 
                                for (var i = 0; i < b_list.Count; i++)
                                        {                                            
                                            draw.Render(b_list[i].Name, b_list[i].PosX, b_list[i].PosY);
                                           
                                        }                                                                  
                            }
                        }
                    for (var i = 0; i < i_arr.GetLength(0); i++)
                    {

                        for (var j = 0; j < i_arr.GetLength(1); j++)
                        {
                            draw.Render(i_arr[i, j].Name, i_arr[i, j].PosX, i_arr[i, j].PosY);                                                       
                                string name;
                                int x;
                                int y;
                                if (i_arr[i, j].firstShot())
                                {
                                    i_arr[i, j].GetBullet(out name, out x, out y);
                                    draw.Render(name, x, y);
                                }
                            
                        }
                        
                    }  
                };
            }
        }


                        
        private static int Press_Key(GameObject obj, List<Bullet> blist) // transformate user`s command 
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
                       Bullet bull = new Bullet(obj.PosX, obj.PosY, true);
                       bull.InsertBull(blist);
                       return 5;
               }
               else
               {
                   return 0; 
               }       
        }                       
      
        private static long getCurrentTime()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.Ticks;
        }

        protected static ConsoleKey readKey()   // 
        {
            if (Console.KeyAvailable)               
            {               
                return Console.ReadKey(true).Key;     
            }
            return ConsoleKey.Backspace;
        }

        protected static void SetEnemy(Invader[,] arr)  // set an army of invaders
        { 
            int posx=7;            

            for(int i=0;i<arr.GetLength(0);i++)
            {
                int posy = 2;
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    Invader inv = new Invader(posx, posy,49,posx+posy);
                        arr[i,j]= inv;
                    posy+=6;
                }
                posx+=8;
            }        
        }

        

    }
}

