using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BulletHell.Engine.MovementPatterns.Bullet
{
    public class PlayerBulletMovementPattern : AbstractMovementPattern
    {

        public override void Move(ref float x, ref float y, GameTime gameTime, ref double movementSpeed)
        {
            y +=(float)(-1 * movementSpeed);
        }
    }
}
