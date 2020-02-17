using BulletHell.Engine;
using BulletHell.Engine.BulletFactory;
using BulletHell.Engine.Entities.Enemies;
using BulletHell.Engine.Entities.Enemies.EnemyFactories;
using BulletHell.Engine.MovementPatterns;
using BulletHell.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace BulletHell
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // Textures
        Texture2D backgroundTexture;
        Texture2D midBossTexture;
        Texture2D bossTexture;
        Texture2D enemyAttackTexture;
        Texture2D playerTexture;
        Texture2D enemyTexture;
        Texture2D bulletTexture;
        Texture2D gruntTexture;

        // Sprites
        Sprite backgroundSprite;
        
        // Fonts
        SpriteFont gameFont;

        // Player
        PlayerEntity player;

        // Bosses
        MidBossEntity midBoss;
        BossEntity boss;

        // Game Variables
        BulletFactory bulletFactory;
        PlayerBulletFactory playerBulletFactory;
        BasicEnemyFactory basicEnemyFactory;
        GruntTwoFactory gruntTwoFactory;

        List<BulletEntity> bulletList;
        List<EnemyEntity> enemyList;
        List<GruntTwo> gruntTwoList;
       // Vector2 targetPosition;
        int score = 0;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            //graphics.IsFullScreen = true;
            this.graphics.PreferredBackBufferWidth = 900;
            this.graphics.PreferredBackBufferHeight = 1000;
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

            backgroundSprite = new Sprite(backgroundTexture, 0, 0, Color.White, 1.5f);
            float enemyScalar = 0.15f;
            float enemyX = 200;
            float enemyY = 100;
            AbstractMovementPattern[] enemyMovements = { new CircleMovementPattern(enemyX, enemyY), new StraightMovementPattern()};
            
            bulletList = new List<BulletEntity>();
            gruntTwoList = new List<GruntTwo>();

            bulletFactory = new BulletFactory(enemyAttackTexture, bulletList);
            playerBulletFactory = new PlayerBulletFactory(bulletTexture, bulletList);
            basicEnemyFactory = new BasicEnemyFactory(enemyTexture, enemyScalar, 2, enemyMovements);
            gruntTwoFactory = new GruntTwoFactory(gruntTexture, enemyScalar, 3, enemyMovements);

            enemyList = new List<EnemyEntity>();

            float playerScalar = 0.15f;
            float playerX = 200;
            float playerY = 1000;


            player = new PlayerEntity(playerTexture, playerX, playerY, 6, playerScalar);
            player.bulletCreated += playerBulletFactory.OnBulletCreated;

            midBoss = new MidBossEntity(midBossTexture, 450, 100, 4, enemyMovements, 0.5f);
            midBoss.bulletCreated += bulletFactory.OnBulletCreated;

            boss = new BossEntity(bossTexture, 450, 100, 4, enemyMovements, 0.5f);
            boss.bulletCreated += bulletFactory.OnBulletCreated;


            Random rand = new Random();

            for (int i = 0; i < 10; i++)
            {
                EnemyEntity temp = basicEnemyFactory.Create(enemyX + (i * rand.Next(20, 100)), enemyY + (i * rand.Next(20, 100)));
                temp.bulletCreated += bulletFactory.OnBulletCreated;
                enemyList.Add(temp);
            }

            for (int i = 0; i < 15; i++)
            {
                GruntTwo temp = gruntTwoFactory.Create(enemyX + (i * rand.Next(20, 100)), enemyY + (i * rand.Next(20, 100)));
                temp.bulletCreated += bulletFactory.OnBulletCreated;
                gruntTwoList.Add(temp);
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
            playerTexture = Content.Load<Texture2D>(@"2D_Assets\playerSprite");
            enemyTexture = Content.Load<Texture2D>(@"2D_Assets\peach");
            midBossTexture = Content.Load<Texture2D>(@"2D_Assets\peach_grunt2");
            enemyAttackTexture = Content.Load<Texture2D>(@"2D_Assets\boss_attack_texture");
            bossTexture = Content.Load<Texture2D>(@"2D_Assets\boss_Texture");
            backgroundTexture = Content.Load<Texture2D>(@"2D_Assets\synthwaveLevel");
            bulletTexture = Content.Load<Texture2D>(@"2D_Assets\fireball");
            gruntTexture = Content.Load<Texture2D>(@"2D_Assets\kris");
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
 
            foreach (var bullet in bulletList)
            {
                bullet.Update(gameTime);
            }
            
            player.Update(gameTime);


            // TODO: Add your update logic here
             midBoss.Update(gameTime);

            boss.Update(gameTime);

            foreach (var enemy in enemyList)
            {
                enemy.Update(gameTime);
            }

            foreach(var grunt in gruntTwoList)
            {
                grunt.Update(gameTime);
            }

            foreach (var bullet in bulletList)
            {
                //if (enemy.Intersects(bullet.Hitbox))
                //{
                //    System.Console.WriteLine("ENEMY WAS HITTTTTTTT!!!!!!!!!!!!!!!!!");
                //}
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

            backgroundSprite.Draw(spriteBatch);

            foreach (var bullet in bulletList)
            {
                bullet.Draw(spriteBatch);
            }

            foreach (var enemy in enemyList)
            {
                enemy.Draw(spriteBatch);
            }

            foreach(var grunt in gruntTwoList)
            {
                grunt.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);

            midBoss.Draw(spriteBatch);

            boss.Draw(spriteBatch);

            spriteBatch.DrawString(gameFont, gameTime.TotalGameTime.Seconds.ToString(), new Vector2(10, 900), Color.Black);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
