using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine.Utils
{
    public class Sprite
    {
        private readonly Color color = Color.White;
        private float x;
        private float y;
        private Vector2 scale;
        private Rectangle? rectangle = null;
        private Texture2D spriteTexture;
        private Rectangle? bounds;
        private Vector2 origin;
        private SpriteEffects spriteEffect = SpriteEffects.None;
        private float rotation = 0;
        private float layerDepth = 0;


        public Sprite(Texture2D spriteTexture, float x, float y, Color color, float scalar, Rectangle? bounds = null)
        {
            this.spriteTexture = spriteTexture;
            this.x = x;
            this.y = y;
            this.color = color;
            this.bounds = bounds;
            this.origin = Vector2.Zero;
            this.scale = new Vector2(scalar, scalar);
        }

        public virtual float X
        {
            get { return x; }
            set
            {
                this.x = value;
            }
        }

        public virtual float Y
        {
            get { return y; }
            set
            {
                this.y = value;
            }
        }

        public virtual Texture2D SpriteTexture
        {
            get { return spriteTexture; }
            set
            {
                this.spriteTexture = value;
            }
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 temp = new Vector2(this.x, this.y);
            spriteBatch.Draw(spriteTexture, temp, rectangle, color, rotation, origin, scale, spriteEffect, layerDepth);
        }
    }
}