using BulletHell.Engine.MovementPatterns;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace BulletHell.Engine
{
    class EnemyEntity : BaseEntity
    {
        AbstractMovementPattern movementPattern;

        public EnemyEntity(Texture2D entitySprite, double x, double y, double movementSpeed, CircleMovementPattern movementPattern) : base(entitySprite, x, y, movementSpeed)
        {
            this.movementPattern = movementPattern;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(entitySprite, new Rectangle((int)this.X, (int)this.Y, 100, 100), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            movementPattern.Move( ref this.x, ref this.y, gameTime, ref movementSpeed);
        }
    }
}
