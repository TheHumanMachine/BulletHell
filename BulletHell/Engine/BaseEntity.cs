using BulletHell.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine
{
    public abstract class BaseEntity
    {
        protected Texture2D entitySprite;
        private Circle hitbox;
        protected double movementSpeed;
        protected double x;
        protected double y;

        protected BaseEntity(Texture2D entitySprite, double x, double y, double movementSpeed)
        {
            this.entitySprite = entitySprite;
            this.x = x;
            this.y = y;
            this.hitbox = new Circle((float)x, (float)y, 10);
            this.movementSpeed = movementSpeed;
        }

       public virtual double X
        {
            get { return x; }
            set
            {
                this.x = value;
                hitbox.X = (float)x + (this.entitySprite.Width / 2);
            }
        }

        public virtual double Y
        {
            get { return y; }
            set
            {
                this.y = value;
                hitbox.Y = (float)y -( this.entitySprite.Height / 2);
            }
        }

        public Circle Hitbox
        {
            get { return hitbox; }
        }

        public bool Intersects(Circle otherCircle)
        {
            return hitbox.Intersects(otherCircle);
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
