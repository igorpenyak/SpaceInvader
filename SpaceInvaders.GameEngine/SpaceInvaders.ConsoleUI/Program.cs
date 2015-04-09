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

            // Bullet bull = new Bullet("Bullet",31,48,true);
            List<Bullet> b_list = new List<Bullet>();
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

                //long current = getCurrentTime();
                //// Console.WriteLine("{0:N0}", current);
                //long elapsed = current - previous;

                //previous = current;
                //lag += elapsed;
                //   Console.WriteLine("{0:N0}", elapsed);
                //processInput();   
                
                const int TIME_LIMIT_SECONDS = 300;
                int elapsedMilliseconds = 0;
	            int totalMilliseconds = TIME_LIMIT_SECONDS * 1000;
                const int INTERVAL = 50;

                while (elapsedMilliseconds < totalMilliseconds && !quit)
                {
                    Thread.Sleep(INTERVAL);
	                elapsedMilliseconds += INTERVAL;
                    foreach (var gameObject in m_GameObjects)
                    {
                        if (gameObject is IUpdateble)
                        {
                            int k = Press_Key(gameObject, b_list);

                            gameObject.Update(k);
                        }
                        foreach (var b in b_list)
                        if (LazerGun.first_shot)
                        {
                            b.Move();
                        }
                    }
                    
                    Console.Clear();
                    foreach (var gameObject in m_GameObjects)
                        if (gameObject is IRenderable)
                        {

                            draw.Render(gameObject.Name, gameObject.PosX, gameObject.PosY);
                            if (gameObject == gun)
                            {
                                Check_Bullet(b_list);
                                
                                for (var i = 0; i < b_list.Count; i++)
                                    if (LazerGun.first_shot)
                                    {

                                        draw.Render(b_list[i].Name, b_list[i].PosX, b_list[i].PosY);
                                        Thread.Sleep(INTERVAL);

                                    }                               
                            }
                        }
                };
            }
        }


        private static void Check_Bullet(List<Bullet> bl)   // проверяем не пора ли удалить пулю
        {
            for (var i = 0; i < bl.Count; i++)
            {
                if (bl[i].PosY < 2)
                {
                    bl[i].RemoveBull(bl);
                }
            }
        }
                        
        private static int Press_Key(GameObject obj, List<Bullet> blist) //
        {
                     
           if (Console.KeyAvailable)               
           {
               Thread.Sleep(20);
               ConsoleKeyInfo key_info = new ConsoleKeyInfo();
               key_info = Console.ReadKey(true);
               ConsoleKey key = key_info.Key;

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
                   if (obj.Name == LazerGun.GetName())
                  {
                       Bullet bull = new Bullet(obj.PosX, obj.PosY, true);
                       //bull.h = 0;
                       bull.InsertBull(blist);
                  }
                   return 5;
               }
               else
               { return 0; }
           }
           else
           { return 0; }
        }                       
      
        private static long getCurrentTime()
        {
            DateTime currentDate = DateTime.Now;
            return currentDate.Ticks;
        }
    }}

