using System;
using System.IO;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Diagnostics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using Microsoft.Xna.Framework.Media;

namespace WindowsPhoneGame1
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {


        Microphone microphone = Microphone.Default;
        byte[] buffer;
        int i;
        int score=0;
        int flag = 0;
        int lives=5;
        private int minimumThreshold = 5000;

        SpriteFont spFont;
        SpriteBatch spBatch;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // This is a texture we can render.
        Texture2D myTexture;
        Texture2D myCoin;
        Texture2D myObstacle1;
        Texture2D myObstacle2;
        Texture2D myObstacle3;
        Texture2D myObstacle4;
        Texture2D myObstacle5;
        Texture2D myObstacle6;
        Texture2D myObstacle7;
        Texture2D myObstacle8;
        Texture2D myObstacle9;
        Texture2D myObstacle10;
        Texture2D end_ribbon;

        int coinlist1_passed=0;
        int coinlist2_passed=0;
        int coinlist3_passed=0;

        Texture2D[] coinlist1= new Texture2D[16];
        Texture2D[] coinlist2 = new Texture2D[8];
        Texture2D[] coinlist3 = new Texture2D[6];
        Texture2D[] coinlist4 = new Texture2D[8];
        Texture2D[] coinlist5 = new Texture2D[16];
        Texture2D[] coinlist6 = new Texture2D[7];
        Texture2D obstacle1;
        Texture2D obstacle2;
        Texture2D obstacle3;
        Texture2D obstacle4;
        Texture2D obstacle5;
        Texture2D obstacle6;
        Texture2D obstacle7;
        Texture2D obstacle8;
        Texture2D obstacle9;
        Texture2D obstacle10;

        Vector2[] coinlist1_position = new Vector2[]
        {
        new Vector2(400f, 200f),
        new Vector2(400f, 230f),
        new Vector2(400f, 260f),
        new Vector2(400f, 290f),
        new Vector2(440f, 200f),
        new Vector2(440f, 230f),
        new Vector2(440f, 260f),
        new Vector2(440f, 290f),
        new Vector2(480f, 200f),
        new Vector2(480f, 230f),
        new Vector2(480f, 260f),
        new Vector2(480f, 290f),
        new Vector2(520f, 200f),
        new Vector2(520f, 230f),
        new Vector2(520f, 260f),
        new Vector2(520f, 290f)
        };
        
        Vector2[] coinlist2_position = new Vector2[]
        {
        new Vector2(800f, 240f),
        new Vector2(800f, 270f),
        new Vector2(840f, 240f),
        new Vector2(840f, 270f),
        new Vector2(880f, 240f),
        new Vector2(880f, 270f),
        new Vector2(920f, 240f),
        new Vector2(920f, 270f)
        };

        Vector2[] coinlist3_position = new Vector2[]
        {
        new Vector2(1150f, 360f),
        new Vector2(1150f, 390f),
        new Vector2(1190f, 360f),
        new Vector2(1190f, 390f),
        new Vector2(1230f, 360f),
        new Vector2(1230f, 390f)
        };

        Vector2[] coinlist4_position = new Vector2[]
        {
        new Vector2(1300f, 240f),
        new Vector2(1300f, 270f),
        new Vector2(1340f, 240f),
        new Vector2(1340f, 270f),
        new Vector2(1380f, 240f),
        new Vector2(1380f, 270f),
        new Vector2(1420f, 240f),
        new Vector2(1420f, 270f)
        };

        Vector2[] coinlist5_position = new Vector2[]
        {
        new Vector2(1560f, 300f),
        new Vector2(1560f, 330f),
        new Vector2(1560f, 360f),
        new Vector2(1560f, 390f),
        new Vector2(1600f, 300f),
        new Vector2(1600f, 330f),
        new Vector2(1600f, 360f),
        new Vector2(1600f, 390f),
        new Vector2(1640f, 300f),
        new Vector2(1640f, 330f),
        new Vector2(1640f, 360f),
        new Vector2(1640f, 390f),
        new Vector2(1680f, 300f),
        new Vector2(1680f, 330f),
        new Vector2(1680f, 360f),
        new Vector2(1680f, 390f)
        };

        Vector2[] coinlist6_position = new Vector2[]
        {
        new Vector2(1800f, 400f),
        new Vector2(1850f, 350f),
        new Vector2(1900f, 300f),
        new Vector2(1950f, 250f),
        new Vector2(2000f, 300f),
        new Vector2(2050f, 350f),
        new Vector2(2100f, 400f)
        };

        // Set the coordinates to draw the obstacles at.
        Vector2 obstacle1_pos = new Vector2(500f, 380f);
        Vector2 obstacle2_pos = new Vector2(600f, 260f);
        Vector2 obstacle3_pos = new Vector2(900f, 320f);
        Vector2 obstacle4_pos = new Vector2(1050f, 100f);
        Vector2 obstacle5_pos = new Vector2(1100f, 400f);
        Vector2 obstacle6_pos = new Vector2(1350f, 300f);
        Vector2 obstacle7_pos = new Vector2(1500f, 250f);
        Vector2 obstacle8_pos = new Vector2(1720f, 360f);
        Vector2 obstacle9_pos = new Vector2(2300f, 100f);
        Vector2 obstacle10_pos = new Vector2(2300f, 350f);

        Vector2 end_ribbon_pos = new Vector2(3000f, 0f);

        // Set the coordinates to draw the sprite at.
        Vector2 spritePosition = new Vector2(40f,35f) ;
        Vector2 coinPosition = Vector2.Zero;

        Vector2[] coinlist1_speed = new Vector2[]
        {
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f)
        };


        Vector2[] coinlist2_speed = new Vector2[]
        {
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f)
        };

        Vector2[] coinlist3_speed = new Vector2[]
        {
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f)
        };

        Vector2[] coinlist5_speed = new Vector2[]
        {
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f)
        };

        Vector2[] coinlist4_speed = new Vector2[]
        {
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f)
        };

        Vector2[] coinlist6_speed = new Vector2[]
        {
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f),
        new Vector2(50.0f, 50.0f)
        };

        // Store some information about the obstacle's motion.
        Vector2 obstacle1_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle2_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle3_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle4_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle5_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle6_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle7_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle8_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle9_speed = new Vector2(50.0f, 50.0f);
        Vector2 obstacle10_speed = new Vector2(50.0f, 50.0f);
        Vector2 end_ribbon_speed = new Vector2(50.0f, 50.0f);

        // Store some information about the sprite's motion.
        Vector2 spriteSpeed = new Vector2(50.0f, 50.0f);
        Vector2 coinSpeed = new Vector2(50.0f, 50.0f);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Frame rate is 30 fps by default for Windows Phone.
            TargetElapsedTime = TimeSpan.FromTicks(333333);

            // Extend battery life under lock.
            InactiveSleepTime = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            
            DispatcherTimer dt = new DispatcherTimer();

            dt.Interval = TimeSpan.FromMilliseconds(50);
            dt.Tick += delegate { try { FrameworkDispatcher.Update(); } catch { } };
            dt.Start();
            microphone.BufferReady += microphone_BufferReady;
            //coinPosition_init();
            startmicrophone();

            base.Initialize();
        }
        void coinPosition_init()
        {
            coinPosition.X = graphics.GraphicsDevice.Viewport.Height*2;

            for (i = 0; i < 8; i++)
            {
                coinlist1_position[i].X = graphics.GraphicsDevice.Viewport.Height * 3;
            }
            for (i = 0; i < 8; i++)
            {
                coinlist2_position[i].X = graphics.GraphicsDevice.Viewport.Height * 4;
            }

        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            myTexture = Content.Load<Texture2D>("copter");
            myCoin = Content.Load<Texture2D>("coin");
            myObstacle1 = Content.Load<Texture2D>("fire_obs");
            myObstacle2 = Content.Load<Texture2D>("fire_obs");
            myObstacle3 = Content.Load<Texture2D>("fire_obs");
            myObstacle4 = Content.Load<Texture2D>("fire_obs");
            myObstacle5 = Content.Load<Texture2D>("fire_obs");
            myObstacle6 = Content.Load<Texture2D>("fire_obs");
            myObstacle7 = Content.Load<Texture2D>("fire_obs");
            myObstacle8 = Content.Load<Texture2D>("fire_obs");
            myObstacle9 = Content.Load<Texture2D>("fire_obs");
            myObstacle10 = Content.Load<Texture2D>("fire_obs");
            end_ribbon = Content.Load<Texture2D>("ribbon");

            load_first_coinlist();
            load_second_coinlist();
            load_third_coinlist();
            load_fourth_coinlist();
            load_fifth_coinlist();
            load_sixth_coinlist();
            // TODO: use this.Content to load your game content here
        }

        void load_first_coinlist()
        {
            for (i=0; i<16;i++)
            {
                coinlist1[i] = Content.Load<Texture2D>("coin");
            }
        }
        void load_second_coinlist()
        {
            for (i=0; i<8;i++)
            {
                coinlist2[i] = Content.Load<Texture2D>("coin");
            }
        }
        void load_third_coinlist()
        {
            for (i = 0; i < 6; i++)
            {
                coinlist3[i] = Content.Load<Texture2D>("coin");
            }
        }
        void load_fourth_coinlist()
        {
            for (i = 0; i < 8; i++)
            {
                coinlist4[i] = Content.Load<Texture2D>("coin");
            }
        }
        void load_fifth_coinlist()
        {
            for (i = 0; i < 16; i++)
            {
                coinlist5[i] = Content.Load<Texture2D>("coin");
            }
        }
        void load_sixth_coinlist()
        {
            for (i = 0; i < 7; i++)
            {
                coinlist6[i] = Content.Load<Texture2D>("coin");
            }
        }
        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
        /// 
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            

            
            UpdateSprite(gameTime);
            //check_oldobjects();
            //intro_new_coinlist();             // find the code to unload/invisible/delete/whatever
            check_collision();
            coin_position_update(gameTime);
            base.Update(gameTime);

        }

        void check_collision()
        {
            //Debug.WriteLine(spritePosition.X + myTexture.Width + "and coin porion"+ coinPosition.X+" and y is " + spritePosition.Y +"\n");
            if (spritePosition.X + myTexture.Width > coinPosition.X && spritePosition.X < coinPosition.X + myCoin.Width &&
                    spritePosition.Y + myTexture.Height > coinPosition.Y && spritePosition.Y < coinPosition.Y + myCoin.Height
                    )
            {
                score+=5;
                coinPosition.X = -500f;
            }

            // Obstacles Collision Detection
            if (spritePosition.X + myTexture.Width > obstacle1_pos.X && spritePosition.X < obstacle1_pos.X + myObstacle1.Width &&
                    spritePosition.Y + myTexture.Height > obstacle1_pos.Y && spritePosition.Y < obstacle1_pos.Y + myObstacle1.Height
                    )
            {
                lives--;
                score-=25;
                obstacle1_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle2_pos.X && spritePosition.X < obstacle2_pos.X + myObstacle2.Width &&
                    spritePosition.Y + myTexture.Height > obstacle2_pos.Y && spritePosition.Y < obstacle2_pos.Y + myObstacle2.Height
                    )
            {
                score-=25;
                lives--;
                obstacle2_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle3_pos.X && spritePosition.X < obstacle3_pos.X + myObstacle3.Width &&
                    spritePosition.Y + myTexture.Height > obstacle3_pos.Y && spritePosition.Y < obstacle3_pos.Y + myObstacle3.Height
                    )
            {
                score-=25;
                lives--;
                obstacle3_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle4_pos.X && spritePosition.X < obstacle4_pos.X + myObstacle4.Width &&
                    spritePosition.Y + myTexture.Height > obstacle4_pos.Y && spritePosition.Y < obstacle4_pos.Y + myObstacle4.Height
                    )
            {
                lives--;
                score-=25;
                obstacle4_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle5_pos.X && spritePosition.X < obstacle5_pos.X + myObstacle5.Width &&
                    spritePosition.Y + myTexture.Height > obstacle5_pos.Y && spritePosition.Y < obstacle5_pos.Y + myObstacle5.Height
                    )
            {
                lives--;
                score-=25;
                obstacle5_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle6_pos.X && spritePosition.X < obstacle6_pos.X + myObstacle6.Width &&
                    spritePosition.Y + myTexture.Height > obstacle6_pos.Y && spritePosition.Y < obstacle6_pos.Y + myObstacle6.Height
                    )
            {
                lives--;
                score-=25;
                obstacle6_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle7_pos.X && spritePosition.X < obstacle7_pos.X + myObstacle7.Width &&
                    spritePosition.Y + myTexture.Height > obstacle7_pos.Y && spritePosition.Y < obstacle7_pos.Y + myObstacle7.Height
                    )
            {
                lives--;
                score-=25;
                obstacle7_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle8_pos.X && spritePosition.X < obstacle8_pos.X + myObstacle8.Width &&
                    spritePosition.Y + myTexture.Height > obstacle8_pos.Y && spritePosition.Y < obstacle8_pos.Y + myObstacle8.Height
                    )
            {
                lives--;
                score-=25;
                obstacle8_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle9_pos.X && spritePosition.X < obstacle9_pos.X + myObstacle9.Width &&
                    spritePosition.Y + myTexture.Height > obstacle9_pos.Y && spritePosition.Y < obstacle9_pos.Y + myObstacle9.Height
                    )
            {
                score-=25;
                lives--;
                obstacle9_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }
            if (spritePosition.X + myTexture.Width > obstacle10_pos.X && spritePosition.X < obstacle10_pos.X + myObstacle10.Width &&
                    spritePosition.Y + myTexture.Height > obstacle10_pos.Y && spritePosition.Y < obstacle10_pos.Y + myObstacle10.Height
                    )
            {
                score-=25;
                lives--;
                obstacle10_pos.X = -500f;
                spritePosition = new Vector2(35f, 0);
            }

            if (spritePosition.X + myTexture.Width > end_ribbon_pos.X && spritePosition.X < end_ribbon_pos.X + end_ribbon.Width &&
                    spritePosition.Y + myTexture.Height > end_ribbon_pos.Y && spritePosition.Y < end_ribbon_pos.Y+ end_ribbon.Height
                    )
            {
                Exit();
            
            }

            for (i = 0; i < 16; i++)
            {
                if (spritePosition.X + myTexture.Width > coinlist1_position[i].X && spritePosition.X < coinlist1_position[i].X + coinlist1[i].Width &&
                    spritePosition.Y + myTexture.Height > coinlist1_position[i].Y && spritePosition.Y < coinlist1_position[i].Y + coinlist1[i].Height
                    )
                {
                    score+=5;
                    coinlist1_position[i].X = -500f;
                }
            }

                for (i = 0; i < 8; i++)
                {


                    if (spritePosition.X + myTexture.Width > coinlist2_position[i].X && spritePosition.X < coinlist2_position[i].X + coinlist2[i].Width &&
                        spritePosition.Y + myTexture.Height > coinlist2_position[i].Y && spritePosition.Y < coinlist2_position[i].Y + coinlist2[i].Height
                        )
                    {
                        score+=5;
                        coinlist2_position[i].X = -500f;
                    }


                }

                for (i = 0; i < 6; i++)
                {
                    if (spritePosition.X + myTexture.Width > coinlist3_position[i].X && spritePosition.X < coinlist3_position[i].X + coinlist3[i].Width &&
                        spritePosition.Y + myTexture.Height > coinlist3_position[i].Y && spritePosition.Y < coinlist3_position[i].Y + coinlist3[i].Height
                        )
                    {
                        score+=5;
                        coinlist3_position[i].X = -500f;
                    }
                }
                for (i = 0; i < 8; i++)
                {
                    if (spritePosition.X + myTexture.Width > coinlist4_position[i].X && spritePosition.X < coinlist4_position[i].X + coinlist4[i].Width &&
                        spritePosition.Y + myTexture.Height > coinlist4_position[i].Y && spritePosition.Y < coinlist4_position[i].Y + coinlist4[i].Height
                        )
                    {
                        score+=5;
                        coinlist4_position[i].X = -500f;
                    }
                }
                for (i = 0; i < 16; i++)
                {
                    if (spritePosition.X + myTexture.Width > coinlist5_position[i].X && spritePosition.X < coinlist5_position[i].X + coinlist5[i].Width &&
                        spritePosition.Y + myTexture.Height > coinlist5_position[i].Y && spritePosition.Y < coinlist5_position[i].Y + coinlist5[i].Height
                        )
                    {
                        score+=5;
                        coinlist5_position[i].X = -500f;
                    }
                }
                for (i = 0; i < 7; i++)
                {
                    if (spritePosition.X + myTexture.Width > coinlist6_position[i].X && spritePosition.X < coinlist6_position[i].X + coinlist6[i].Width &&
                        spritePosition.Y + myTexture.Height > coinlist6_position[i].Y && spritePosition.Y < coinlist6_position[i].Y + coinlist6[i].Height
                        )
                    {
                        score+=5;
                        coinlist6_position[i].X = -500f;
                    }
                }
            
            //Debug.WriteLine("current score == " + score);
        }

        void check_oldobjects()
        {
            if (coinPosition.X < 180f)
            {
                //Debug.WriteLine("\n\n abhiabhiabhidbih");
                coinPosition.X = -500f;
                
            }
            if (coinlist1_position[7].X < 0)
            {
                for (i = 0; i < 8; i++)
                {
                    coinlist1_passed = 1;
                    //coinlist1[i].Dispose();
                    
                }

            }
            if (coinlist2_position[7].X < 0)
            {
                for (i = 0; i < 8; i++)
                {
                    coinlist2_passed = 1;
                    //coinlist2[i].Dispose();
                }
                
            }

        }
        
        void coin_position_update(GameTime gameTime)
        {
            coinPosition.Y = graphics.GraphicsDevice.Viewport.Height/2;
            coinPosition.X += -coinSpeed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;

            obstacle1_pos.X += -obstacle1_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle2_pos.X += -obstacle2_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle3_pos.X += -obstacle3_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle4_pos.X += -obstacle4_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle5_pos.X += -obstacle5_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle6_pos.X += -obstacle6_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle7_pos.X += -obstacle6_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle8_pos.X += -obstacle6_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle9_pos.X += -obstacle6_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            obstacle10_pos.X += -obstacle6_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            end_ribbon_pos.X += -obstacle6_speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (i = 0; i < 16; i++)
            {
                coinlist1_position[i].X += -coinlist1_speed[i].X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            for (i = 0; i < 8; i++)
            {
                coinlist2_position[i].X += -coinlist2_speed[i].X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            for (i = 0; i < 6; i++)
            {
                coinlist3_position[i].X += -coinlist4_speed[i].X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            for (i = 0; i < 8; i++)
            {
                coinlist4_position[i].X += -coinlist4_speed[i].X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            for (i = 0; i < 16; i++)
            {
                coinlist5_position[i].X += -coinlist5_speed[i].X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            for (i = 0; i < 7; i++)
            {
                coinlist6_position[i].X += -coinlist6_speed[i].X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            //coinPosition.X = graphics.GraphicsDevice.Viewport.Height - coinPosition.X;

        }
        void startmicrophone()
        {
            if (microphone.State == MicrophoneState.Stopped)
            {
                microphone.BufferDuration = TimeSpan.FromMilliseconds(500);
                buffer = new byte[microphone.GetSampleSizeInBytes(microphone.BufferDuration)];
                microphone.Start();
                System.Diagnostics.Debug.WriteLine("Threshold setted to:" + minimumThreshold);
            }
        }
        void UpdateSprite(GameTime gameTime)
        {
            // Move the sprite by speed, scaled by elapsed time.
            //spritePosition.X += spriteSpeed.X * (float)gameTime.ElapsedGameTime.TotalSeconds;
            
            if (flag == 1) { spritePosition.Y += -spriteSpeed.Y * (float)3 * (float)gameTime.ElapsedGameTime.TotalSeconds; }

            if (flag == 0)
            {
                if ((spritePosition.Y + (spriteSpeed.Y * (float)0.8 * (float)gameTime.ElapsedGameTime.TotalSeconds)) >= 460)
                    spritePosition.Y = 0;
                else
                    spritePosition.Y = (spritePosition.Y + spriteSpeed.Y * (float)0.8 * (float)gameTime.ElapsedGameTime.TotalSeconds);
            }

            //Debug.WriteLine(spritePosition);
            int MaxX =
                graphics.GraphicsDevice.Viewport.Width - myTexture.Width;
            int MinX = 0;
            int MaxY =
                graphics.GraphicsDevice.Viewport.Height - myTexture.Height;
            int MinY = 0;
            
            // Check for bounce.
            /*
            if (spritePosition.X > MaxX)
            {
                //spriteSpeed.X *= -1;
                //spritePosition.X = MaxX;
                spritePosition = Vector2.Zero;
                flag = 0;
            }
            
            else if (spritePosition.X < MinX)
            {
                spriteSpeed.X *= -1;
                spritePosition.X = MinX;
                
            }
            */
            if (spritePosition.Y > MaxY)
            {
                //spriteSpeed.Y *= -1;
                //spritePosition.Y = MaxY;
                spritePosition = new Vector2 (35f,0);
                flag = 0;
            }

            else if (spritePosition.Y < MinY)
            {
                spriteSpeed.Y *= -1;
                spritePosition.Y = MinY;
                
            }
        }
        
        void microphone_BufferReady(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            microphone.GetData(buffer);

            // RMS Method
            double rms = 0;
            ushort byte1 = 0;
            ushort byte2 = 0;
            short value = 0;
            int volume = 0;
            rms = (short)(byte1 | (byte2 << 8));

            for (int i = 0; i < buffer.Length - 1; i += 2)
            {
                byte1 = buffer[i];
                byte2 = buffer[i + 1];

                value = (short)(byte1 | (byte2 << 8));
                rms += Math.Pow(value, 2);
            }
            rms /= (double)(buffer.Length / 2);
            volume = (int)Math.Floor(Math.Sqrt(rms));
            //Debug.WriteLine(volume);
            if ((volume > minimumThreshold))
            {
                flag = 1;
                System.Diagnostics.Debug.WriteLine("Threshold exceeded");
                System.Diagnostics.Debug.WriteLine("buffer.Length" + buffer.Length + " Volume:" + volume);
            }
            if ((volume < minimumThreshold))
            {
                flag = 0;
            }


            //stream.Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            // Draw the sprite.
            

            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend);
            spriteBatch.Draw(myTexture, spritePosition, Color.White);

            spFont = Content.Load<SpriteFont>("Arial");
            spBatch = new SpriteBatch(graphics.GraphicsDevice);
            spriteBatch.DrawString(spFont," Score : "+score, new Vector2(620f, 20f), Color.Black);
            //spriteBatch.DrawString(spFont, " Lives : " + lives, new Vector2(680f, 50f), Color.Black);

            spriteBatch.Draw(myCoin, coinPosition, Color.White);
            spriteBatch.Draw(myObstacle1, obstacle1_pos, Color.White);
            spriteBatch.Draw(myObstacle2, obstacle2_pos, Color.White);
            spriteBatch.Draw(myObstacle3, obstacle3_pos, Color.White);
            spriteBatch.Draw(myObstacle4, obstacle4_pos, Color.White);
            spriteBatch.Draw(myObstacle5, obstacle5_pos, Color.White);
            spriteBatch.Draw(myObstacle6, obstacle6_pos, Color.White);
            spriteBatch.Draw(myObstacle7, obstacle7_pos, Color.White);
            spriteBatch.Draw(myObstacle8, obstacle8_pos, Color.White);
            spriteBatch.Draw(myObstacle9, obstacle9_pos, Color.White);
            spriteBatch.Draw(myObstacle10, obstacle10_pos, Color.White);
            spriteBatch.Draw(end_ribbon, end_ribbon_pos, Color.White);
            
            draw_first_coinlist();
            draw_second_coinlist();
            draw_third_coinlist();
            draw_fourth_coinlist();
            draw_fifth_coinlist();
            draw_sixth_coinlist();
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
        void draw_first_coinlist()
        {
            
            for (i = 0; i < 16; i++)
            {
                spriteBatch.Draw(coinlist1[i], coinlist1_position[i], Color.White);
            }
        }

        void draw_second_coinlist()
        {
            
            for (i = 0; i < 8; i++)
            {
                spriteBatch.Draw(coinlist2[i], coinlist2_position[i], Color.White);
            }
        }

        void draw_third_coinlist()
        {

            for (i = 0; i < 6; i++)
            {
                spriteBatch.Draw(coinlist3[i], coinlist3_position[i], Color.White);
            }
        }

        void draw_fourth_coinlist()
        {

            for (i = 0; i < 8; i++)
            {
                spriteBatch.Draw(coinlist4[i], coinlist4_position[i], Color.White);
            }
        }

        void draw_fifth_coinlist()
        {

            for (i = 0; i < 16; i++)
            {
                spriteBatch.Draw(coinlist5[i], coinlist5_position[i], Color.White);
            }
        }

        void draw_sixth_coinlist()
        {

            for (i = 0; i < 7; i++)
            {
                spriteBatch.Draw(coinlist6[i], coinlist6_position[i], Color.White);
            }
        }
        public void Quit()
        {
            this.Exit();
        }

        }


    }

