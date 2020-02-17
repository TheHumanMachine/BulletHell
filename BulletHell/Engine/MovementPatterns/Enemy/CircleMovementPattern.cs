using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace BulletHell.Engine.MovementPatterns
{
    class CircleMovementPattern : AbstractMovementPattern
    {
        private double radius = 10;
        private double angle = 0.1;
        private float originX = 200;
        private float originY = 100;

        public CircleMovementPattern(float originX, float originY)
        {
            this.originX = originX;
            this.originY = originY;
        }

        public override void Move(ref float x, ref float y, GameTime gameTime, ref double movementSpeed)
        {
            x += (float)(Math.Cos(angle) * radius);
            y += (float)(Math.Sin(angle) * radius);

            double angleInRad = Math.PI * angle / 180.0;

            angle += 0.10 ;
        }
    }
}
