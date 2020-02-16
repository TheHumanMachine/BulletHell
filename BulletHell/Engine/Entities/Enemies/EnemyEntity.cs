using BulletHell.Engine.MovementPatterns;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BulletHell.Engine
{
    class EnemyEntity : BaseEntity
    {
        public delegate void CreateBulletEventHandler(double x, double y);
        public event CreateBulletEventHandler bulletCreated;

        AbstractMovementPattern[] movementPatterns;
        int counter = 0;
        bool isCircling = true;

        public EnemyEntity(Texture2D entitySprite, double x, double y, double movementSpeed, AbstractMovementPattern[] movementPatterns) : base(entitySprite, x, y, movementSpeed)
        {
            this.movementPatterns = movementPatterns;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(entitySprite, new Rectangle((int)this.X, (int)this.Y, 75, 100), Color.White);
        }

        protected virtual void OnBulletCreated()
        {
            // the width is divided by 2 so that the bullets appear in the middle of the sprite
            bulletCreated(this.X + this.entitySprite.Width / 2, this.Y);
        }

        public override void Update(GameTime gameTime)
        {
            if(isCircling)
            {
                movementPatterns[0].Move( ref this.x, ref this.y, gameTime, ref movementSpeed);
                counter++;
                if(counter > 200)
                {
                    isCircling = false;
                    counter = 0;
                }
            }
            else
            {
                movementPatterns[1].Move(ref this.x, ref this.y, gameTime, ref movementSpeed);
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
