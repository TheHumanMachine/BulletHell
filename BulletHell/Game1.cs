using BulletHell.Engine;
using BulletHell.Engine.BulletFactory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Text;

namespace BulletHell
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Sprits
        Texture2D crosshairSprite;
        Texture2D backgroundSprite;
        Texture2D playerSprite;
        Texture2D enemySprite;
        Texture2D bulletSprite;

        // Fonts
        SpriteFont gameFont;

        // Player
        PlayerEntity player;

        // Enemy
        EnemyEntity enemy;

        // Control Variables (Mouse, Keyboard, etc)
        MouseState mouseState;
        bool isReleased = true;

        KeyboardState state;

        // Game Variables
        BulletFactory bulletFactory;
        List<BulletEntity> bulletList;
       // Vector2 targetPosition;
        int score = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            base.Initialize();
            bulletList = new List<BulletEntity>();
            bulletFactory = new BulletFactory(bulletSprite, bulletList);
            player = new PlayerEntity(playerSprite, 50, 50, 1);

            player.bulletCreated += bulletFactory.OnBulletCreated;
            enemy = new EnemyEntity(enemySprite, 25, 50, 1);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            playerSprite = Content.Load<Texture2D>(@"2D_Assets\playerSprite");
            enemySprite = Content.Load<Texture2D>(@"2D_Assets\enemySprite");
            backgroundSprite = Content.Load<Texture2D>(@"2D_Assets\synthwaveLevel");
            bulletSprite = Content.Load<Texture2D>(@"2D_Assets\bullet");
            gameFont = Content.Load<SpriteFont>(@"Fonts\galleryFont");
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //mouseState = Mouse.GetState();

            //if(mouseState.LeftButton == ButtonState.Pressed && isReleased)
            //{
            //    score++;
            //    isReleased = false;
            //}

            //if(mouseState.LeftButton == ButtonState.Released)
            //{
            //    isReleased = true;
            //}

            //state = Keyboard.GetState();

            //// If they hit esc, exit
            //if (state.IsKeyDown(Keys.Escape))
            //{
            //    Exit();
            //}

            // Print to debug console currently pressed keys
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (var key in state.GetPressedKeys())
                sb.Append("Key: ").Append(key).Append(" pressed ");

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            else
                System.Diagnostics.Debug.WriteLine("No Keys pressed");

            //// Move our sprite based on arrow keys being pressed:
            //if (state.IsKeyDown(Keys.D))
            //    player.X += 10;
            //if (state.IsKeyDown(Keys.A))
            //    player.X -= 10;
            //if (state.IsKeyDown(Keys.W))
            //    player.Y -= 10;
            //if (state.IsKeyDown(Keys.S))
            //    player.Y += 10;
            foreach (var bullet in bulletList)
            {
                bullet.Update(gameTime);
            }
            player.Update(gameTime);
            // TODO: Add your update logic here
            enemy.Update(gameTime);

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

            spriteBatch.Draw(backgroundSprite, new Rectangle(0, 0, 500, 500), Color.Transparent);

            foreach (var bullet in bulletList)
            {
                bullet.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);
            enemy.Draw(spriteBatch);

            spriteBatch.DrawString(gameFont, score.ToString(), new Vector2(10, 10), Color.Black);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
