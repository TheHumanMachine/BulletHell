using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell.Engine.Utils
{
    public class Sprite
    {
        private readonly Color color = Color.White;
        private Vector2 position;
        public Vector2 scale;
        private Rectangle? rectangle = null;
        private Texture2D spriteTexture;
        private Rectangle? bounds;
        private Vector2 origin;
        private SpriteEffects spriteEffect = SpriteEffects.None;
        private float rotation = 0;
        private float layerDepth = 0;

        
        public Sprite(Texture2D spriteTexture, Vector2 position, Color color, float scalar, Rectangle? bounds = null)
        {
            this.spriteTexture = spriteTexture;
            this.position = position;
            this.color = color;
            this.bounds = bounds;
            this.origin = Vector2.Zero;
            this.scale = new Vector2(scalar, scalar);
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
            spriteBatch.Draw(spriteTexture, position, rectangle, color, rotation, origin, scale, spriteEffect, layerDepth);
        }

        public void UpdatePosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public void UpdatePosition(Vector2 nPosition)
        {
            position = nPosition;
        }

    }
}
