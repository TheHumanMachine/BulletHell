
using BulletHell.Engine.MovementPatterns;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine
{
    public class BulletEntity : BaseEntity
    {
        private bool alive = true;
        AbstractMovementPattern movementPattern;

        public BulletEntity(Texture2D entitySprite, float x, float y, double movementSpeed, AbstractMovementPattern movementPattern, float scalar) : base(entitySprite, x, y, movementSpeed, scalar)
        {
            this.movementPattern = movementPattern;
        }

        public bool IsAlive
        {
            get { return alive; }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            float tempX = this.X;
            float tempY = this.Y;
            movementPattern.Move(ref tempX, ref tempY, gameTime, ref movementSpeed);
            this.X = tempX;
            this.Y = tempY;

        }
    }
}
