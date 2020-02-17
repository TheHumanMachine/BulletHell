using System;
using BulletHell.Engine.MovementPatterns;
using BulletHell.Engine.MovementPatterns.Enemy;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine.Entities.Enemies
{
    public class BossEntity : BaseEntity
    {
        public delegate void CreateBulletEventHandler(float x, float y);
        public event CreateBulletEventHandler bulletCreated;

        private double timeOnScreen = 40; // the mid boss will be on screen for 20 seconds
        private int startingTime;
        private bool hasTimeStarted = false;
        private bool isActive = false;

        private int counter = 0;
        private bool isCircling = true;
        AbstractMovementPattern[] movementPatterns;
        AbstractMovementPattern exitMovementPattern;

        TimeSpan bossTimer;

        public BossEntity(Texture2D entitySprite, float x, float y, double movementSpeed, AbstractMovementPattern[] movementPatterns, float scalar) : base(entitySprite, x, y, movementSpeed, scalar)
        {
            this.movementPatterns = movementPatterns;
            exitMovementPattern = new ExitScreenMovementPattern();
            bossTimer = TimeSpan.Zero;
        }

        protected virtual void OnBulletCreated()
        {
            // the width is divided by 2 so that the bullets appear in the middle of the sprite
            bulletCreated(this.X + ((this.sprite.SpriteTexture.Width * 0.15f) / 2), this.Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                this.sprite.Draw(spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            bossTimer += gameTime.ElapsedGameTime;
            // If this is the first time it's updating we want to preserve the time for future reference
            if (!hasTimeStarted && bossTimer > TimeSpan.FromSeconds(115))
            {
                startingTime = gameTime.TotalGameTime.Seconds;
                hasTimeStarted = true;
                isActive = true;
                bossTimer = TimeSpan.Zero;
            }

            if (isActive)
            {
                // We assume currentTimeIn Seconds wil always be bigger then startingTime
                if (bossTimer < TimeSpan.FromSeconds(timeOnScreen))
                {
                    // Mid boss is still active
                    float tempX = this.X;
                    float tempY = this.Y;
                    if (isCircling)
                    {
                        movementPatterns[0].Move(ref tempX, ref tempY, gameTime, ref movementSpeed);
                        counter++;
                        if (counter > 200)
                        {
                            isCircling = false;
                            counter = 0;
                        }
                    }
                    else
                    {
                        movementPatterns[1].Move(ref tempX, ref tempY, gameTime, ref movementSpeed);
                        counter++;
                        if (counter > 200)
                        {
                            isCircling = true;
                            counter = 0;
                        }
                    }

                    this.X = tempX;
                    this.Y = tempY;

                    if (counter % 25 == 0)
                    {
                        OnBulletCreated();
                    }
                }
                else
                {
                    // Mid boss should exit
                    if (movementSpeed < 0) { movementSpeed *= -1; }
                    float tempX = this.X;
                    float tempY = this.Y;
                    exitMovementPattern.Move(ref tempX, ref tempY, gameTime, ref movementSpeed);
                    this.X = tempX;
                    this.Y = tempY;

                    if (this.Y <= (0 - this.sprite.SpriteTexture.Height))
                    {
                        isActive = false;
                    }
                }
            }
        }
    }
}
