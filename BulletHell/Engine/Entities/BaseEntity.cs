using BulletHell.Engine.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine
{
    public abstract class BaseEntity
    {
        //private Circle hitbox;
        protected Sprite sprite;
        protected double movementSpeed;
        protected Vector2 position;

        protected BaseEntity(Texture2D entitySprite, Vector2 position, double movementSpeed, float scalar)
        {
            this.position = position;
            sprite = new Sprite(entitySprite, position, Color.White, scalar);
            //this.hitbox = new Circle((float)x, (float)y, 10);
            this.movementSpeed = movementSpeed;
        }

       public virtual float X
        {
            get { return position.X; }
            set
            {
                this.position.X = value;
                this.sprite.UpdatePosition(position);
                //hitbox.X = position.X + (this.sprite.SpriteTexture.Width / 2);
            }
        }

        public virtual float Y
        {
            get { return position.Y; }
            set
            {
                position.Y = value;
                this.sprite.UpdatePosition(position);
                //hitbox.Y = position.Y - (this.sprite.SpriteTexture.Height / 2);
            }
        }

        //public Circle Hitbox
        //{
        //    get { return hitbox; }
        //}

        //public bool Intersects(Circle otherCircle)
        //{
        //    return hitbox.Intersects(otherCircle);
        //}

        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
