using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Engine.Utils
{
    public class Circle
    {
        private float x;
        private float y;
        private float radius;

        public Circle(float x, float y, float radius)
        {
            X = x;
            Y = y;
            this.radius = radius;
        }
        
        public float X
        {
            get { return x; }
            set
            {
                this.x = value;
            }
        }

        public float Y
        {
            get { return y; }
            set
            {
                this.y = value;
            }
        }

        public bool Intersects(Circle circle)
        {
            var centre0 = new Vector2(circle.X, circle.Y);
            var centre1 = new Vector2(X, Y);
            return Vector2.Distance(centre0, centre1) < radius + circle.radius;
        }
    }
}
