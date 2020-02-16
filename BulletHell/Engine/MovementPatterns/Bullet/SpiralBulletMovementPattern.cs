using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BulletHell.Engine.MovementPatterns.Bullet
{
    public class SpiralBulletMovementPattern : AbstractMovementPattern
    {
        private double radius = 10;
        private double radialIncrease = 0.005;
        private double angle = 0.01;

        public SpiralBulletMovementPattern() : base()
        {

        }

        public override void Move(ref double x, ref double y, GameTime gameTime, ref double movementSpeed)
        {
            x = x + Math.Cos(angle) * radius;
            y = y + Math.Sin(angle) * radius;

            double angleInRad = Math.PI * angle / 180.0;

            radius += radialIncrease;

            angle += 0.1;
        }
    }
}
