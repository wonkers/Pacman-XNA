using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xna_Pac_Man
{
    class Player
    {
        public Player()
        {
            //constructor
            x = 14;
            y = 26;
            //sx = 24;
            //sy = 72;
            //oldDirection = 0;
            direction = 2;
        }
        public static void move_PacMan()
        {
            if (Player.x <= 1 && Player.y == 17 && Player.direction == 0)
            {
                Player.x = 28;
            }
            if (Player.x == 27 && Player.y == 17 && Player.direction == 2)
            {
                Player.x = 0;
            }
            if (Map.check_tile(direction, x, y))
            {
            }
            else
            {
                switch (direction)
                {
                    case 0:
                        
                        x -= 1;
                        break;
                    case 1:
                        
                        y -= 1;
                        break;
                    case 2:
                        
                        x += 1;
                        break;
                    case 3:
                        
                        y += 1;
                        break;
                }
               
            }
        }
        public static int x;
        public static int y;
        public static int direction;
      
    }
 
}
