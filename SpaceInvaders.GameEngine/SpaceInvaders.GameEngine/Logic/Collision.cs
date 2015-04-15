using SpaceInvaders.GameEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceInvaders.GameEngine
{
   public class Collision
    {
        public static void FindCollision(Process game)
        {
            for (var i = 0; i < game.i_arr.GetLength(0); i++)
            {
                for (var j = game.i_arr.GetLength(1)-1; j >= 0; j--)
                {
                    if (game.i_arr[i, j].Live)
                    {
                        for (int b = 0; b < game.b_list.Count; b++)
                        {
                        
                            if (isCollision(game.i_arr[i, j], game.b_list[b]))  // when LazerGun kill an Invader
                            {                                                              
                                game.b_list.Remove(game.b_list[b]);
                                game.i_arr[i, j].Live = false;
                                if (j == 2)
                                {
                                    game.UpdScore(50); 
                                }
                                else if (j == 1)
                                {
                                    game.UpdScore(70);
                                }
                                else
                                {
                                    game.UpdScore(100);
                                }
                            }                           
                        }


                        if (InvaderWin(game.i_arr[i, j], game.m_GameObjects[1]))  // when Invader win
                        {
                            game.m_GameObjects[1].Live=false;
                        }


                        if (game.i_arr[i, j].enem_bullet.Count != 0)
                        {
                           
                                if (isCollision(game.i_arr[i, j].enem_bullet[0], game.m_GameObjects[1]))
                                {
                                    game.m_GameObjects[1].isDie();
                                }
                        }                        
                    }
                }
            }            
        }

        #region Static Methods
        public static bool isCollision(GameObject striker, GameObject receiver)
        {
            return ((findDistance(striker, receiver)) <= 0);
        }

        public static double findDistance(GameObject obj1, GameObject obj2)
        {
            if (obj1.PosX-1 <= obj2.PosX && obj1.PosX + 4 >= obj2.PosX)
            {
                return obj2.PosY - obj1.PosY;
            }
            return 1.0;
        }
        public static bool InvaderWin(GameObject obj1, GameObject obj2)
        {
            int k=obj2.PosY - obj1.PosY;
            if (k <= 1)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}
