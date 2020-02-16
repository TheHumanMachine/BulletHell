using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace BulletHell.Engine.MovementPatterns
{
    class StraightMovementPattern : AbstractMovementPattern
    {
        public StraightMovementPattern()
        {

        }

        public override void Move(ref double x, ref double y, GameTime gameTime, ref double movementSpeed)
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
                movementSpeed = rnd.Next(2, 2);
            }
            
            float timeDelta = gameTime.ElapsedGameTime.Milliseconds;
            x += movementSpeed * timeDelta * 0.2;
        }
    }
}
