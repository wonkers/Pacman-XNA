using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xna_Pac_Man
{
    class Pinky
    {
        public static int x = 13;
        public static int y = 14;

        public static int speed = 1;
        public static int direction = 0;

        public static int target_x;
        public static int target_y;

        //only accessable from within the Ghost AI class.(I think)
        public static void find_target(Ghost_AI.AI_STATE ai_state)
        {

            switch (ai_state)
            {
                case Ghost_AI.AI_STATE.SCATTER:
                    target_x = 2;
                    target_y = 0;
                    break;
                case Ghost_AI.AI_STATE.CHASE:
                    if (Player.direction == 0)
                    {
                        target_x = Player.x - 4;
                        target_y = Player.y;
                    }
                    else if (Player.direction == 1)
                    {
                        target_x = Player.x;
                        target_y = Player.y - 4;
                    }
                    else if (Player.direction == 2)
                    {
                        target_x = Player.x + 4;
                        target_y = Player.y;
                    }
                    else if (Player.direction == 3)
                    {
                        target_x = Player.x;
                        target_y = Player.y + 4;
                    }
                    break;
                case Ghost_AI.AI_STATE.FRIGHTENED:
                    break;
            }

        }
        public static void move(int dir)
        {

            switch (dir)
            {
                case 0:
                    Pinky.x -= 1;
                    break;
                case 1:
                    Pinky.y -= 1;
                    break;
                case 2:
                    Pinky.x += 1;
                    break;
                case 3:
                    Pinky.y += 1;
                    break;
            }
        }
        void function()
        {
        
        }

          
    }
}
