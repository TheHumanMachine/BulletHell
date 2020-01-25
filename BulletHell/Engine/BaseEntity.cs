using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine
{
    public abstract class BaseEntity
    {
        protected Texture2D entitySprite;
        protected double movementSpeed;
        protected double x;
        protected double y;

        protected BaseEntity(Texture2D entitySprite, double x, double y, double movementSpeed)
        {
            this.entitySprite = entitySprite;
            this.x = x;
            this.y = y;
            this.movementSpeed = movementSpeed;
        }

       public double X
        {
            get { return x; }
            set
            {
                this.x = value;
            }
        }

        public double Y
        {
            get { return y; }
            set
            {
                this.y = value;
            }
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
