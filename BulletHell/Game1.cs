using BulletHell.Engine;
using BulletHell.Engine.BulletFactory;
using BulletHell.Engine.MovementPatterns;
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
            graphics.IsFullScreen = true;
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
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
            
            double enemyX = 200;
            double enemyY = 100;
            AbstractMovementPattern[] enemyMovements = { new CircleMovementPattern(enemyX, enemyY), new StraightMovementPattern()};
            enemy = new EnemyEntity(enemySprite, 200, 100, 1, enemyMovements);
            enemy.bulletCreated += bulletFactory.OnBulletCreated;
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
            enemySprite = Content.Load<Texture2D>(@"2D_Assets\peach");
            backgroundSprite = Content.Load<Texture2D>(@"2D_Assets\synthwaveLevel");
            bulletSprite = Content.Load<Texture2D>(@"2D_Assets\fireball");
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

          //  bulletFactory.RecycleBullets(); // Culls all of the bullets that are no longer on the screen
            
            // Print to debug console currently pressed keys
            System.Text.StringBuilder sb = new StringBuilder();
            foreach (var key in state.GetPressedKeys())
                sb.Append("Key: ").Append(key).Append(" pressed ");

            if (sb.Length > 0)
                System.Diagnostics.Debug.WriteLine(sb.ToString());
            else
                System.Diagnostics.Debug.WriteLine("No Keys pressed");

            foreach (var bullet in bulletList)
            {
                bullet.Update(gameTime);
            }


            player.Update(gameTime);

            // TODO: Add your update logic here
            enemy.Update(gameTime);

            foreach (var bullet in bulletList)
            {
                if (enemy.Intersects(bullet.Hitbox))
                {
                    System.Console.WriteLine("ENEMY WAS HITTTTTTTT!!!!!!!!!!!!!!!!!");
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            
            spriteBatch.Begin();

            spriteBatch.Draw(backgroundSprite, new Rectangle(0, 0, 700, 700), Color.White);

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
