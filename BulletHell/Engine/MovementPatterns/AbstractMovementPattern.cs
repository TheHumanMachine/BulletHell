using Microsoft.Xna.Framework;

namespace BulletHell.Engine.MovementPatterns
{
    public abstract class AbstractMovementPattern
    {
        protected AbstractMovementPattern()
        {
        }

        public abstract void Move(ref float x, ref float y, GameTime gameTime, ref double movementSpeed);

    }
}

