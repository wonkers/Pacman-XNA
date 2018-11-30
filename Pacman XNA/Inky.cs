using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace xna_Pac_Man
{
    class Inky
    {
        public static int x = 11;
        public static int y = 15;

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
                    target_x = 27;
                    target_y = 35;
                    break;
                case Ghost_AI.AI_STATE.CHASE:
                    if (Player.direction == 0)
                    {
                        target_x = Player.x - 2;
                        target_y = Player.y;
                        int xvar = Math.Abs(Blinky.x - target_x);
                        int yvar = Math.Abs(Blinky.y - target_y);
                        if (Blinky.x < Player.x)
                        {
                            target_x += xvar;
                        }
                        else if (Blinky.x > Player.x)
                        {
                            target_x -= xvar;
                        }

                        if (Blinky.y < Player.y)
                        {
                            target_y += yvar;
                        }
                        else if (Blinky.y > Player.y)
                        {
                            target_y -= yvar;
                        }
                    }
                    else if (Player.direction == 1)
                    {
                        target_x = Player.x;
                        target_y = Player.y - 2;
                        int xvar = Math.Abs(Blinky.x - target_x);
                        int yvar = Math.Abs(Blinky.y - target_y);
                        if (Blinky.x < Player.x)
                        {
                            target_x += xvar;
                        }
                        else if (Blinky.x > Player.x)
                        {
                            target_x -= xvar;
                        }

                        if (Blinky.y < Player.y)
                        {
                            target_y += yvar;
                        }
                        else if (Blinky.y > Player.y)
                        {
                            target_y -= yvar;
                        }
                    }
                    else if (Player.direction == 2)
                    {
                        target_x = Player.x + 2;
                        target_y = Player.y;
                        int xvar = Math.Abs(Blinky.x - target_x);
                        int yvar = Math.Abs(Blinky.y - target_y);
                        if (Blinky.x < Player.x)
                        {
                            target_x += xvar;
                        }
                        else if (Blinky.x > Player.x)
                        {
                            target_x -= xvar;
                        }

                        if (Blinky.y < Player.y)
                        {
                            target_y += yvar;
                        }
                        else if (Blinky.y > Player.y)
                        {
                            target_y -= yvar;
                        }
                    }
                    else if (Player.direction == 3)
                    {
                        target_x = Player.x;
                        target_y = Player.y + 2;
                        int xvar = Math.Abs(Blinky.x - target_x);
                        int yvar = Math.Abs(Blinky.y - target_y);
                        if (Blinky.x < Player.x)
                        {
                            target_x += xvar;
                        }
                        else if (Blinky.x > Player.x)
                        {
                            target_x -= xvar;
                        }

                        if (Blinky.y < Player.y)
                        {
                            target_y += yvar;
                        }
                        else if (Blinky.y > Player.y)
                        {
                            target_y -= yvar;
                        }
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
                    Inky.x -= 1;
                    break;
                case 1:
                    Inky.y -= 1;
                    break;
                case 2:
                    Inky.x += 1;
                    break;
                case 3:
                    Inky.y += 1;
                    break;
            }
        }
        
    }
}
