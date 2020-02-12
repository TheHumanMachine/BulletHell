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
        private double radius = 30;
        private double angle = 0.1;
        private double originX = 200;
        private double originY = 100;

        public CircleMovementPattern(double originX, double originY)
        {
            this.originX = originX;
            this.originY = originY;
        }

        public override void Move(ref double x, ref double y, GameTime gameTime, ref double movementSpeed)
        {
            x = originX +  Math.Cos(angle) * radius;
            y = originY + Math.Sin(angle) * radius;

            double angleInRad = Math.PI * angle / 180.0;

            angle += 0.10 ;
        }
    }
}
