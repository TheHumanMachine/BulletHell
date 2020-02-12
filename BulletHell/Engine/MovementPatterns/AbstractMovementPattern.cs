using Microsoft.Xna.Framework;

namespace BulletHell.Engine.MovementPatterns
{
    public abstract class AbstractMovementPattern
    {
        protected AbstractMovementPattern()
        {
        }

        public abstract void Move(ref double x, ref double y, GameTime gameTime, ref double movementSpeed);

    }
}

