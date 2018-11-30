using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace xna_Pac_Man
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        SpriteFont font;

        public Ghost_AI ghost = new Ghost_AI();
        Player PacMan = new Player();

        Texture2D BlinkyImage, PacManImage1, PinkyImage, InkyImage, ClydeImage, PacManImage2, PacManImage, PellotImage, PowerPellotImage;
        Rectangle PacManTile = new Rectangle();
        Texture2D BackgroundImage;
        Rectangle BackgroundTile = new Rectangle();

        /* oh crap - need this file. it's the map*/
         /*StreamReader SR = new StreamReader("C:/Users/e_duc/OneDrive/Documents/Visual Studio 2017/Projects/Game2/Map.txt");*/
         
        Map map = new Map();
        int timer = 0;
        const int TILE_SIZE = 16;

        float RotationAngle;
        public int score;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            PacManTile.Height = TILE_SIZE * 2;
            PacManTile.Width = TILE_SIZE * 2;

            BackgroundTile.Width = 448;
            BackgroundTile.Height = 576;

            graphics.PreferredBackBufferHeight = 576;
            graphics.PreferredBackBufferWidth = 448;
            graphics.ApplyChanges();


           Map.intersections[6, 4] = true;
            Map.intersections[21, 4] = true;
            Map.intersections[1, 8] = true;
            Map.intersections[6, 8] = true;
            Map.intersections[9, 8] = true;
            Map.intersections[12, 8] = true;
            Map.intersections[15, 8] = true;
            Map.intersections[18, 8] = true;
            Map.intersections[21, 8] = true;
            Map.intersections[26, 8] = true;
            Map.intersections[6, 11] = true;
            Map.intersections[21, 11] = true;
            Map.intersections[6, 17] = true;
            Map.intersections[9, 17] = true;
            Map.intersections[18, 17] = true;
            Map.intersections[21, 17] = true;
            Map.intersections[9, 20] = true;
            Map.intersections[18, 20] = true;
            Map.intersections[6, 23] = true;
            Map.intersections[9, 23] = true;
            Map.intersections[18, 23] = true;
            Map.intersections[21, 23] = true;
            Map.intersections[6, 26] = true;
            Map.intersections[9, 26] = true;
            Map.intersections[18, 26] = true;
            Map.intersections[21, 26] = true;
            Map.intersections[3, 29] = true;
            Map.intersections[24, 29] = true;
            Map.intersections[12, 32] = true;
            Map.intersections[15, 32] = true;
            /*Map.intersections[1,8] = true;
            Map.intersections[6, 8] = true;
            Map.intersections[6, 11] = true;
            Map.intersections[6, 17] = true;
            Map.intersections[6, 23] = true;
            Map.intersections[6, 26] = true;
            Map.intersections[9, 8] = true;
            Map.intersections[9, 17] = true;
            Map.intersections[9, 23] = true;
            Map.intersections[9, 26] = true;
            Map.intersections[12, 8] = true;
            Map.intersections[12, 14] = true;
            Map.intersections[12, 26] = true;
            Map.intersections[12, 32] = true;
            Map.intersections[15, 8] = true;
            Map.intersections[15, 14] = true;
            Map.intersections[15, 26] = true;
            Map.intersections[15, 32] = true;
            Map.intersections[18, 8] = true;
            Map.intersections[18, 17] = true;
            Map.intersections[18, 23] = true;
            Map.intersections[18, 26] = true;
            Map.intersections[21, 8] = true;
            Map.intersections[21, 11] = true;
            Map.intersections[21, 17] = true;
            Map.intersections[21, 23] = true;
            Map.intersections[21, 26] = true;
            Map.intersections[21, 8] = true;
            Map.intersections[26, 8] = true;
            Map.intersections[3, 26] = true;
            Map.intersections[24, 29] = true;*/


            base.Initialize();
        }


        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = Content.Load<SpriteFont>("Ariel");
          

            BlinkyImage = Content.Load<Texture2D>("Blinky");
            PinkyImage = Content.Load<Texture2D>("Pinky");
            InkyImage = Content.Load<Texture2D>("Inky");
            ClydeImage = Content.Load<Texture2D>("Clyde");

            PacManImage2 = Content.Load<Texture2D>("PacMan");
            PacManImage1 = Content.Load<Texture2D>("PacManClosed");
            PacManImage = Content.Load<Texture2D>("PacManClosed");

            PellotImage = Content.Load<Texture2D>("Pellot");
            PowerPellotImage = Content.Load<Texture2D>("PowerPellot");

            BackgroundImage = Content.Load<Texture2D>("PacMan Grid");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (Map.check_tile(3, Player.x, Player.y))
                {
                }
                else
                {
                    Player.direction = 3;
                    RotationAngle = 1.55f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {

                if (Map.check_tile(1, Player.x, Player.y))
                {
                }
                else
                {
                    Player.direction = 1;
                    RotationAngle = -1.55f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (Map.check_tile(2, Player.x, Player.y))
                {

                }
                else
                {
                    Player.direction = 2;
                    RotationAngle = 0.0f;
                }
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {

                if (Map.check_tile(0, Player.x, Player.y))
                {
                }
                else
                {
                    Player.direction = 0;
                    RotationAngle = -3.15f;
                }
            }

            // TODO: Add your update logic here

            timer +=1;
            ghost.time();
            if (timer == 6)
            {
                Player.move_PacMan();
            }
            else if (timer == 8)
            {
                ghost.move_Ghosts();
                PacManImage = PacManImage2;
            }
            else if (timer == 12)
            {
                Player.move_PacMan();
            }
            else if (timer == 16)
            {
                ghost.move_Ghosts();
                PacManImage = PacManImage1;
            }
            else if (timer == 18)
            {
                Player.move_PacMan();
            }
            else if (timer == 24)
            {
                Player.move_PacMan();
                ghost.move_Ghosts();
                PacManImage = PacManImage2;
                timer = 0;
            }


            if (Map.tiles[Player.x, Player.y] == 0)
            {
                score += 10;

                Map.tiles[Player.x, Player.y] = 2;
            }
            if (Map.tiles[Player.x, Player.y] == 50)
            {
                ghost.reverseDirection();
                /*ghost.ai_state = Ghost_AI.AI_STATE.FRIGHTENED;*/
                Map.tiles[Player.x, Player.y] = 2;
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            Vector2 bill = new Vector2((Blinky.x * TILE_SIZE) - 8, (Blinky.y * TILE_SIZE) - 8);
            Vector2 pinky = new Vector2((Pinky.x * TILE_SIZE) - 8, (Pinky.y * TILE_SIZE) - 8);
            Vector2 inky = new Vector2((Inky.x * TILE_SIZE) - 8, (Inky.y * TILE_SIZE) - 8);
            Vector2 clyde = new Vector2((Clyde.x * TILE_SIZE) - 8, (Clyde.y * TILE_SIZE) - 8);

            PacManTile.X = (Player.x * TILE_SIZE) + 8;
            PacManTile.Y = (Player.y * TILE_SIZE) + 8;

            Vector2 background = new Vector2(0, 0);
            //draw background/map
            spriteBatch.Draw(BackgroundImage, background, Color.White);
            //draw pellots
            for (int row = 0; row < 28; row++)
            {
                for (int col = 0; col < 36; col++)
                {
                    if (Map.tiles[row, col] == 0)
                    {
                        spriteBatch.Draw(PellotImage, new Vector2((row * TILE_SIZE) - 6, (col * TILE_SIZE) - 8), Color.White);
                    }
                    else if (Map.tiles[row, col] == 50)
                    {
                        spriteBatch.Draw(PowerPellotImage, new Vector2((row * TILE_SIZE) - 6, (col * TILE_SIZE) - 8), Color.White);
                    }
                    else if(Map.tiles[row, col] == 2)
                    {
                        
                    }
                }
            }

            //draw pacman            
            spriteBatch.Draw(PacManImage, PacManTile, null, Color.White, RotationAngle, new Vector2(16, 16), SpriteEffects.None, 0.0f);
            //draw the 4 ghosts
            spriteBatch.Draw(BlinkyImage, bill, Color.White);
            spriteBatch.Draw(PinkyImage, pinky, Color.White);
            spriteBatch.Draw(InkyImage, inky, Color.White);
            spriteBatch.Draw(ClydeImage, clyde, Color.White);

            spriteBatch.DrawString(font, "" + score, new Vector2((5 * TILE_SIZE), (1 * TILE_SIZE)), Color.White);
            //spriteBatch.DrawString(font, "" + Player.sx, new Vector2((10 * TILE_SIZE), (0 * TILE_SIZE)), Color.White);
            //spriteBatch.DrawString(font, "" + Player.sy, new Vector2((10 * TILE_SIZE), (1 * TILE_SIZE)), Color.White);

            //spriteBatch.DrawString(font, "" + Player.x, new Vector2((14 * TILE_SIZE), (0 * TILE_SIZE)), Color.White);
            //spriteBatch.DrawString(font, "" + Player.y, new Vector2((14 * TILE_SIZE), (1 * TILE_SIZE)), Color.White);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
