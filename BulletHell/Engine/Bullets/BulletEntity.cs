using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BulletHell.Engine.MovementPatterns;
using BulletHell.Engine.MovementPatterns.Bullet;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BulletHell.Engine
{
    public class BulletEntity : BaseEntity
    {
        private bool alive = true;
        AbstractMovementPattern movementPattern;

        public BulletEntity(Texture2D entitySprite, double x, double y, double movementSpeed, AbstractMovementPattern movementPattern) : base(entitySprite, x, y, movementSpeed)
        {
            this.movementPattern = movementPattern;
        }

        public BulletEntity(Texture2D entitySprite, double x, double y, double movementSpeed) : base(entitySprite, x, y, movementSpeed)
        {
            this.movementPattern = new SpiralBulletMovementPattern();
        }

        public bool IsAlive
        {
            get { return alive; }
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(entitySprite, new Rectangle((int)this.X, (int)this.Y, 50, 50), Color.White);
        }

        public override void Update(GameTime gameTime)
        {
            //if (x > 0 && x < 500 && y > 0 && y < 500)
            //{
            //    this.Y -= movementSpeed;
            //}
            //else
            //{
            //    alive = false; // Kill the bullet aka it should be removed from the game
            //}
            movementPattern.Move(ref x, ref y, gameTime, ref movementSpeed);

        }
    }
}
