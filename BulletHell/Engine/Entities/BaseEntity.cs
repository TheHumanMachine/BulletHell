using BulletHell.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine
{
    public abstract class BaseEntity
    {
        protected Sprite sprite;
        private Circle hitbox;
        protected double movementSpeed;
        protected float x;
        protected float y;

        protected BaseEntity(Texture2D entitySprite, float x, float y, double movementSpeed, float scalar)
        {
            sprite = new Sprite(entitySprite, x, y, Color.White, scalar);
            this.x = x;
            this.y = y;
            this.hitbox = new Circle((float)x, (float)y, 10);
            this.movementSpeed = movementSpeed;
        }

       public virtual float X
        {
            get { return x; }
            set
            {
                this.x = value;
                sprite.X = this.x;
                //hitbox.X = (float)x + (this.entitySprite.Width / 2);
            }
        }

        public virtual float Y
        {
            get { return y; }
            set
            {
                this.y = value;
                this.sprite.Y = y;
                //hitbox.Y = (float)y -( this.entitySprite.Height / 2);
            }
        }

        //public Circle Hitbox
        //{
        //    get { return hitbox; }
        //}

        public bool Intersects(Circle otherCircle)
        {
            return false;
        }

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
