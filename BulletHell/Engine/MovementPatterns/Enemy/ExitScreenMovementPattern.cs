using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BulletHell.Engine.MovementPatterns.Enemy
{
    public class ExitScreenMovementPattern : AbstractMovementPattern
    {
        public override void Move(ref float x, ref float y, GameTime gameTime, ref double movementSpeed)
        {
            y += (float)(-1 * movementSpeed * 10);
        }
    }
}
