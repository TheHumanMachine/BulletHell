using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BulletHell.Engine
{
    class EnemyEntity : BaseEntity
    {
        public EnemyEntity(Texture2D entitySprite, double x, double y, double movementSpeed) : base(entitySprite, x, y, movementSpeed)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(entitySprite, new Rectangle((int)this.X, (int)this.Y, 200, 200), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            Random rnd = new Random();
            double x_speed = movementSpeed;
            double y_speed = movementSpeed + 1;
            if (x > 700)
            {
                movementSpeed = -1 * (double)rnd.Next(2, 2);
            }
            if (x < 0)
            {
                movementSpeed = (double)rnd.Next(2, 2);
            }

            float timeDelta = gameTime.ElapsedGameTime.Milliseconds;
            this.x += movementSpeed * timeDelta * 0.2;
           // this.y += movementSpeed * timeDelta * 0.1;

        }
    }
}
