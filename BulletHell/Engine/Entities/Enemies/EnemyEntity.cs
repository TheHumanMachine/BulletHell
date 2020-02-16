using BulletHell.Engine.MovementPatterns;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BulletHell.Engine
{
    class EnemyEntity : BaseEntity
    {
        public delegate void CreateBulletEventHandler(float x, float y);
        public event CreateBulletEventHandler bulletCreated;

        AbstractMovementPattern[] movementPatterns;
        int counter = 0;
        bool isCircling = true;

        public EnemyEntity(Texture2D entitySprite, Vector2 position, double movementSpeed, AbstractMovementPattern[] movementPatterns, float scalar) : base(entitySprite, position, movementSpeed, scalar)
        {
            this.movementPatterns = movementPatterns;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        protected virtual void OnBulletCreated()
        {
            // the width is divided by 2 so that the bullets appear in the middle of the sprite
            bulletCreated(this.X + this.sprite.SpriteTexture.Width  / 2, this.Y);
        }

        public override void Update(GameTime gameTime)
        {
            if(isCircling)
            {
                movementPatterns[0].Move(ref this.X, ref this.Y, gameTime, ref movementSpeed);
                counter++;
                if(counter > 200)
                {
                    isCircling = false;
                    counter = 0;
                }
            }
            else
            {
                movementPatterns[1].Move(this.X, this.Y, gameTime, ref movementSpeed);
                counter++;
                if (counter > 200)
                {
                    isCircling = true;
                    counter = 0;
                }
            }

            if(counter == 50 || counter == 100 || counter == 150)
            {
                OnBulletCreated();
            }
        }
    }
}
