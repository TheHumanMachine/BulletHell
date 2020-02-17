using System;
using Microsoft.Xna.Framework;

namespace BulletHell.Engine.MovementPatterns.Bullet
{
    public class SpiralBulletMovementPattern : AbstractMovementPattern
    {
        private double radius = 10;
        double angleInDegrees = 0;
        
        public SpiralBulletMovementPattern() : base()
        {

        }

        public override void Move(ref float x, ref float y, GameTime gameTime, ref double movementSpeed)
        {
            x += (float)(Math.Cos(angleInDegrees * (Math.PI / 180.0)) * radius);
            y += (float)(Math.Sin(angleInDegrees * (Math.PI / 180.0)) * radius);

            if (angleInDegrees < 90)
            {
                angleInDegrees += 10;
            }
        }
    }
}
