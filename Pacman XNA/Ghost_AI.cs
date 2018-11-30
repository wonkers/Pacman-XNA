namespace xna_Pac_Man
{    
    public class Ghost_AI
    {
        public int timer;

        public enum AI_STATE
        {
            SCATTER,    //head to the ghosts allocated corner
            CHASE,      //chase pac man
            FRIGHTENED,  //change direction and slow down, with random turns
        }
        public AI_STATE ai_state = AI_STATE.SCATTER;
        public void time()
        {
            timer++;
            if (ai_state != AI_STATE.FRIGHTENED)
            {
                if (timer == 800)
                {
                    ai_state = AI_STATE.CHASE;
                    reverseDirection();

                }
                if (timer == 2000)
                {
                    ai_state = AI_STATE.SCATTER;
                    reverseDirection();
                    timer = 0;
                }
            }
            else
            {
                //frightened.
            }
           
        }
        public void reverseDirection()
        {
            if (Blinky.direction == 0) Blinky.direction = 2;
            else if (Blinky.direction == 1) Blinky.direction = 3;
            else if (Blinky.direction == 2) Blinky.direction = 0;
            else if (Blinky.direction == 3) Blinky.direction = 1;

            if (Inky.direction == 0) Inky.direction = 2;
            else if (Inky.direction == 1) Inky.direction = 3;
            else if (Inky.direction == 2) Inky.direction = 0;
            else if (Inky.direction == 3) Inky.direction = 1;

            if (Pinky.direction == 0) Pinky.direction = 2;
            else if (Pinky.direction == 1) Pinky.direction = 3;
            else if (Pinky.direction == 2) Pinky.direction = 0;
            else if (Pinky.direction == 3) Pinky.direction = 1;

            if (Clyde.direction == 0) Clyde.direction = 2;
            else if (Clyde.direction == 1) Clyde.direction = 3;
            else if (Clyde.direction == 2) Clyde.direction = 0;
            else if (Clyde.direction == 3) Clyde.direction = 1;

        }
        public void move_Ghosts()
        {
            Blinky.find_target(ai_state);
            Pinky.find_target(ai_state);
            Inky.find_target(ai_state);
            Clyde.find_target(ai_state);

            //from one side to the other***********************************************************************
            //*************************************BLINKY******************************************************
            if (Blinky.x == 0 && Blinky.y == 17 && Blinky.direction == 0)
            {
                Blinky.x = 28;
            }
            if (Blinky.x == 27 && Blinky.y == 17 && Blinky.direction == 2)
            {
                Blinky.x = 0;
            }

            if (Map.intersections[Blinky.x, Blinky.y])
            {
                Blinky.direction = check_intersections(Blinky.x, Blinky.y, Blinky.target_x,Blinky.target_y, Blinky.direction);
            }
            else
            {
                Blinky.direction = check_walls(Blinky.x, Blinky.y, Blinky.target_x, Blinky.target_y, Blinky.direction);
            }

            
            /***********************************************************************************************
             * *******************************PINKY***************************************************/
            if (Pinky.x == 0 && Pinky.y == 17 && Pinky.direction == 0)
            {
                Pinky.x = 28;
            }
            if (Pinky.x == 27 && Pinky.y == 17 && Pinky.direction == 2)
            {
                Pinky.x = 0;
            }

            if (Map.intersections[Pinky.x, Pinky.y])
            {
                Pinky.direction = check_intersections(Pinky.x, Pinky.y, Pinky.target_x, Pinky.target_y, Pinky.direction);

            }
            else
            {
                Pinky.direction = check_walls(Pinky.x, Pinky.y, Pinky.target_x, Pinky.target_y, Pinky.direction);
            }
            
            //from one side to the other***********************************************************************
            //*************************************INKY******************************************************
            if (Inky.x == 0 && Inky.y == 17 && Inky.direction == 0)
            {
                Inky.x = 28;
            }
            if (Inky.x == 27 && Inky.y == 17 && Inky.direction == 2)
            {
                Inky.x = 0;
            }

            if (Map.intersections[Inky.x, Inky.y])
            {
                Inky.direction = check_intersections(Inky.x, Inky.y, Inky.target_x, Inky.target_y, Inky.direction);
            }
            else
            {
                Inky.direction = check_walls(Inky.x, Inky.y, Inky.target_x, Inky.target_y, Inky.direction);
            }

           
            //from one side to the other***********************************************************************
            //*************************************CLYDE******************************************************
            if (Clyde.x == 0 && Clyde.y == 17 && Clyde.direction == 0)
            {
                Clyde.x = 28;
            }
            if (Clyde.x == 27 && Clyde.y == 17 && Clyde.direction == 2)
            {
                Clyde.x = 0;
            }

            if (Map.intersections[Clyde.x, Clyde.y])
            {
                Clyde.direction = check_intersections(Clyde.x, Clyde.y, Clyde.target_x, Clyde.target_y, Clyde.direction);
            }
            else
            {
                Clyde.direction = check_walls(Clyde.x, Clyde.y, Clyde.target_x, Clyde.target_y, Clyde.direction);
            }

            Blinky.move(Blinky.direction);
            Pinky.move(Pinky.direction);
            Inky.move(Inky.direction);
            Clyde.move(Clyde.direction);
        
        }
        int check_walls(int x, int y, int tx, int ty, int dir)
        {
            //Check for collision with wall.
            if (Map.check_tile(dir, x, y))
            {

                if (Map.check_tile(1, x, y))
                {
                    if (Map.check_tile(0, x, y))
                    {
                        if (Map.check_tile(3, x, y))
                        {
                            if (Map.check_tile(2, x, y))
                            {
                            }
                            else
                            {
                                if (dir != 0)
                                {
                                    dir = 2;
                                }
                                else
                                {
                                    if (Map.check_tile(1, x, y))
                                    {
                                        dir = 0;
                                    }
                                    else
                                    {
                                    dir = 1;
                                    }
                                    
                                }
                            }
                        }
                        else
                        {
                            if (dir != 1)
                            {
                                dir = 3;
                            }
                            else
                            {
                                if (Map.check_tile(0, x, y))
                                {
                                    if (dir != 1) dir = 3;
                                    else dir = 2;
                                }
                                else
                                {
                                    dir = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (dir != 2)
                        {
                            dir = 0;
                        }
                        else
                        {
                            if (Map.check_tile(1, x, y))
                            {
                                if (dir != 2) dir = 0;
                                else dir = 3;
                            }
                            else
                            {
                                dir = 1;
                            }
                        }
                    }
                }
                else
                {
                    if (dir != 3)
                    {
                        dir = 1;
                    }
                    else
                    {
                        if (Map.check_tile(0, x, y))
                        {
                            dir = 2;
                        }
                        else
                        {
                            dir = 0;
                        }
                       
                    }
                }
            }
            return dir; 
        }
        public static int check_distance(int x, int y, int tx, int ty, int dir)
        {
            int dist = 0;
            if (dir == 0) x -= 1;
            else if (dir == 1) y -= 1;
            else if (dir == 2) x += 1;
            else if (dir == 3) y += 1;
           
            do
            {
                if (x < tx)
                {
                    x++;
                    dist++;
                }
                else if (tx < x)
                {
                    x--;
                    dist++;
                }
                if (y < ty)
                {
                    y++;
                    dist++;
                }
                else if (y > ty)
                {
                    y--;
                    dist++;
                }

            } while (x != tx && x != ty);
            return dist;
        }
        public int check_intersections(int x, int y, int tx, int ty, int dir)
        {
            int op1, op2, op3;
            //check if they are on an intersection and redirect
            if (dir == 1)
            {
                op1 = check_distance(x, y, tx, ty, 0);
                op2 = check_distance(x, y, tx, ty, 2);
                op3 = check_distance(x, y, tx, ty, 1);

                if (op1 < op2 && op1 < op3)
                {
                    if (Map.check_tile(0, x, y))
                    {
                        if (x > tx)
                        {
                            if (Map.check_tile(1, x, y)) dir = 2;
                            else dir = 1;
                        }
                        else
                        {
                            if (Map.check_tile(2, x, y)) dir = 1;
                            else dir = 2;
                        }
                        
                    }
                    else dir = 0;
                }
                else if (op2 < op1 && op2 < op3)
                {
                    if (Map.check_tile(2, x, y))
                    {
                        if (Map.check_tile(1, x, y)) dir = 0;
                        else dir = 1;
                    }
                    else dir = 2;
                }
                else if (op3 < op1 && op3 < op2)
                {
                    if (Map.check_tile(1, x, y))
                    {
                        if (x < tx)
                        {
                            if (Map.check_tile(2, x, y)) dir = 0;
                            else dir = 2;
                        }
                        else
                        {
                            if (Map.check_tile(0, x, y)) dir = 2;
                            else dir = 0;
                        }
                        
                    }
                    else dir = 1;
                }
                else
                {
                    if (x > tx)
                    {
                        if (Map.check_tile(1, x, y))
                        {
                            if (Map.check_tile(0, x, y)) dir = 2;
                            else dir = 0;
                        }
                        else dir = 1;
                    }
                    else
                    {
                        if (Map.check_tile(1, x, y))
                        {
                            if (Map.check_tile(2, x, y)) dir = 0;
                            else dir = 2;
                        }
                        else dir = 1;
                    }
                }


            }
            else if (dir == 2)
            {
                op1 = check_distance(x, y, tx, ty, 1);
                op2 = check_distance(x, y, tx, ty, 2);
                op3 = check_distance(x, y, tx, ty, 3);

                if (op1 < op2 && op2 < op3)
                {
                    if (Map.check_tile(1, x, y))
                    {
                        if (Map.check_tile(2, x, y)) dir = 3;
                        else dir = 2;
                    }
                    else dir = 1;

                }
                else if (op2 < op1 && op2 < op3)
                {
                    if (Map.check_tile(2, x, y))
                    {
                        if (y > ty)
                        {
                            if (Map.check_tile(1, x, y)) dir = 3;
                            else dir = 1;
                        }
                        else
                        {
                            if (Map.check_tile(3, x, y)) dir = 1;
                            else dir = 3;
                        }
                    }
                    else dir = 2;
                }
                else if (op3 < op1 && op3 < op2)
                {
                    if (Map.check_tile(3, x, y))
                    {
                        if (x > tx)
                        {
                            if (Map.check_tile(1, x, y)) dir = 2;
                            else dir = 1;
                        }
                        else
                        {
                            if (Map.check_tile(2, x, y)) dir = 1;
                            else dir = 2;
                        }
                        
                    }
                    else dir = 3;
                }
                else
                {
                    if (y > ty)
                    {
                        if (Map.check_tile(1, x, y))
                        {
                            if (Map.check_tile(3, x, y)) dir = 2;
                            else dir = 3;
                        }
                        else dir = 1;
                    }
                    else
                    {
                        if (Map.check_tile(3, x, y))
                        {
                            if (Map.check_tile(2, x, y)) dir = 1;
                            else dir = 2;
                        }
                        else dir = 3;
                    }
                }
            }
            else if (dir == 3)
            {

                op1 = check_distance(x, y, tx, ty, 0);
                op2 = check_distance(x, y, tx, ty, 2);
                op3 = check_distance(x, y, tx, ty, 3);

                if (op1 < op2 && op1 < op3)
                {
                    if (Map.check_tile(0, x, y))
                    {
                        if (Map.check_tile(3, x, y))dir = 2;
                        else dir = 3;
                    }
                    else dir = 0;
                }
                else if (op2 < op1 && op2 < op3)
                {
                    if (Map.check_tile(2, x, y))
                    {
                        if (Map.check_tile(3, x, y)) dir = 0;
                        else dir = 3;
                    }
                    else dir = 2;
                }
                else if (op3 < op1 && op3 < op2)
                {
                    if (Map.check_tile(3, x, y))
                    {
                        if (x < tx)
                        {
                            
                        }
                        else
                        {
                            if (Map.check_tile(0, x, y)) dir = 1;
                            else dir = 0;
                        }
                    }
                    else dir = 3;
                }
                else
                {
                    if (x > tx)
                    {
                        if (Map.check_tile(0, x, y))
                        {
                            if (Map.check_tile(3, x, y)) dir = 2;
                            else dir = 3;
                        }
                        else dir = 0;
                    }
                    else
                    {
                        if (Map.check_tile(2, x, y))
                        {
                            if (Map.check_tile(3, x, y)) dir = 0;
                            
                            else dir = 3;
                        }
                        else dir = 2;
                    }
                }
            }
            else if (dir == 0)
            {
                op1 = check_distance(x, y, tx, ty, 0);
                op2 = check_distance(x, y, tx, ty, 1);
                op3 = check_distance(x, y, tx, ty, 3);
                
                if (op1 < op2 && op1 < op3 ||op1 == 0)
                {
                    if (Map.check_tile(0, x, y))
                    {
                        if (y < ty)
                        {
                            if (Map.check_tile(3, x, y)) dir = 1;
                            else dir = 3;
                        }
                        else
                        {
                            if (Map.check_tile(1, x, y)) dir = 3;
                            else dir = 1;
                        }
                    }
                    else dir = 0;  
                }
                else if (op2 < op1 && op2 < op3 || op2 == 0)
                {
                    if (Map.check_tile(1, x, y))
                    {
                        if (Map.check_tile(0, x, y)) dir = 3;
                        else dir = 0;
                    }
                    else dir = 1;
                }
                else if (op3 < op1 && op3 < op2 || op3 == 0)
                {
                    if (Map.check_tile(3, x, y))
                    {
                        if (y < ty)
                        {
                            if (Map.check_tile(1, x, y)) dir = 0;
                            else dir = 1;
                        }
                        else
                        {
                            if (Map.check_tile(0, x, y)) dir = 1;
                            dir = 0;
                        }
                    }
                    else dir = 3;
                }
                else
                {
                    if (y > ty)
                    {
                        if (Map.check_tile(1, x, y))
                        {
                            if (Map.check_tile(0, x, y)) dir = 3;
                            else dir = 0;
                        }
                        else dir = 1;
                    }
                    else
                    {
                        if (Map.check_tile(3, x, y))
                        {
                            if (Map.check_tile(0, x, y)) dir = 1;
                            else dir = 0;
                        }
                        else dir = 3;
                    }
                }
            }
            return dir;
        }
        
    }
}
