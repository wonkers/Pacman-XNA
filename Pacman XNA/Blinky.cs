using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xna_Pac_Man
{
    public class Blinky
    {
        public static int x = 14;
        public static int y = 13;
        
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
                    target_x = 25;
                    target_y = 0;
                    break;
                case Ghost_AI.AI_STATE.CHASE:
                    target_x = Player.x;
                    target_y = Player.y;
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
                    Blinky.x -= 1;
                    break;
                case 1:
                    Blinky.y -= 1;
                    break;
                case 2:
                    Blinky.x += 1;
                    break;
                case 3:
                    Blinky.y += 1;
                    break;
            } 
        }
    }
}
