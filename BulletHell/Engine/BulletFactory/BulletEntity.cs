using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine
{
    public class BulletEntity : BaseEntity
    {

        public BulletEntity(Texture2D entitySprite, double x, double y, double movementSpeed) : base(entitySprite, x, y, movementSpeed)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(entitySprite, new Rectangle((int)this.X, (int)this.Y, 20, 20), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            this.Y -= movementSpeed;
        }
    }
}
